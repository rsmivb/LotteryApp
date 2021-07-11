using Lottery.Models.Lotteries;
using Lottery.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lottery.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly ILogger<ILotteryService> _logger;

        public LotteryService( ILogger<ILotteryService> logger)
        {
            _logger = logger;
        }

        //public IEnumerable<MongoModel> ChooseLottery(List<List<string>> htmlLines)
        //{
        //    _logger.LogDebug($"Initializing loading for lottery {lotteryName}");
        //    switch (model.)
        //    {
        //        case "DuplaSena":
        //            return DuplaSenaExtensionMethods.Load(htmlLines);
        //        case "Federal":
        //            return FederalExtensionMethods.Load(htmlLines);
        //        case "TimeMania":
        //            return TimeManiaExtensionMethods.Load(htmlLines);
        //        case "Quina":
        //            return QuinaExtensionMethods.Load(htmlLines);
        //        case "LotoMania":
        //            return LotoManiaExtensionMethods.Load(htmlLines);
        //        case "LotoGol":
        //            return LotoGolExtensionMethods.Load(htmlLines);
        //        case "LotoFacil":
        //            return LotoFacilExtensionMethods.Load(htmlLines);
        //        case "Loteca":
        //            return LotecaExtensionMethods.Load(htmlLines);
        //        case "MegaSena":
        //            return MegaSenaExtensionMethods.Load(htmlLines);
        //        default:
        //            _logger.LogError($"Error when try to load lottery {lotteryName}.");
        //            throw new NotSupportedException($"Lottery {lotteryName} did not support.");
        //    }
        //}

        public LotteryData Load(List<List<string>> htmlLines, LotteryData lotteryData)
        {
            try
            {
                Type type = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(method => method.Name.Equals($"{lotteryData.Name}ExtensionMethods"));

                if (type is null) throw new Exception();

                object[] args = { htmlLines };

                IEnumerable<MongoModel> values = ((IEnumerable<MongoModel>)type.GetMethod("Load", BindingFlags.Static | BindingFlags.Public)
                         .Invoke(null, args));

                lotteryData.Entries = values.ToList();

                return lotteryData;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when Load lottery: {lotteryData.Name}. Message: {e.Message} - StackTrace: {e.StackTrace}.");
                throw;
            }
        }
    }
}
