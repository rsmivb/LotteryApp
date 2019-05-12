using System.IO;

namespace Lottery.Services
{
    public interface IFileHandlerService
    {
        void ExtractFile(string zipPath, string tempFile);
        void CleanUpFolder(string path);
        void CreateFolder(string path);
        void CreateFileFromStream(string filePath, Stream stream);
    }
}