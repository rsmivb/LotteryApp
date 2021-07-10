using Lottery.Models;
using Lottery.Repository;
using Lottery.Services.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services
{
    public class HandlerLotteryService : IHandlerLotteryService
    {
        private readonly ILogger<IHandlerLotteryService> _logger;

        public HandlerLotteryService(ILogger<IHandlerLotteryService> logger)
        {
            _logger = logger;
        }
        public void FindAndInsert(List<List<string>> htmlLines, string lotteryName)
        {
            switch (lotteryName)
            {
                case "DuplaSena":
                    DuplaSenaExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "Federal":
                    FederalExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "TimeMania":
                    TimeManiaExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "Quina":
                    QuinaExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "LotoMania":
                    LotoManiaExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "LotoGol":
                    LotoGolExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "LotoFacil":
                    LotoFacilExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "Loteca":
                    LotecaExtensionMethods.Load(htmlLines).ToList();
                    break;
                case "MegaSena":
                    MegaSenaExtensionMethods.Load(htmlLines).ToList();
                    break;
                default:
                    throw new NotSupportedException($"Lottery {lotteryName} did not support.");
            }
        }
    }

    public interface IHandlerLotteryService
    {
    }
}
