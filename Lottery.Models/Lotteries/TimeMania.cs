﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class TimeMania : MongoModel
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] Dozens { get; set; }
        public string Team { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalWinners7 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int TotalWinners6 { get; set; }
        public int TotalWinners5 { get; set; }
        public int TotalWinners4 { get; set; }
        public int TotalWinners3 { get; set; }
        public int WinnersTeam { get; set; }
        public decimal TotalValueNumbers7 { get; set; }
        public decimal TotalValueNumbers6 { get; set; }
        public decimal TotalValueNumbers5 { get; set; }
        public decimal TotalValueNumbers4 { get; set; }
        public decimal TotalValueNumbers3 { get; set; }
        public decimal TeamValue { get; set; }
        public decimal AccumulatedValue { get; set; }
        public decimal EstimatedPrize { get; set; }
    }
    public static class TimeManiaExtensionMethods
    {
        public static IEnumerable<TimeMania> Load(IList<IList<string>> items)
        {
            foreach (var item in items)
            {
                yield return new TimeMania
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new int[] { item[2].ConvertToInt(), item[3].ConvertToInt(),
                                     item[4].ConvertToInt(), item[5].ConvertToInt(),
                                     item[6].ConvertToInt(), item[7].ConvertToInt(),
                                     item[8].ConvertToInt()}.OrderBy(c => c).ToArray(),
                    Team = item[9].ConvertEmptyToString(),
                    TotalValue = item[10].ConvertToDecimal(),
                    TotalWinners7 = item[11].ConvertToInt(),
                    City = item[12].ConvertEmptyToString(),
                    UF = item[13].ConvertEmptyToString(),
                    TotalWinners6 = item[14].ConvertToInt(),
                    TotalWinners5 = item[15].ConvertToInt(),
                    TotalWinners4 = item[16].ConvertToInt(),
                    TotalWinners3 = item[17].ConvertToInt(),
                    WinnersTeam = item[18].ConvertToInt(),
                    TotalValueNumbers7 = item[19].ConvertToDecimal(),
                    TotalValueNumbers6 = item[20].ConvertToDecimal(),
                    TotalValueNumbers5 = item[21].ConvertToDecimal(),
                    TotalValueNumbers4 = item[22].ConvertToDecimal(),
                    TotalValueNumbers3 = item[23].ConvertToDecimal(),
                    TeamValue = item[24].ConvertToDecimal(),
                    AccumulatedValue = item[25].ConvertToDecimal(),
                    EstimatedPrize = item[26].ConvertToDecimal()
                };
            }
        }
    }
}
