using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.IO.Compression;

namespace Lottery.Services
{
    public class FileHandlerService : IFileHandlerService
    {
        private readonly ILogger<IFileHandlerService> _logger;

        public FileHandlerService(ILogger<IFileHandlerService> logger)
        {
            _logger = logger;
        }

        public void ProcessToFile(Stream stream, string zipPath, string tempFile)
        {
            CreateFileFromStream(zipPath, stream);
            ExtractFile(zipPath, tempFile);
        }
        public void ExtractFile(string zipPath, string tempFile)
        {
            try
            {
                _logger.LogDebug($"Extracting file {zipPath} to {tempFile}");
                ZipFile.ExtractToDirectory(zipPath, tempFile,true);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to extract from {zipPath}. Error -> {e.Message} -> StackTrace -> {e.StackTrace}.");
                throw;
            }
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

        public void CreateFileFromStream(string filePath, Stream stream)
        {
            try
            {
                _logger.LogDebug($"Creating file from Stream to {filePath}.");
                FileInfo fileInfo = new FileInfo(filePath);
                CreateFolder(fileInfo.Directory);
                using (var responseStream = stream)
                {
                    using (var fileStream = new FileStream(fileInfo.FullName, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
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
