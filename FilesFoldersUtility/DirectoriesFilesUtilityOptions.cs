using System;
using System.Collections.Generic;

namespace FilesFoldersUtility
{
    public class DirectoriesFilesUtilityOptions
    {
        internal List<FolderItem> AppFolders = new List<FolderItem>();
        internal string Localhost { get; set; }

        /// <summary>
        /// This flag enable for use application root as wwwroot to compatibility with IWebHostEnvironment interface (Default == true)
        /// </summary>
        public bool UseWwwRootAsAppRoot { get; set; } = true;

        /// <summary>
        /// Defines a new base URL for accessing static files in the app over the internet
        /// </summary>
        /// <param name="localhost">New base URL for accessing static files in the app over the internet</param>
        /// <exception cref="ArgumentException">Argument passed is empty or null</exception>
        public void SetLocalhost(string localhost)
        {
            if (string.IsNullOrWhiteSpace(localhost))
            {
                throw new ArgumentException($"'{nameof(localhost)}' cannot be null or whitespace.", nameof(localhost));
            }

            Localhost = localhost;
        }

        /// <summary>
        /// Defines a static child directory to be registered during application execution
        /// </summary>
        /// <param name="parent">Parent directory</param>
        /// <param name="name">Child directory</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddFolder(string parent, string name)
        {
            if (string.IsNullOrWhiteSpace(parent))
            {
                throw new ArgumentException($"'{nameof(parent)}' cannot be null or empty.", nameof(parent));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            AppFolders.Add(new FolderItem(parent, name));
        }

        /// <summary>
        /// Defines a static directory to be registered during application execution
        /// </summary>
        /// <param name="name">Child directory</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddFolder(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            AppFolders.Add(new FolderItem(name));
        }
    }
}
