using System.IO;

namespace Lottery.Services
{
    public interface IFileHandlerService
    {
        void ProcessToFile(string tempFile, string content);
        void CreateFile(string filePath, string content);
        void CleanUpFolder(string path);
    }
}