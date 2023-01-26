using System.Globalization;
using System.Linq;
using System.Text;
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
            name = RemoveAccent(textInfo.ToTitleCase(name).Trim());

            return Regex.Replace(name, @"\s+", "-", RegexOptions.Compiled);
        }

        public static string RemoveAccent(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return name;

            return new string(name
            .Normalize(NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            .ToArray());
        }
    }
}
