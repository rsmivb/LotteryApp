using System.IO;

namespace Lottery.Services
{
    public interface IFileHandlerService
    {
        void ProcessToFile(Stream stream, string zipPath, string tempFile);
        void ExtractFile(string zipPath, string tempFile);
        void CreateFileFromStream(string filePath, Stream stream);
        void CleanUpFolder(string path);
    }
}