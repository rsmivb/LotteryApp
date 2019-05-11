
using Lottery.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Net;

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
        public bool DownloadFile(string lotteryName)
        {
            try
            {
                _logger.LogDebug($"Getting data from AppSettings for lottery {lotteryName}.");
                var _setting = _settings.Lotteries.Where(l => l.Name.Equals(lotteryName)).FirstOrDefault();
                if (_setting == null) throw new ArgumentNullException("Object Lottery setting must not be null.");
                string path = string.Concat(Environment.CurrentDirectory, _settings.TempFilePath);

                _fileHandler.CreateFolder(path);
                var filePath = Path.Combine(path, _setting.ZipFileName);
                var destinationPath = Path.Combine(path, _setting.Name);
                var streamResponse = GetStreamFileFromWebService(_setting.WebService);
                _fileHandler.CreateFileFromStream(filePath, streamResponse);
                _fileHandler.ExtractFile(filePath, destinationPath);
                _logger.LogInformation($"Finished DownloadFile for {lotteryName}.");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during downloading file process. Lottery {lotteryName}, error message - {e.Message}, stacktrace - {e.StackTrace} - inner exception - {e.InnerException?.Message}.");
                throw e;
            }
        }
        public Stream GetStreamFileFromWebService(string lotteryWebServiceUrl)
        {
            _logger.LogDebug($"Connecting with web service url: {lotteryWebServiceUrl}.");
            CookieContainer myContainer = new CookieContainer();
            var request = (HttpWebRequest)WebRequest.Create(lotteryWebServiceUrl);
            request.MaximumAutomaticRedirections = 1;
            request.AllowAutoRedirect = true;
            request.CookieContainer = myContainer;
            return request.GetResponse().GetResponseStream();
        }
    }
}
