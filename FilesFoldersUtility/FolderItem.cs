using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FilesFoldersUtility
{
    internal class FolderItem : IComparable<FolderItem>
    {
        private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        private string Sanitize(string name)
        {
            name = Regex.Replace(name, @"([\\\/|<>*:“?])", "", RegexOptions.Compiled);
            return textInfo.ToTitleCase(name).Trim();
        }

        /// <summary>
        /// Overloaded Builder to create directory
        /// </summary>
        /// <param name="name">Directory name</param>
        public FolderItem(string name)
        {
            Name = Sanitize(name);
        }

        /// <summary>
        /// Overloaded Builder to create child directory
        /// </summary>
        /// <param name="parent">Parent folder</param>
        /// <param name="name">Directory name</param>
        public FolderItem(string parent, string name)
        {
            Parent = Sanitize(parent);
            Name = Sanitize(name);
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
