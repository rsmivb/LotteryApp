using Lottery.Models;
using Lottery.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Service.Tests.Lotteries
{
    [TestClass]
    public class DuplaSenaServiceTest
    {
        private readonly Mock<IRepository<DuplaSena>> _mockServiceRepo;
        private readonly List<DuplaSena> _listToLoad;

        public DuplaSenaServiceTest()
        {
            _mockServiceRepo = new Mock<IRepository<DuplaSena>>();
            _listToLoad = new List<DuplaSena>
            {
                new DuplaSena
                {
                    LotteryId = 1,
                    DateRealized = new DateTime(2001,11,06,03,00,00),
                    DozensRound1 = new List<int>{7,15,24,41,48,50 },
                    TotalAmount = 0,
                    Winners6NumbersRound1 = 0,
                    City = "",
                    UF = "",
                    Average6NumbersRound1 = 0,
                    IsAccumulated = true,
                    AccumulatedValueRound1 = 588519.68m,
                    Winners5NumbersRound1 = 0,
                    Average5NumbersRound1 = 0,
                    Winners4NumbersRound1 = 0,
                    Average4NumbersRound1 = 0,
                    Winners3NumbersRound1 = 0,
                    Average3NumbersRound1 = 0,
                    DozensRound2 = new List<int>{9,37,41,43,44,49},
                    Winners6NumbersRound2 = 0,
                    Average6NumbersRound2 = 0,
                    Winners5NumbersRound2 = 55,
                    Average5NumbersRound2 = 2317.59m,
                    Winners4NumbersRound2 = 1307,
                    Average4NumbersRound2 = 97.16m,
                    Winners3NumbersRound2 = 0,
                    Average3NumbersRound2 = 0,
                    EstimatedPrize = 0,
                    AccumulatedEspecialPascoa = 0
                },
                new DuplaSena
                {
                    LotteryId = 2,
                    DateRealized = new DateTime(2001,11,09,02,00,00),
                    DozensRound1 = new List<int>{4, 9, 15, 32, 38, 42 },
                    TotalAmount = 0,
                    Winners6NumbersRound1 = 0,
                    City = "",
                    UF = "",
                    Average6NumbersRound1 = 0,
                    IsAccumulated = true,
                    AccumulatedValueRound1 = 867336.46m,
                    Winners5NumbersRound1 = 0,
                    Average5NumbersRound1 = 0,
                    Winners4NumbersRound1 = 0,
                    Average4NumbersRound1 = 0,
                    Winners3NumbersRound1 = 0,
                    Average3NumbersRound1 = 0,
                    DozensRound2 = new List<int>{9, 13, 19, 24, 29, 46 },
                    Winners6NumbersRound2 = 0,
                    Average6NumbersRound2 = 0,
                    Winners5NumbersRound2 = 35,
                    Average5NumbersRound2 = 2655.4m,
                    Winners4NumbersRound2 = 2014,
                    Average4NumbersRound2 = 45.98m,
                    Winners3NumbersRound2 = 0,
                    Average3NumbersRound2 = 0,
                    EstimatedPrize = 0,
                    AccumulatedEspecialPascoa = 0
            }
            };
        }
        [TestMethod]
        public void LoadDuplaSenaLotteryData()
        {
            var expectedResult = new LotteryData
            {
                LotteryName = "DuplaSena",
                AverageWinnersData = new List<AverageData>
                                    {
                                        new AverageData
                                        {
                                            TypeOfAward = "Average3NumbersRound1",
                                            TotalPeopleWhoWon = 0,
                                            AwardAverage = 0m
                                        },
                                        new AverageData
                                        {
                                            TypeOfAward = "Average4NumbersRound1",
                                            TotalPeopleWhoWon = 0,
                                            AwardAverage = 0m
                                        },
                                        new AverageData
                                        {
                                            TypeOfAward = "Average5NumbersRound1",
                                            TotalPeopleWhoWon = 0,
                                            AwardAverage = 0m
                                        },
                                        new AverageData
                                        {
                                            TypeOfAward = "Average6NumbersRound1",
                                            TotalPeopleWhoWon = 0,
                                            AwardAverage = 0m
                                        }
                                    },
                AwardData = new ArwardsData
                            {
                                TotalAward = 0m,
                                TotalLotteries = 2
                            },
                DozenByQuantity = new List<DozenData>
                                {
                                    new DozenData
                                    {
                                        Dozen = 4,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 7,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 9,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 15,
                                        SumOf = 2
                                    },
                                    new DozenData
                                    {
                                        Dozen = 24,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 32,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 38,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 41,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 42,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 48,
                                        SumOf = 1
                                    },
                                    new DozenData
                                    {
                                        Dozen = 50,
                                        SumOf = 1
                                    }
                                }
            };

            _mockServiceRepo.SetReturnsDefault<IEnumerable<DuplaSena>>(_listToLoad);
            var duplaSenaService = new DuplaSenaService(_mockServiceRepo.Object);
            LotteryData actualResult = duplaSenaService.LoadResultsFor();
            Assert.AreEqual(expectedResult.ToString(), actualResult.ToString());

        }
    }

    internal class DuplaSenaService
    {
        private readonly IRepository<DuplaSena> _serviceRepo;

        public DuplaSenaService(IRepository<DuplaSena> serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        internal LotteryData LoadResultsFor()
        {
            var results = _serviceRepo.GetAll().ToList();
            var DozenByQuantity = results.SelectMany(lottery => lottery.DozensRound1) //select all list of dozens
                                         .GroupBy(dozens => dozens) // group into a new list
                                         .Select(s => new { Dozen = s.Key, Quantity = s.Count() }) // runs each number and count it
                                         .OrderBy(o => o.Dozen).Select(l => new DozenData { Dozen = l.Dozen, SumOf = l.Quantity }).ToList();
            var sumAllPrizes = results.Sum(l => (l.Average3NumbersRound1 + l.Average4NumbersRound1 +
                                      l.Average5NumbersRound1 + l.Average6NumbersRound1));
            var awardsData = new ArwardsData
                {
                    TotalAward = sumAllPrizes,
                    TotalLotteries = results.Count
                };
            var totalPeople3WhoWon = results.Sum(l => l.Winners3NumbersRound1);
            var totalPeople4WhoWon = results.Sum(l => l.Winners4NumbersRound1);
            var totalPeople5WhoWon = results.Sum(l => l.Winners5NumbersRound1);
            var totalPeople6WhoWon = results.Sum(l => l.Winners6NumbersRound1);
            var award3Average = (totalPeople3WhoWon == 0) ? 0 : results.Sum(l => l.Average3NumbersRound1) / totalPeople3WhoWon;
            var award4Average = (totalPeople4WhoWon == 0) ? 0 : results.Sum(l => l.Average4NumbersRound1) / totalPeople4WhoWon;
            var award5Average = (totalPeople5WhoWon == 0) ? 0 : results.Sum(l => l.Average5NumbersRound1) / totalPeople5WhoWon;
            var award6Average = (totalPeople6WhoWon == 0) ? 0 : results.Sum(l => l.Average6NumbersRound1) / totalPeople6WhoWon;

            return new LotteryData
            {
                LotteryName = Constants.DuplaSena,
                AverageWinnersData = new List<AverageData>
                    {
                        new AverageData
                        {
                            TypeOfAward = "Average3NumbersRound1",
                            TotalPeopleWhoWon = totalPeople3WhoWon,
                            AwardAverage = award3Average
                        },
                        new AverageData
                        {
                            TypeOfAward = "Average4NumbersRound1",
                            TotalPeopleWhoWon = totalPeople4WhoWon,
                            AwardAverage = award4Average
                        },
                        new AverageData
                        {
                            TypeOfAward = "Average5NumbersRound1",
                            TotalPeopleWhoWon = totalPeople5WhoWon,
                            AwardAverage = award5Average
                        },
                        new AverageData
                        {
                            TypeOfAward = "Average6NumbersRound1",
                            TotalPeopleWhoWon = totalPeople6WhoWon,
                            AwardAverage = award6Average
                        }
                    },
                AwardData = awardsData,
                DozenByQuantity = DozenByQuantity
            };
        }
    }
}
