
using Lottery.Models;
using Lottery.Models.Lotteries;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace Lottery.Services
{
    public class ProcessLotteryFileService : IProcessLotteryFileService
    {
        private readonly ILogger<IProcessLotteryFileService> _logger;
        private readonly IFileHandlerService _fileHandlerService;
        private readonly IWebServiceService _webService;

        public ProcessLotteryFileService( ILogger<IProcessLotteryFileService> logger,
                                        IFileHandlerService fileHandlerService,
                                        IWebServiceService webService)
        {
            _logger = logger;
            _fileHandlerService = fileHandlerService;
            _webService = webService;
        }
        public bool Execute(LotteryData lottery)
        {
            try
            {
                var stream = _webService.GetStreamFileFromWebService(lottery.SenderUrlPath);
                _fileHandlerService.ProcessToFile(stream, lottery.ZipPath, lottery.HtmlFilePath);
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error during downloading file process. Lottery {lottery.Name}, error message - {e.Message}, stacktrace - {e.StackTrace} - inner exception - {e.InnerException?.Message}.");
                return false;
            }
        }
    }
}
