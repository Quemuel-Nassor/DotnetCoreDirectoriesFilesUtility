namespace FilesFoldersUtility.Src
{
    public interface IUtility
    {
        string GetUrl(string folderName, string filename = null);
        string GetPath(string folderName, string filename = null);
    }
}
