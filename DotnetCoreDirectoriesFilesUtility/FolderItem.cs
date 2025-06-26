using DotnetCoreDirectoriesFilesUtility;
using System;

namespace FilesFoldersUtility
{
    internal class FolderItem : IComparable<FolderItem>
    {
        /// <summary>
        /// Overloaded Builder to create directory
        /// </summary>
        /// <param name="name">Directory name</param>
        public FolderItem(string name)
        {
            Name = name.SanitizeDirectoryName();
        }

        /// <summary>
        /// Overloaded Builder to create child directory
        /// </summary>
        /// <param name="parent">Parent folder</param>
        /// <param name="name">Directory name</param>
        public FolderItem(string parent, string name)
        {
            Parent = parent.SanitizeDirectoryName();
            Name = name.SanitizeDirectoryName();
            HasParent = true;
        }

        public string Parent { get; private set; }
        public string Name { get; private set; }
        public bool HasParent { get; private set; }
        public int CompareTo(FolderItem other)
        {
            if (other == null)
                return -1;

            else
                return HasParent.CompareTo(other.HasParent);
        }
    }
}
