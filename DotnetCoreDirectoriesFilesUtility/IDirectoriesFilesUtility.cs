using System.IO;
using System.Threading.Tasks;

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

        /// <summary>
        /// Copy a file from source to destination
        /// </summary>
        /// <param name="sourcePath">Source file path</param>
        /// <param name="destinationPath">Destination file path</param>
        /// <param name="replaceIfExist">Overwrite file if already exist</param>
        /// <returns>End file namee</returns>
        /// <exception cref="ArgumentException">sourcePath or destinationPath is empty or null</exception>
        /// <exception cref="Exception">Source file not found</exception>
        string CopyFile(string sourcePath, string destinationPath, bool replaceIfExist = false);

        /// <summary>
        /// Move a file from source to destination deleting source file
        /// </summary>
        /// <param name="sourcePath">Source file path</param>
        /// <param name="destinationPath">Destination file path</param>
        /// <param name="replaceIfExist">Overwrite file if already exist</param>
        /// <returns>End file namee</returns>
        /// <exception cref="ArgumentException">SourcePath or destinationPath is empty or null</exception>
        /// <exception cref="Exception">Source file not found</exception>
        string MoveFile(string sourcePath, string destinationPath, bool replaceIfExist = false);

        /// <summary>
        /// Write a file from stream to destination
        /// </summary>
        /// <param name="file">File stream</param>
        /// <param name="destinationPath">Destination file path</param>
        /// <param name="replaceIfExist">Overwrite file if already exist</param>
        /// <returns>End file namee</returns>
        /// <exception cref="ArgumentNullException">File is null</exception>
        /// <exception cref="ArgumentException">DestinationPath is empty or null</exception>
        Task<string> WriteFile(Stream file, string destinationPath, bool replaceIfExist = false);
    }
}
