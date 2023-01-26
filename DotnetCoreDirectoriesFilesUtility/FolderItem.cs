using System;
using SH = DotnetCoreDirectoriesFilesUtility.SanitizerHelper;

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
            Name = SH.Sanitize(name);
        }

        /// <summary>
        /// Overloaded Builder to create child directory
        /// </summary>
        /// <param name="parent">Parent folder</param>
        /// <param name="name">Directory name</param>
        public FolderItem(string parent, string name)
        {
            Parent = SH.Sanitize(parent);
            Name = SH.Sanitize(name);
        }

        public string Parent { get; private set; }
        public string Name { get; private set; }
        public bool HasParent() => !string.IsNullOrWhiteSpace(Parent);
        public int CompareTo(FolderItem other)
        {
            if (other == null)
                return -1;

            else
                return HasParent().CompareTo(other.HasParent());
        }
    }
}
