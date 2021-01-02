//using Lottery.Models;
//using Lottery.Repository;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Lottery.Services
//{
//    public class HandlerLotteryService : IHandlerLotteryService
//    {
//        private readonly ILogger<IHandlerLotteryService> _logger;
//        private readonly MongoContext _context;

//        public HandlerLotteryService(ILogger<IHandlerLotteryService> logger,
//            MongoContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }
//        public void FindAndInsert(List<List<string>> htmlLines, string lotteryName)
//        {
//            switch (lotteryName)
//            {
//                case "DuplaSena":
//                    _context.DuplaSenaRepository.InsertMany(DuplaSenaExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "Federal":
//                    _context.FederalRepository.InsertMany(FederalExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "TimeMania":
//                    _context.TimeManiaRepository.InsertMany(TimeManiaExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "Quina":
//                    _context.QuinaRepository.InsertMany(QuinaExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "LotoMania":
//                    _context.LotoManiaRepository.InsertMany(LotoManiaExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "LotoGol":
//                    _context.LotoGolRepository.InsertMany(LotoGolExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "LotoFacil":
//                    _context.LotoFacilRepository.InsertMany(LotoFacilExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "Loteca":
//                    _context.LotecaRepository.InsertMany(LotecaExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                case "MegaSena":
//                    _context.MegaSenaRepository.InsertMany(MegaSenaExtensionMethods.Load(htmlLines).ToList());
//                    break;
//                default:
//                    throw new NotSupportedException($"Lottery {lotteryName} did not support.");
//            }
//        }
//    }
//}
