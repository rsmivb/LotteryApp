using Lottery.Models;
using Lottery.Models.Lotteries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lottery.Services
{
    public class LotteryDataBuilder : ILotteryDataBuilder
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<ILotteryDataBuilder> _logger;

        public LotteryDataBuilder(ILogger<ILotteryDataBuilder> logger,
                                AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public LotteryData Build(string lotteryName)
        {
            var lottery = _appSettings.Lotteries.FirstOrDefault(l => l.Name.Equals(lotteryName, StringComparison.InvariantCultureIgnoreCase));

            if (lottery is null)
            {
                var msg = $"The lottery name {lotteryName} did not find in application, please check the lottery name.";
                _logger.LogError(msg);
                throw new EntryPointNotFoundException(msg);
            }

            return new LotteryData
            {
                Name = lotteryName,
                CaixaLotteryURL = lottery.WebSite,
                HtmlFilePath = $"{Environment.CurrentDirectory}{_appSettings.TempFilePath}{lottery.HtmlFileName}",
                Columns = lottery.Columns,
                Entries = new List<Repository.MongoModel>()
            };
        }
    }

    public interface ILotteryDataBuilder
    {
        LotteryData Build(string lotteryName);
    }
}
