using Lottery.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lottery.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly IHtmlHandlerService _htmlService;
        private readonly IEnumerable<LotterySetting> _lotterySetting;
        private readonly string _tempFilePath;
        private readonly ILogger<ILotteryService> _logger;

        public LotteryService(IHtmlHandlerService htmlService, AppSettings settings, ILogger<ILotteryService> logger)
        {
            _htmlService = htmlService;
            _lotterySetting = settings.Lotteries;
            _tempFilePath = settings.TempFilePath;
            _logger = logger;
        }

        public IEnumerable<MongoModel> ChooseLottery(List<List<string>> htmlLines, string lotteryName)
        {
            _logger.LogDebug($"Initializing loading for lottery {lotteryName}");
            switch (lotteryName)
            {
                case "DuplaSena":
                    return DuplaSenaExtensionMethods.Load(htmlLines);
                case "Federal":
                    return FederalExtensionMethods.Load(htmlLines);
                case "TimeMania":
                    return TimeManiaExtensionMethods.Load(htmlLines);
                case "Quina":
                    return QuinaExtensionMethods.Load(htmlLines);
                case "LotoMania":
                    return LotoManiaExtensionMethods.Load(htmlLines);
                case "LotoGol":
                    return LotoGolExtensionMethods.Load(htmlLines);
                case "LotoFacil":
                    return LotoFacilExtensionMethods.Load(htmlLines);
                case "Loteca":
                    return LotecaExtensionMethods.Load(htmlLines);
                case "MegaSena":
                    return MegaSenaExtensionMethods.Load(htmlLines);
                default:
                    _logger.LogError($"Error when try to load lottery {lotteryName}.");
                    throw new NotSupportedException($"Lottery {lotteryName} did not support.");
            }
        }
        /// <summary>
        /// TODO : to be improved
        /// </summary>
        /// <param name="lotteryName"></param>
        /// <returns></returns>
        public IEnumerable<MongoModel> Load(string lotteryName)
        {
            try
            {
                var lottery = _lotterySetting.Where(l => l.Name == lotteryName).FirstOrDefault();
                if (lottery == null)
                {
                    var msg = $"The lottery name {lotteryName} did not found on appSettigs, please check AppSetting object.";
                    _logger.LogError(msg);
                    throw new EntryPointNotFoundException(msg);
                }

                IEnumerable<MongoModel> lotteryList = new List<MongoModel>();
                var HTMLFilePath = string.Concat(string.Concat(Environment.CurrentDirectory, _tempFilePath), string.Concat($@"{lottery.Name}/", lottery.HtmlFileName));
                _logger.LogDebug($"Loading lottery file from path: {HTMLFilePath}");
                if (!File.Exists(HTMLFilePath))
                {
                    var msg = $"The lottery file on path {HTMLFilePath} does not exist, please check AppSetting object.";
                    _logger.LogError(msg);
                    throw new FileNotFoundException(msg);
                }
                var listResult = _htmlService.LoadHtmlFile(HTMLFilePath, lottery.Columns);
                _logger.LogDebug($"_htmlService.LoadHTMLFile returned list from LOadHTMLFile with {listResult.Count} rows.");
                lotteryList = ChooseLottery(listResult, lottery.Name);
                _logger.LogDebug($"ChooseLottery returned list with {lotteryList.Count()} rows.");
                return lotteryList;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when Load lottery: {lotteryName}. Message: {e.Message} - StackTrace: {e.StackTrace}.");
                throw;
            }
        }
    }
}
