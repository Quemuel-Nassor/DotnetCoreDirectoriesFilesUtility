using FilesFoldersUtility.Src.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace FilesFoldersUtility.Src
{
    public class Utility : IUtility
    {
        private readonly Hashtable AppFolders = new Hashtable();

        public Utility(IHttpContextAccessor httpContextAccessor,
            IHostEnvironment environment,
            List<FolderItem> folders)
        {
            HttpRequest request = httpContextAccessor.HttpContext.Request;
            string localhost = $"{request.Scheme}://{request.Host.Value}";
            string appRoot = Path.Combine(environment.ContentRootPath, "wwwroot");

            CreateFolders(appRoot, localhost, folders);
        }
        public Utility(string localhost,
            IHostEnvironment environment,
            List<FolderItem> folders)
        {
            string appRoot = Path.Combine(environment.ContentRootPath, "wwwroot");

            CreateFolders(appRoot, localhost, folders);
        }

        private void CreateFolders(string appRoot, string localhost, List<FolderItem> folders)
        {
            folders.Sort();
            foreach (FolderItem item in folders)
            {
                string basePath = !item.HasParent() ? appRoot : (string)AppFolders[$"Physical{item.Parent}"];
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
            string key = $"Web{folderName}";

            if (!AppFolders.ContainsKey(key))
                throw new Exception("Url not found");

            string url = (string)AppFolders[key];
            return !string.IsNullOrWhiteSpace(filename) ? $"{url}/{filename}" : url;
        }

        public string GetPath(string folderName, string filename = null)
        {
            string key = $"Physical{folderName}";

            if (!AppFolders.ContainsKey(key))
                throw new Exception("Directory not found");

            string path = (string)AppFolders[key];
            return !string.IsNullOrWhiteSpace(filename) ? Path.Combine(path, filename) : path;
        }
    }
}
