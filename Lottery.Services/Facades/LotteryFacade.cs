using Microsoft.Extensions.Logging;

namespace Lottery.Services
{
    public class LotteryFacade : ILotteryFacade
    {
        private readonly ILogger<ILotteryFacade> _logger;
        private readonly ILotteryDataBuilder _lotteryDataBuilder;
        private readonly IProcessLotteryFileService _processLotteryFileService;
        private readonly IHtmlHandlerService _htmlHandlerService;
        private readonly ILotteryService _lotteryService;

        public LotteryFacade( ILogger<ILotteryFacade> logger,
            ILotteryDataBuilder lotteryDataBuilder,
            IProcessLotteryFileService processLotteryFileService,
            IHtmlHandlerService htmlHandlerService,
            ILotteryService lotteryService
            )
        {
            _logger = logger;
            _lotteryDataBuilder = lotteryDataBuilder;
            _processLotteryFileService = processLotteryFileService;
            _htmlHandlerService = htmlHandlerService;
            _lotteryService = lotteryService;
        }
        public void LoadData(string lotteryName)
        {
            // build lotteryData
            var lotteryData = _lotteryDataBuilder.Build(lotteryName);
            // download zip file from Caixa WebService and extract to a html file
            if (_processLotteryFileService.Execute(lotteryData))
            {

                //get repositories from IServiceCollection

                // build Entries
                var entries = _htmlHandlerService.ConvertHtmlTo(lotteryData);
                _lotteryService.Load(entries, lotteryData);

                // load to database based on repository

            }
        }
    }

    public interface ILotteryFacade
    {
        void LoadData(string lotteryName);
    }
}
