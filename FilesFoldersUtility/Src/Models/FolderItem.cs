using System;
using System.Globalization;

namespace FilesFoldersUtility.Src.Models
{
    public class FolderItem : IComparable<FolderItem>
    {
        private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        /// <summary>
        /// Builder to create folder
        /// </summary>
        /// <param name="name">Folder name</param>
        public FolderItem(string name)
        {
            Name = textInfo.ToTitleCase(name).Trim();
        }

        /// <summary>
        /// Builder to create child folder
        /// </summary>
        /// <param name="parent">Parent folder</param>
        /// <param name="name">Folder name</param>
        public FolderItem(string parent, string name)
        {
            Parent = textInfo.ToTitleCase(parent).Trim();
            Name = textInfo.ToTitleCase(name).Trim();
        }

        public string Parent { get; private set; }
        public string Name { get; private set; }
        public bool HasParent() => !string.IsNullOrWhiteSpace(Parent);
        public int CompareTo(FolderItem other)
        {
            if (other == null)
                return -1;

            else
                return this.HasParent().CompareTo(other.HasParent());
        }
    }
}
