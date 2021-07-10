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

        public LotteryFacade( ILogger<ILotteryFacade> logger,
            ILotteryDataBuilder lotteryDataBuilder,
            IProcessLotteryFileService processLotteryFileService
            )
        {
            _logger = logger;
            _lotteryDataBuilder = lotteryDataBuilder;
            _processLotteryFileService = processLotteryFileService;
        }
        public void LoadData(string lotteryName)
        {
            // build lotteryData
            var lotteryData = _lotteryDataBuilder.Build(lotteryName);
            // download zip file from Caixa WebService and extract to a html file
            _processLotteryFileService.Execute(lotteryData);
            // build Entries

            // load to database
        }
    }

    public interface ILotteryFacade
    {
    }
}
