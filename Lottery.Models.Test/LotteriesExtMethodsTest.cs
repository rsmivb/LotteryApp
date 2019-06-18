using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models.Test
{
    [TestClass]
    public class LotteriesExtMethodsTest
    {
        [TestMethod]
        public void ExtensioMethod_DuplaSena_Test()
        {
            var listOfValuesDuplaSena = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                "06/11/2001",
                "41",
                "48",
                "15",
                "07",
                "24",
                "50",
                "0,00",
                "0",
                "&nbsp",
                "&nbsp",
                "0,00",
                "SIM",
                "588.519,68",
                "0",
                "0,00",
                "0",
                "0,00",
                "0",
                "0,00",
                "43",
                "37",
                "41",
                "49",
                "44",
                "09",
                "0",
                "0,00",
                "55",
                "2.317,59",
                "1307",
                "97,16",
                "0",
                "0,00",
                "0,00",
                "0,00"
                }
            };
            var expectedDuplaSena = new List<DuplaSena>
            {
                new DuplaSena
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2001, 11, 06),
                    DozensRound1 = new List<int> { 07, 15, 24, 41, 48, 50 }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    Winners6NumbersRound1 = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    Average6NumbersRound1 = 0.00m,
                    IsAccumulated = true,
                    AccumulatedValueRound1 = 588519.68m,
                    Winners5NumbersRound1 = 0,
                    Average5NumbersRound1 = 0.00m,
                    Winners4NumbersRound1 = 0,
                    Average4NumbersRound1 = 0.00m,
                    Winners3NumbersRound1 = 0,
                    Average3NumbersRound1 = 0.00m,
                    DozensRound2 = new List<int> { 09, 37, 41, 43, 44, 49 }.OrderBy(c => c).ToList(),
                    Winners6NumbersRound2 = 0,
                    Average6NumbersRound2 = 0.00m,
                    Winners5NumbersRound2 = 55,
                    Average5NumbersRound2 = 2317.59m,
                    Winners4NumbersRound2 = 1307,
                    Average4NumbersRound2 = 97.16m,
                    Winners3NumbersRound2 = 0,
                    Average3NumbersRound2 = 0.00m,
                    EstimatedPrize = 0.00m,
                    AccumulatedEspecialPascoa = 0.00m
                }
            };
            var actualResult = DuplaSenaExtensionMethods.Load(listOfValuesDuplaSena).ToList();

            Assert.AreEqual(expectedDuplaSena.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedDuplaSena, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_Federal_Test()
        {
            var listOfValuesFederal = new List<List<string>>
            {
                new List<string>{"00001","15/09/1962","05349","38031","26492","25151","01416","200.000,00","8.000,00","5.000,00","4.000,00","2.000,00" }
            };
            var expectedFederal = new List<Federal>{
                new Federal
                {
                    LotteryId = 00001,
                    DateRealized = new DateTime(1962, 09, 15),
                    Dozens = new List<int> { 05349, 38031, 26492, 25151, 01416 }.OrderBy(c => c).ToList(),
                    Prize1 = 200000.00m,
                    Prize2 = 8000.00m,
                    Prize3 = 5000.00m,
                    Prize4 = 4000.00m,
                    Prize5 = 2000.00m
                }
            };
            var actualResult = FederalExtensionMethods.Load(listOfValuesFederal).ToList();

            Assert.AreEqual(expectedFederal.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedFederal, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_Loteca_Test()
        {
            var listOfValuesLoteca = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "18/02/2002",
                    "2",
                    "",
                    "BA",
                    "55.985,99",
                    "NÃO",
                    "0,00",
                    "44",
                    "2.544,81",
                    "1028",
                    "144,68",
                    "2",
                    "1",
                    "1",
                    "2",
                    "1",
                    "2",
                    "x",
                    "1",
                    "x",
                    "1",
                    "1",
                    "2",
                    "1",
                    "1",
                    " - ",
                    " - "
                }
            };
            var expectedLoteca = new List<Loteca>
            {
                new Loteca
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2002, 02, 18),
                    Winners14 = 2,
                    City = string.Empty,
                    UF = "BA",
                    Average14 = 55985.99m,
                    IsAcumulated = false,
                    AmountValue14 = 0.00m,
                    Winners13 = 44,
                    AmountValue13 = 2544.81m,
                    Winners12 = 1028,
                    AmountValue12 = 144.68m,
                    Dozens = new List<string> { "2", "1", "1", "2", "1", "2", "x", "1", "x", "1", "1", "2", "1", "1" }.OrderBy(c => c).ToList(),
                    TotalAmount = 0,
                    EstimatedPrize = 0
                }
            };
            var actualResult = LotecaExtensionMethods.Load(listOfValuesLoteca).ToList();

            Assert.AreEqual(expectedLoteca.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedLoteca, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_LotoFacil_Test()
        {
            var listOfValuesLotoFacil = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "29/09/2003",
                    "18",
                    "20",
                    "25",
                    "23",
                    "10",
                    "11",
                    "24",
                    "14",
                    "06",
                    "02",
                    "13",
                    "09",
                    "05",
                    "16",
                    "03",
                    "0,00",
                    "5",
                    "",
                    "BA",
                    "154",
                    "4645",
                    "48807",
                    "257593",
                    "49.765,82",
                    "689,84",
                    "10,00",
                    "4,00",
                    "2,00",
                    "0,00",
                    "0,00",
                    "0,00"
                }
            };
            var expectedLotoFacil = new List<LotoFacil>
            {
                new LotoFacil
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2003, 09, 29),
                    Dozens = new List<int> { 18, 20, 25, 23, 10, 11, 24, 14, 06, 02, 13, 09, 05, 16, 03 }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    Winners15 = 5,
                    City = string.Empty,
                    UF = "BA",
                    Winners14 = 154,
                    Winners13 = 4645,
                    Winners12 = 48807,
                    Winners11 = 257593,
                    AverageAmount15 = 49765.82m,
                    AverageAmount14 = 689.84m,
                    AverageAmount13 = 10.00m,
                    AverageAmount12 = 4.00m,
                    AverageAmount11 = 2.00m,
                    Accumulated15 = 0.00m,
                    EstimatedPrize = 0.00m,
                    SpecialAmount = 0.00m
                }
            };

            var actualResult = LotoFacilExtensionMethods.Load(listOfValuesLotoFacil).ToList();

            Assert.AreEqual(expectedLotoFacil.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedLotoFacil, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_LotoGol_Test()
        {
            var listOfValuesLotoGol = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "18/02/2002",
                    "&nbsp",
                    "&nbsp",
                    "0",
                    "0,00",
                    "SIM",
                    "425.061,45",
                    "3",
                    "3.278,78",
                    "NÃO",
                    "0,00",
                    "481",
                    "20,38",
                    "NÃO",
                    "0,00",
                    "2",
                    "+",
                    "3",
                    "0",
                    "2",
                    "1",
                    "1",
                    "+",
                    "+",
                    "0",
                    "0,00",
                    "0,00"
                }
            };
            var expectedLotoGol = new List<LotoGol>
            {
                new LotoGol
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2002, 02, 18),
                    City = "",
                    UF = "",
                    Winners5 = 0,
                    Average5 = 0.00m,
                    IsAcumlated5 = true,
                    Acumulated5 = 425061.45m,
                    Winners4 = 3,
                    Average4 = 3278.78m,
                    IsAcumlated4 = false,
                    Acumulated4 = 0.00m,
                    Winners3 = 481,
                    Average3 = 20.38m,
                    IsAcumlated3 = false,
                    Acumulated3 = 0.00m,
                    Dozens = new List<string> { "2", "+", "3", "0", "2", "1", "1", "+", "+", "0" }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    EstimatedPrize = 0.00m
                }
            };
            var actualResult = LotoGolExtensionMethods.Load(listOfValuesLotoGol).ToList();

            Assert.AreEqual(expectedLotoGol.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedLotoGol, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_LotoMania_Test()
        {
            var listOfValuesLotoMania = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "02/10/1999",
                    "16",
                    "11",
                    "88",
                    "32",
                    "25",
                    "00",
                    "70",
                    "78",
                    "73",
                    "61",
                    "90",
                    "89",
                    "46",
                    "95",
                    "06",
                    "33",
                    "34",
                    "21",
                    "14",
                    "22",
                    "0,00",
                    "0",
                    "&nbsp",
                    "&nbsp",
                    "1",
                    "46",
                    "446",
                    "2716",
                    "0",
                    "0,00",
                    "118.746,87",
                    "2.581,46",
                    "132,62",
                    "21,78",
                    "0,00",
                    "178.120,31",
                    "0,00",
                    "0,00",
                    "0,00",
                    "0,00",
                    "59.373,46",
                    "0,00",
                    ""
                }
            };
            var expectedLotoMania = new List<LotoMania>
                {
                    new LotoMania
                    {
                        LotteryId = 1,
                        DateRealized = new DateTime(1999, 10, 02),
                        Dozens = new List<int> { 16, 11, 88, 32, 25, 00, 70, 78, 73, 61, 90, 89, 46, 95, 06, 33, 34, 21, 14, 22 }.OrderBy(c => c).ToList(),
                        TotalValue = 0.00m,
                        TotalWinners20 = 0,
                        City = string.Empty,
                        UF = string.Empty,
                        TotalWinners19 = 1,
                        TotalWinners18 = 46,
                        TotalWinners17 = 446,
                        TotalWinners16 = 2716,
                        TotalWinnersNoNumbers = 0,
                        TotalValueNumbers20 = 0.00m,
                        TotalValueNumbers19 = 118746.87m,
                        TotalValueNumbers18 = 2581.46m,
                        TotalValueNumbers17 = 132.62m,
                        TotalValueNumbers16 = 21.78m,
                        TotalValueNoNumbers = 0.00m,
                        Acumulated20 = 178120.31m,
                        Acumulated19 = 0.00m,
                        Acumulated18 = 0.00m,
                        Acumulated17 = 0.00m,
                        Acumulated16 = 0.00m,
                        AcumulatedNoNumbers = 59373.46m,
                        PrizeEstimated = 0.00m,
                        SpecialPrizeEstimated = 0m
                    }
                };
            var actualResult = LotoManiaExtensionMethods.Load(listOfValuesLotoMania).ToList();

            Assert.AreEqual(expectedLotoMania.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedLotoMania, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_MegaSena_Test()
        {
            var listOfValuesMegaSena = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "11/03/1996",
                    "41",
                    "05",
                    "04",
                    "52",
                    "30",
                    "33",
                    "0,00",
                    "0",
                    "&nbsp",
                    "&nbsp",
                    "0,00",
                    "17",
                    "39.158,92",
                    "2016",
                    "330,21",
                    "SIM",
                    "1.714.650,23",
                    "0,00",
                    "0,00"
                }
            };
            var expectedMegaSena = new List<MegaSena>
            {
                new MegaSena
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(1996, 03, 11),
                    Dozens = new List<int> { 41, 05, 04, 52, 30, 33 }.OrderBy(c => c).ToList(),
                    TotalCollection = 0.00m,
                    Winners6Numbers = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    Average6Numbers = 0.00m,
                    Winners5Numbers = 17,
                    Average5Numbers = 39158.92m,
                    Winners4Numbers = 2016,
                    Average4Numbers = 330.21m,
                    IsAccumulated = true,
                    AccumulatedPrize = 1714650.23m,
                    EstimatedPrize = 0.00m,
                    AccumulatedMegaSenaVirada = 0.00m
                }
            };

            var actualResult = MegaSenaExtensionMethods.Load(listOfValuesMegaSena).ToList();

            Assert.AreEqual(expectedMegaSena.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedMegaSena, actualResult);
        }

        [TestMethod]
        public void ExtensioMethod_Quina_Test()
        {
            var listOfValuesQuina = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "13/03/1994",
                    "25",
                    "45",
                    "60",
                    "76",
                    "79",
                    "0,00",
                    "3",
                    "&nbsp",
                    "&nbsp",
                    "75.731.225,00",
                    "127",
                    "1.788.927,00",
                    "7030",
                    "42.982,00",
                    "0",
                    "0,00",
                    "NÃO",
                    "0,00",
                    "0,00",
                    "0,00"
                }
            };
            var expectedQuina = new List<Quina>
            {
                new Quina
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(1994, 03, 13),
                    Dozens = new List<int> { 25, 45, 60, 76, 79 }.OrderBy(c => c).ToList(),
                    TotalAmount = 0.00m,
                    Winners5 = 3,
                    City = string.Empty,
                    UF = string.Empty,
                    Average5Numbers = 75731225.00m,
                    Winners4 = 127,
                    Average4Numbers = 1788927.00m,
                    Winners3 = 7030,
                    Average3Numbers = 42982.00m,
                    Winners2 = 0,
                    Average2Numbers = 0.00m,
                    IsAccumulated = false,
                    AccumulatedValue = 0.00m,
                    EstimatePrize = 0.00m,
                    AccumulatedSorteioSaoJoao = 0.00m
                }
            };

            var actualResult = QuinaExtensionMethods.Load(listOfValuesQuina).ToList();

            Assert.AreEqual(expectedQuina.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedQuina, actualResult);
        }
        [TestMethod]
        public void ExtensioMethod_TimeMania_Test()
        {
            var listOfValuesTimeMania = new List<List<string>>
            {
                new List<string>
                {
                    "1",
                    "01/03/2008",
                    "71",
                    "51",
                    "63",
                    "57",
                    "24",
                    "80",
                    "31",
                    "PALMAS/TO",
                    "0,00",
                    "0",
                    "&nbsp",
                    "&nbsp",
                    "6",
                    "328",
                    "6032",
                    "60403",
                    "13122",
                    "0,00",
                    "59.909,90",
                    "730,61",
                    "6,00",
                    "2,00",
                    "2,00",
                    "479.279,20",
                    "1.000.000,00"
                }
            };
            var expectedTimeMania = new List<TimeMania>
            {
                new TimeMania
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2008, 03, 01),
                    Dozens = new List<int> { 71, 51, 63, 57, 24, 80, 31 }.OrderBy(c => c).ToList(),
                    Team = "PALMAS/TO",
                    TotalValue = 0.00m,
                    TotalWinners7 = 0,
                    City = string.Empty,
                    UF = string.Empty,
                    TotalWinners6 = 6,
                    TotalWinners5 = 328,
                    TotalWinners4 = 6032,
                    TotalWinners3 = 60403,
                    WinnersTeam = 13122,
                    TotalValueNumbers7 = 0.00m,
                    TotalValueNumbers6 = 59909.90m,
                    TotalValueNumbers5 = 730.61m,
                    TotalValueNumbers4 = 6.00m,
                    TotalValueNumbers3 = 2.00m,
                    TeamValue = 2.00m,
                    AccumulatedValue = 479279.20m,
                    EstimatedPrize = 1000000.00m
                }
            };

            var actualResult = TimeManiaExtensionMethods.Load(listOfValuesTimeMania).ToList();

            Assert.AreEqual(expectedTimeMania.ToString(), actualResult.ToString());
            CollectionAssert.AreEqual(expectedTimeMania, actualResult);
        }
    }
}
