
using Lottery.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Lottery.Services
{
    public class ProcessLotteryService : IProcessLotteryService
    {
        private readonly IFileHandlerService _fileHandler;
        private readonly AppSettings _settings;
        private readonly IWebServiceService _webService;
        private readonly ILogger<IProcessLotteryService> _logger;

        public ProcessLotteryService(IFileHandlerService fileHandler, AppSettings settings, IWebServiceService webService, ILogger<IProcessLotteryService> logger)
        {
            _fileHandler = fileHandler;
            _settings = settings;
            _webService = webService;
            _logger = logger;
        }
        public bool ProcessLotteryFile(string lotteryName)
        {
            try
            {
                _logger.LogDebug($"Getting data from AppSettings for lottery {lotteryName}.");
                var _setting = _settings.Lotteries.FirstOrDefault(l => l.Name.Equals(lotteryName));
                if (_setting == null) throw new ArgumentNullException("Object Lottery setting must not be null.");
                string path = string.Concat(Environment.CurrentDirectory, _settings.TempFilePath);

                _fileHandler.CreateFolder(path);
                var filePath = Path.Combine(path, $"{_setting.Name}{Constants.ZIP}");
                var destinationPath = Path.Combine(path, _setting.Name);
                var streamResponse = _webService.GetStreamFileFromWebService($"{_settings.DefaultURL}{_setting.WebFileName}");
                _fileHandler.CreateFileFromStream(filePath, streamResponse);
                _fileHandler.ExtractFile(filePath, destinationPath);
                _logger.LogInformation($"Finished DownloadFile for {lotteryName}.");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during downloading file process. Lottery {lotteryName}, error message - {e.Message}, stacktrace - {e.StackTrace} - inner exception - {e.InnerException?.Message}.");
                throw ;
            }
        }
    }
}
