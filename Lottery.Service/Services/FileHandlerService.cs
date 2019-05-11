using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.IO.Compression;

namespace Lottery.Services
{
    public class FileHandlerService : IFileHandlerService
    {
        private ILogger<IFileHandlerService> _logger;

        public FileHandlerService(ILogger<IFileHandlerService> logger)
        {
            _logger = logger;
        }
        public void ExtractFile(string zipPath, string tempFile)
        {
            try
            {
                _logger.LogDebug($"Extracting file {zipPath} to {tempFile}");
                ZipFile.ExtractToDirectory(zipPath, tempFile);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to extract from {zipPath}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw e;
            }
        }
        public void CleanUpFolder(string path)
        {
            try
            {
                _logger.LogDebug($"Cleaning up folder {path}.");
                if (Directory.Exists(path)) Directory.Delete(path, true);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to Cleanup folder {path}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw e;
            }
        }
        public void CreateFolder(string path)
        {
            try
            {
                _logger.LogDebug($"Creating folder {path}.");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to create folder from {path}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw e;
            }
        }
        public void CreateFileFromStream(string filePath, Stream stream)
        {
            try
            {
                _logger.LogDebug($"Creating file from Stream {filePath}.");
                using (var responseStream = stream)
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to create file from Stream {filePath}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw e;
            }
        }
    }
}
