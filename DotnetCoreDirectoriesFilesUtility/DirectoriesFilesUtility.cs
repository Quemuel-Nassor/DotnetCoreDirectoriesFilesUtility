using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SH = DotnetCoreDirectoriesFilesUtility.SanitizerHelper;

namespace FilesFoldersUtility
{
    internal class DirectoriesFilesUtility : IDirectoriesFilesUtility
    {
        private readonly Hashtable AppFolders = new Hashtable();

        public DirectoriesFilesUtility(
            IServiceProvider services,
            IOptions<DirectoriesFilesUtilityOptions> options)
        {
            IHttpContextAccessor httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
            IHostEnvironment environment = services.GetRequiredService<IHostEnvironment>();
            HttpRequest request = httpContextAccessor.HttpContext.Request;
            DirectoriesFilesUtilityOptions _options = options.Value;

            string localhost = string.IsNullOrWhiteSpace(_options.Localhost) ? $"{request.Scheme}://{request.Host.Value}" : _options.Localhost;
            string rootAppFolder = _options.UseWwwRootAsAppRoot ? Path.Combine(environment.ContentRootPath, "wwwroot") : environment.ContentRootPath;

            CreateFolders(rootAppFolder, localhost, _options.AppFolders);
        }

        private void CreateFolders(string rootAppFolder, string localhost, List<FolderItem> folders)
        {
            folders.Sort();
            foreach (FolderItem item in folders)
            {
                string basePath = !item.HasParent() ? rootAppFolder : (string)AppFolders[$"Physical{item.Parent}"];
                string baseUrl = !item.HasParent() ? localhost : (string)AppFolders[$"Web{item.Parent}"];

                string physicalPath = Path.Combine(basePath, item.Name);
                string webPath = $"{baseUrl}/{item.Name}";

                AppFolders.Add($"Physical{item.Name}", physicalPath);
                AppFolders.Add($"Web{item.Name}", webPath);

                Directory.CreateDirectory((string)AppFolders[$"Physical{item.Name}"]);
            }
        }

        public string GetUrl(string folderName, string filename = null)
        {
            string key = $"Web{SH.Sanitize(folderName)}";

            if (!AppFolders.ContainsKey(key))
                throw new Exception("Url not found");

            string url = (string)AppFolders[key];
            return !string.IsNullOrWhiteSpace(filename) ? $"{url}/{filename}" : url;
        }

        public string GetPath(string folderName, string filename = null)
        {
            string key = $"Physical{SH.Sanitize(folderName)}";

            if (!AppFolders.ContainsKey(key))
                throw new Exception("Directory not found");

            string path = (string)AppFolders[key];
            return !string.IsNullOrWhiteSpace(filename) ? Path.Combine(path, filename) : path;
        }
    }
}
