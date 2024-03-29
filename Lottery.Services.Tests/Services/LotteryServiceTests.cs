﻿using Lottery.Models;
using Lottery.Models.Lotteries;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services.Tests
{
    [TestClass]
    public class LotteryServiceTests
    {
        private readonly Mock<ILogger<ILotteryService>> _logger;
        private readonly ILotteryService _service;

        public LotteryServiceTests()
        {
            _logger = new Mock<ILogger<ILotteryService>>();
            _service = new LotteryService(_logger.Object);
        }

        [TestMethod("Create List of MegaSena objects")]
        [TestCategory("LotteryService")]
        //https://stackoverflow.com/questions/30888325/cannot-convert-type-via-a-reference-conversion-boxing-conversion-unboxing-conv
        public void CreateListOfMegaSenaObjectsTest()
        {
            var megaSenaList = new List<MegaSena>
                {
                    new MegaSena
                    {
                        LotteryId = 1,
                        City = "BRASÍLIA, DF",
                        DateRealized = new DateTime(1996,3,11),
                        Dozens = new List<int> { 4, 5, 30, 33, 41, 52 },
                        WinnersSena = 0,
                        WinnersQuina = 17,
                        WinnersQuadra = 2016,
                        WinnersSenaValue = 0.00M,
                        WinnersQuinaValue = 39158.92M,
                        WinnersQuadraValues = 330.21M
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "MegaSena",
                Columns = 15,
                HtmlFilePath = string.Empty,
                CaixaLotteryURL = "http://www.url.com"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "MegaSena",
                Columns = 15,
                HtmlFilePath = string.Empty,
                CaixaLotteryURL = "http://www.url.com",
                Entries = megaSenaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new()
            {
                    new List<string>
                    {
                        "1",
                        "Brasília, DF",
                        "11/03/1996",
                        "004",
                        "005",
                        "030",
                        "033",
                        "041",
                        "052",
                        "0",
                        "17",
                        "2016",
                        "0,00",
                        "39.158,92",
                        "330,21",
                        "0,00",
                        "0,00",
                        "0,00",
                        "SIM",
                        "SIM",
                        "&nbsp"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }

        [TestMethod("Create List of DuplaSena objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfDuplaSenaObjectsTest()
        {
            var duplaSenaList = new List<DuplaSena>
                {
                    new DuplaSena
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 1999,
                        DateRealized = new DateTime(2021,4,27),
                        DozensRound1 = new List<int>{ 1, 2, 4, 6, 8, 11 },
                        TotalAmount = 150_041.21M,
                        Winners6NumbersRound1 = 0,
                        City = "",
                        UF = "",
                        Average6NumbersRound1 = 0.00M,
                        IsAccumulated = true,
                        AccumulatedValueRound1 = 594.81M,
                        Winners5NumbersRound1 = 38,
                        Average5NumbersRound1 = 1106.43M,
                        Winners4NumbersRound1 = 22,
                        Average4NumbersRound1 = 11.10M,
                        Winners3NumbersRound1 = 33,
                        Average3NumbersRound1 = 9.90M,
                        DozensRound2 = new List<int>{ 4, 7, 25, 41, 56, 57 },
                        Winners6NumbersRound2 = 0,
                        Average6NumbersRound2 = 0.00M,
                        Winners5NumbersRound2 = 12,
                        Average5NumbersRound2 = 1200.01M,
                        Winners4NumbersRound2 = 123,
                        Average4NumbersRound2 = 129001.99M,
                        Winners3NumbersRound2 = 1234,
                        Average3NumbersRound2 = 234543.01M,
                        EstimatedPrize = 12120120.98M,
                        AccumulatedEspecialPascoa = 1000000.00M
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "DuplaSena",
                Columns = 12,
                HtmlFilePath = string.Empty,
                CaixaLotteryURL = "http://www.url.com"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "DuplaSena",
                Columns = 12,
                HtmlFilePath = string.Empty,
                CaixaLotteryURL = "http://www.url.com",
                Entries = duplaSenaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "1999",
                        "27/04/2021",
                        "1",
                        "2",
                        "6",
                        "8",
                        "4",
                        "11",
                        "150.041,21",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "SIM",
                        "594,81",
                        "38",
                        "1106,43",
                        "22",
                        "11,10",
                        "33",
                        "9,90",
                        "4",
                        "25",
                        "56",
                        "57",
                        "41",
                        "7",
                        "0",
                        "0,00",
                        "12",
                        "1200,01",
                        "123",
                        "129.001,99",
                        "1234",
                        "234.543,01",
                        "12.120.120,98",
                        "1.000.000,00"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of Federal objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfFederalObjectsTest()
        {
            //TBD
            var federalList = new List<Federal>
                {
                    new Federal
                    {
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        Dozens = new List<int>(),
                        Prize1 = 0,
                        Prize2 = 0,
                        Prize3 = 0,
                        Prize4 = 0,
                        Prize5 = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "Federal"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "Federal",
                Entries = federalList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of Loteca objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfLotecaObjectsTest()
        {
            //TBD
            var lotecaList = new List<Loteca>
                {
                    new Loteca
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        Winners14 = 0,
                        City = "",
                        UF = "",
                        Average14 = 0,
                        IsAcumulated = true,
                        AmountValue14 = 0,
                        Winners13 = 0,
                        AmountValue13 = 0,
                        Winners12 = 0,
                        AmountValue12 = 0,
                        Dozens = new List<string>(),
                        TotalAmount = 0,
                        EstimatedPrize = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "Loteca"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "Loteca",
                Entries = lotecaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of LotoFacil objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfLotoFacilObjectsTest()
        {
            //TBD
            var lotoFacilList = new List<LotoFacil>
                {
                    new LotoFacil
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        Dozens = new List<int>(),
                        TotalAmount = 0,
                        Winners15 = 0,
                        City = "",
                        UF = "",
                        Winners14 = 0,
                        Winners13 = 0,
                        Winners12 = 0,
                        Winners11 = 0,
                        AverageAmount15 = 0,
                        AverageAmount14 = 0,
                        AverageAmount13 = 0,
                        AverageAmount12 = 0,
                        AverageAmount11 = 0,
                        Accumulated15 = 0,
                        EstimatedPrize = 0,
                        SpecialAmount = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "LotoFacil"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "LotoFacil",
                Entries = lotoFacilList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of LotoGol objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfLotoGolObjectsTest()
        {
            //TBD
            var lotoGolList = new List<LotoGol>
                {
                    new LotoGol
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        City = "",
                        UF = "",
                        Winners5 = 0,
                        Average5 = 0,
                        IsAcumlated5 = true,
                        Acumulated5 = 0,
                        Winners4 = 0,
                        Average4 = 0,
                        IsAcumlated4 = true,
                        Acumulated4 = 0,
                        Winners3 = 0,
                        Average3 = 0,
                        IsAcumlated3 = true,
                        Acumulated3 = 0,
                        Dozens = new List<string>(),
                        TotalAmount = 0,
                        EstimatedPrize = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "LotoGol"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "LotoGol",
                Entries = lotoGolList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of LotoMania objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfLotoManiaObjectsTest()
        {
            //TBD
            var lotoManiaList = new List<LotoMania>
                {
                    new LotoMania
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        Dozens = new List<int>(),
                        TotalValue = 0,
                        TotalWinners20 = 0,
                        City = "",
                        UF = "",
                        TotalWinners19 = 0,
                        TotalWinners18 = 0,
                        TotalWinners17 = 0,
                        TotalWinners16 = 0,
                        TotalWinnersNoNumbers = 0,
                        TotalValueNumbers20 = 0,
                        TotalValueNumbers19 = 0,
                        TotalValueNumbers18 = 0,
                        TotalValueNumbers17 = 0,
                        TotalValueNumbers16 = 0,
                        TotalValueNoNumbers = 0,
                        Acumulated20 = 0,
                        Acumulated19 = 0,
                        Acumulated18 = 0,
                        Acumulated17 = 0,
                        Acumulated16 = 0,
                        AcumulatedNoNumbers = 0,
                        PrizeEstimated = 0,
                        SpecialPrizeEstimated = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "LotoMania"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "LotoMania",
                Entries = lotoManiaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of Quina objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfQuinaObjectsTest()
        {
            //TBD
            var quinaList = new List<Quina>
                {
                    new Quina
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        Dozens = new List<int>(),
                        TotalAmount = 0,
                        Winners5 = 0,
                        City = "",
                        UF = "",
                        Average5Numbers = 0,
                        Winners4 = 0,
                        Average4Numbers = 0,
                        Winners3 = 0,
                        Average3Numbers = 0,
                        Winners2 = 0,
                        Average2Numbers = 0,
                        IsAccumulated = true,
                        AccumulatedValue = 0,
                        EstimatePrize = 0,
                        AccumulatedSorteioSaoJoao = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "Quina"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "Quina",
                Entries = quinaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }
        [Ignore]
        [TestMethod("Create List of TimeMania objects")]
        [TestCategory("LotteryService")]
        public void CreateListOfTimeManiaObjectsTest()
        {
            //TBD
            var timeManiaList = new List<TimeMania>
                {
                    new TimeMania
                    {
                        _id = "000000000000000000000000",
                        LotteryId = 0,
                        DateRealized = new DateTime(),
                        Dozens = new List<int>(),
                        Team = "",
                        TotalValue = 0,
                        TotalWinners7 = 0,
                        City = "",
                        UF = "",
                        TotalWinners6 = 0,
                        TotalWinners5 = 0,
                        TotalWinners4 = 0,
                        TotalWinners3 = 0,
                        WinnersTeam = 0,
                        TotalValueNumbers7 = 0,
                        TotalValueNumbers6 = 0,
                        TotalValueNumbers5 = 0,
                        TotalValueNumbers4 = 0,
                        TotalValueNumbers3 = 0,
                        TeamValue = 0,
                        AccumulatedValue = 0,
                        EstimatedPrize = 0
                    }
                };
            var lotteryData = new LotteryData
            {
                Name = "TimeMania"
            };
            var expectedLotteryData = new LotteryData
            {
                Name = "TimeMania",
                Entries = timeManiaList.Cast<MongoModel>().ToList()
            };
            List<List<string>> htmlList = new List<List<string>>
                {
                    new List<string>
                    {
                        "2146",
                        "27/04/2019",
                        "39",
                        "42",
                        "16",
                        "18",
                        "44",
                        "31",
                        "150.176.040,00",
                        "0",
                        "&nbsp",
                        "&nbsp",
                        "0,00",
                        "283",
                        "30.594,81",
                        "15338",
                        "806,43",
                        "SIM",
                        "107.627.872,22",
                        "125.000.000,00",
                        "26.248.210,83"
                    }
                };

            var result = _service.Load(htmlList, lotteryData);

            CollectionAssert.AreEqual(expectedLotteryData.Entries, result.Entries);

            Assert.AreEqual(expectedLotteryData, result);
        }

    }
}
