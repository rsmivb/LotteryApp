namespace Lottery.Services
{
    public interface IFileHandler
    {
        void ExtractFile(string zipPath, string tempFile);
        void CleanUpFolder(string path);
        void CreateFolder(string path);
    }
}