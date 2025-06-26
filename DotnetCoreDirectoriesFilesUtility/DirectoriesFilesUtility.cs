using DotnetCoreDirectoriesFilesUtility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FilesFoldersUtility
{
    internal class DirectoriesFilesUtility : IDirectoriesFilesUtility
    {
        private readonly IDictionary<string, string> AppFolders = new Dictionary<string, string>();

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
            for (int i = 0; i < folders.Count; i++)
            {
                string basePath = folders[i].HasParent ? AppFolders[$"Physical{folders[i].Parent}"] : rootAppFolder;
                string baseUrl = folders[i].HasParent ? AppFolders[$"Web{folders[i].Parent}"] : localhost;

                string physicalPath = Path.Combine(basePath, folders[i].Name);
                string webPath = $"{baseUrl}/{folders[i].Name}";

                AppFolders.Add($"Physical{folders[i].Name}", physicalPath);
                AppFolders.Add($"Web{folders[i].Name}", webPath);

                Directory.CreateDirectory(physicalPath);
            }
        }

        public string GetUrl(string folderName, string filename = null)
        {
            string key = $"Web{folderName.SanitizeDirectoryName()}";

            if (!AppFolders.TryGetValue(key, out string url))
                throw new Exception("Url not found");

            return !string.IsNullOrWhiteSpace(filename) ? $"{url}/{filename}" : url;
        }

        public string GetPath(string folderName, string filename = null)
        {
            string key = $"Physical{folderName.SanitizeDirectoryName()}";

            if (!AppFolders.TryGetValue(key, out string path))
                throw new Exception("Directory not found");

            return !string.IsNullOrWhiteSpace(filename) ? Path.Combine(path, filename) : path;
        }

        public string CopyFile(string sourcePath, string destinationPath, bool replaceIfExist = false)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
                throw new ArgumentException($"'{nameof(sourcePath)}' cannot be null or whitespace.", nameof(sourcePath));

            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException($"'{nameof(destinationPath)}' cannot be null or whitespace.", nameof(destinationPath));

            if (!File.Exists(sourcePath))
                throw new Exception("Source file not found");

            string diskPath = destinationPath.Substring(0, destinationPath.LastIndexOf(Path.DirectorySeparatorChar));

            Directory.CreateDirectory(diskPath);

            if (!replaceIfExist)
                destinationPath = destinationPath.AutoIndexFile();

            File.Copy(sourcePath, destinationPath, replaceIfExist);

            return Path.GetFileName(destinationPath);
        }

        public string MoveFile(string sourcePath, string destinationPath, bool replaceIfExist = false)
        {
            destinationPath = CopyFile(sourcePath, destinationPath, replaceIfExist);
            File.Delete(sourcePath);

            return destinationPath;
        }

        public async Task<string> WriteFile(Stream file, string destinationPath, bool replaceIfExist = false)
        {
            if (file is null)
                throw new ArgumentNullException(nameof(file));

            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException($"'{nameof(destinationPath)}' cannot be null or whitespace.", nameof(destinationPath));

            string diskPath = destinationPath.Substring(0, destinationPath.LastIndexOf(Path.DirectorySeparatorChar));

            Directory.CreateDirectory(diskPath);

            if (!replaceIfExist)
                destinationPath = destinationPath.AutoIndexFile();

            using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
            {
                if(file.CanSeek) file.Position = 0;
                await file.CopyToAsync(fs);
            }

            return Path.GetFileName(destinationPath);
        }
    }
}
