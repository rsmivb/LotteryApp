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
