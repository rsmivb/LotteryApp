using Lottery.Models;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lottery.Services
{
    public class LotteryService : ILotteryService
    {
        private IHTMLHandlerService _htmlService;
        private IEnumerable<LotterySetting> _lotterySetting;
        private string _tempFilePath;
        private ILogger<ILotteryService> _logger;

        public LotteryService(IHTMLHandlerService htmlService, AppSettings settings, ILogger<ILotteryService> logger)
        {
            _htmlService = htmlService;
            _lotterySetting = settings.Lotteries;
            _tempFilePath = settings.TempFilePath;
            _logger = logger;
        }

        public IEnumerable<MongoModel> ChooseLottery(List<List<string>> htmlLines, string lotteryName)
        {
            _logger.LogDebug($"Initializing loading for lottery {lotteryName}");
            IEnumerable<MongoModel> results;
            switch (lotteryName)
            {
                case "DuplaSena":
                    results = DuplaSenaExtensionMethods.Load(htmlLines);
                    break;
                case "Federal":
                    results = FederalExtensionMethods.Load(htmlLines);
                    break;
                case "TimeMania":
                    results = TimeManiaExtensionMethods.Load(htmlLines);
                    break;
                case "Quina":
                    results = QuinaExtensionMethods.Load(htmlLines);
                    break;
                case "LotoMania":
                    results = LotoManiaExtensionMethods.Load(htmlLines);
                    break;
                case "LotoGol":
                    results = LotoGolExtensionMethods.Load(htmlLines);
                    break;
                case "LotoFacil":
                    results = LotoFacilExtensionMethods.Load(htmlLines);
                    break;
                case "Loteca":
                    results = LotecaExtensionMethods.Load(htmlLines);
                    break;
                case "MegaSena":
                    results = MegaSenaExtensionMethods.Load(htmlLines);
                    break;
                default:
                    _logger.LogError($"Error when try to load lottery {lotteryName}.");
                    throw new NotSupportedException($"Lottery {lotteryName} did not support.");
            }
            return results;
        }

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
                var path = string.Concat(string.Concat(Environment.CurrentDirectory, _tempFilePath), string.Concat($@"{lottery.Name}\", lottery.HtmlFileName));
                _logger.LogDebug($"Loading lottery file from path: {path}");
                if (!System.IO.File.Exists(path))
                {
                    var msg = $"The lottery file on path {path} does not exist, please check AppSetting object.";
                    _logger.LogError(msg);
                    throw new System.IO.FileNotFoundException(msg);
                }

                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
                {
                    var listResult = _htmlService.LoadHTMLFile(stream, lottery.Columns);
                    _logger.LogDebug($"_htmlService.LoadHTMLFile returned list from LOadHTMLFile with {listResult.Count} rows.");
                    lotteryList = ChooseLottery(listResult, lottery.Name);
                    _logger.LogDebug($"ChooseLottery returned list with {lotteryList.Count()} rows.");
                }
                return lotteryList;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when Load lottery: {lotteryName}. Message: {e.Message} - StackTrace: {e.StackTrace}.");
                throw e;
            }
        }
    }
}
