using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Services
{
    public class LotteryFacade : ILotteryFacade
    {
        private readonly ILogger<ILotteryFacade> _logger;
        private readonly ILotteryDataBuilder _lotteryDataBuilder;
        private readonly IProcessLotteryFileService _processLotteryFileService;
        private readonly IHtmlHandlerService _htmlHandlerService;

        public LotteryFacade( ILogger<ILotteryFacade> logger,
            ILotteryDataBuilder lotteryDataBuilder,
            IProcessLotteryFileService processLotteryFileService,
            IHtmlHandlerService htmlHandlerService
            )
        {
            _logger = logger;
            _lotteryDataBuilder = lotteryDataBuilder;
            _processLotteryFileService = processLotteryFileService;
            _htmlHandlerService = htmlHandlerService;
        }
        public void LoadData(string lotteryName)
        {
            // build lotteryData
            var lotteryData = _lotteryDataBuilder.Build(lotteryName);
            // download zip file from Caixa WebService and extract to a html file
            _processLotteryFileService.Execute(lotteryData);
            // build Entries
            var entries = _htmlHandlerService.ConvertHtmlTo(lotteryData);
            // load to database
        }
    }

    public interface ILotteryFacade
    {
    }
}
