using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;

namespace Lottery.Services
{
    public class FileHandlerService : IFileHandlerService
    {
        private readonly ILogger<IFileHandlerService> _logger;

        public FileHandlerService(ILogger<IFileHandlerService> logger)
        {
            _logger = logger;
        }

        public void ProcessToFile(string tempFile, string content)
        {
            CreateFile(tempFile, content);
        }

        public void CleanUpFolder(string path)
        {
            try
            {
                _logger.LogDebug($"Cleaning up folder {path}.");
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to Cleanup folder {path}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw;
            }
        }

        public void CreateFile(string filePath, string content)
        {
            try
            {
                _logger.LogDebug($"Creating file from Stream to {filePath}.");
                FileInfo fileInfo = new FileInfo(filePath);
                CreateFolder(fileInfo.Directory);
                File.WriteAllText(filePath, content, Encoding.UTF8);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to create file from Stream to {filePath}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw;
            }
        }

        private void CreateFolder(DirectoryInfo directory)
        {
            try
            {
                if (!directory.Exists)
                {
                    _logger.LogDebug($"Creating folder {directory.FullName}.");
                    directory.Create();
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to create folder from {directory.FullName}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw;
            }
        }
    }
}
