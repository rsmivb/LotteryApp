
using Lottery.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services
{
    public class WebService : IWebService
    {
        private readonly IFileHandlerService _fileHandler;
        private readonly AppSettings _settings;
        private readonly ILogger<IWebService> _logger;

        public WebService(IFileHandlerService fileHandler, AppSettings settings, ILogger<IWebService> logger)
        {
            _fileHandler = fileHandler;
            _settings = settings;
            _logger = logger;
        }
        public void DownloadFile(string lotteryName)
        {
            try
            {
                _logger.LogDebug($"Getting data from AppSettings for lottery {lotteryName}.");
                var _setting = _settings.Lotteries.Where(l => l.Name.Equals(lotteryName)).FirstOrDefault();
                if (_setting == null) throw new ArgumentNullException("Object Lottery setting must not be null.");
                string path = string.Concat(Environment.CurrentDirectory, _settings.TempFilePath);
                _logger.LogDebug($"Creating folder for path {path}.");
                _fileHandler.CreateFolder(path);
                _logger.LogDebug($"Connecting with web service url: {_setting.WebService}.");
                CookieContainer myContainer = new CookieContainer();
                var request = (HttpWebRequest)WebRequest.Create(_setting.WebService);
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.CookieContainer = myContainer;
                var response = (HttpWebResponse)request.GetResponse();
                var filePath = Path.Combine(path, _setting.ZipFileName);
                var destinationPath = Path.Combine(path, _setting.Name);
                _logger.LogDebug($"Loading Response to a file path: {filePath}.");
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                _logger.LogDebug($"Extracting file from {filePath} to {destinationPath}");
                _fileHandler.ExtractFile(filePath, destinationPath);
                _logger.LogInformation($"Finished DownloadFile for {lotteryName}.");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during downloading file process. Lottery {lotteryName}, error message - {e.Message}, stacktrace - {e.StackTrace} - inner exception - {e.InnerException?.Message}.");
                throw e;
            }
        }
    }
}
