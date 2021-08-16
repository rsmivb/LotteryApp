using Lottery.Models.Lotteries;
using Microsoft.Extensions.Logging;
using System;

namespace Lottery.Services
{
    public class ProcessLotteryFileService : IProcessLotteryFileService
    {
        private readonly ILogger<IProcessLotteryFileService> _logger;
        private readonly IFileHandlerService _fileHandlerService;
        private readonly ICaixaWSService _webService;

        public ProcessLotteryFileService( ILogger<IProcessLotteryFileService> logger,
                                        IFileHandlerService fileHandlerService,
                                        ICaixaWSService webService)
        {
            _logger = logger;
            _fileHandlerService = fileHandlerService;
            _webService = webService;
        }
        public bool Execute(LotteryData lottery)
        {
            try
            {
                var content = _webService.GetContent(lottery.CaixaLotteryURL);
                _fileHandlerService.ProcessToFile(lottery.HtmlFilePath, content);
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
