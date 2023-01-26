using System.Globalization;
using System.Text.RegularExpressions;

namespace DotnetCoreDirectoriesFilesUtility
{
    internal static class SanitizerHelper
    {
        private static TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public static string Sanitize(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            name = Regex.Replace(name, @"([\\\/|<>*:“?])", "", RegexOptions.Compiled);
            name = textInfo.ToTitleCase(name).Trim();

            return Regex.Replace(name, @"\s+", "-", RegexOptions.Compiled);
        }
    }
}
