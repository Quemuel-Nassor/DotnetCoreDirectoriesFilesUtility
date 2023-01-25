namespace FilesFoldersUtility
{
    public interface IDirectoriesFilesUtility
    {
        /// <summary>
        /// Returns base URL for static files based on directory passed, or full URL for file if given file name
        /// </summary>
        /// <param name="folderName">Directory name</param>
        /// <param name="filename">Target file into directory</param>
        /// <exception cref="Exception">Url not found</exception>
        /// <returns></returns>
        string GetUrl(string folderName, string filename = null);

        /// <summary>
        /// Returns full path for static files based on directory passed, or full Path for file if given file name
        /// </summary>
        /// <param name="folderName">Directory name</param>
        /// <param name="filename">Target file into directory</param>
        /// <exception cref="Exception">Directory not found</exception>
        /// <returns></returns>
        string GetPath(string folderName, string filename = null);
    }
}
