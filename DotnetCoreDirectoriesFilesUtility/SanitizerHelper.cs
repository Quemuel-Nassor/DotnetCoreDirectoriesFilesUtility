using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotnetCoreDirectoriesFilesUtility
{
    internal static class SanitizerHelper
    {
        private static TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public static string SanitizeDir(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            name = Regex.Replace(name, @"([\\\/|<>*:“?])", "", RegexOptions.Compiled);
            name = textInfo.ToTitleCase(name).Trim().RemoveAccent();

            return Regex.Replace(name, @"\s+", "-", RegexOptions.Compiled);
        }

        public static string RemoveAccent(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            return new string(name
            .Normalize(NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            .ToArray());
        }
    }

    internal static class FileHelper
    {
        public static string AutoIndexFile(this string destinationPath)
        {
            if (!File.Exists(destinationPath))
                return destinationPath;

            string filePath = Path.GetDirectoryName(destinationPath);
            string extension = Path.GetExtension(destinationPath);
            string[] files = Directory.GetFiles(filePath);

            var filesThatContainsSameName = files.Where(f => f.GetFileName().IndexOf(destinationPath.GetFileName(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            filesThatContainsSameName.Sort();

            List<int> filesIndexes = filesThatContainsSameName
                .Select(f => Regex.Match(f, @"\(\d*\)").Value.Replace("(", "").Replace(")", ""))
                .Where(f => !string.IsNullOrWhiteSpace(f))
                .Select(f => Convert.ToInt32(f))
                .ToList();

            int index = (filesIndexes.Any() ? filesIndexes.Max() : 0) + 1;

            return destinationPath.Replace($"{extension}", $" ({index}){extension}");

        }

        private static string GetFileName(this string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }
    }
}
