﻿using Lottery.Models;
using Lottery.Models.Lotteries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lottery.Services
{
    public class LotteryDataBuilder : ILotteryDataBuilder
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<ILotteryDataBuilder> _logger;

        public LotteryDataBuilder(AppSettings appSettings, ILogger<ILotteryDataBuilder> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        public LotteryData Build(string lotteryName)
        {
            var lottery = _appSettings.Lotteries.FirstOrDefault(l => l.Name == lotteryName);

            if (lottery is null)
            {
                var msg = $"The lottery name {lotteryName} did not find in application, please check the lottery name.";
                _logger.LogError(msg);
                throw new EntryPointNotFoundException(msg);
            }

            return new LotteryData
            {
                Name = lotteryName,
                SenderUrlPath = new Uri($"{_appSettings.DefaultURL}{lottery.ZipFileName}"),
                ZipPath = Path.Combine(Environment.CurrentDirectory,_appSettings.TempFilePath,lottery.ZipFileName),
                HtmlFilePath = Path.Combine(Environment.CurrentDirectory,_appSettings.TempFilePath, lottery.HtmlFileName),
                Columns = lottery.Columns
            };
        }
    }

    public interface ILotteryDataBuilder
    {
        LotteryData Build(string lotteryName);
    }
}
