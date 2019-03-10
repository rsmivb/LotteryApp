using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class TimeMania : MongoObject
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
        public static TimeMania LoadTImemMania(this IList<string> nodes) => new TimeMania
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Dozens = new int[] { nodes[2].ConvertToInt(), nodes[3].ConvertToInt(),
                                     nodes[4].ConvertToInt(), nodes[5].ConvertToInt(),
                                     nodes[6].ConvertToInt(), nodes[7].ConvertToInt(),
                                     nodes[8].ConvertToInt()},
                Team = nodes[9].ConvertEmptyToString(),
                TotalValue = nodes[10].ConvertToDecimal(),
                TotalWinners7 = nodes[11].ConvertToInt(),
                City = nodes[12].ConvertEmptyToString(),
                UF = nodes[13].ConvertEmptyToString(),
                TotalWinners6 = nodes[14].ConvertToInt(),
                TotalWinners5 = nodes[15].ConvertToInt(),
                TotalWinners4 = nodes[16].ConvertToInt(),
                TotalWinners3 = nodes[17].ConvertToInt(),
                WinnersTeam = nodes[18].ConvertToInt(),
                TotalValueNumbers7 = nodes[19].ConvertToDecimal(),
                TotalValueNumbers6 = nodes[20].ConvertToDecimal(),
                TotalValueNumbers5 = nodes[21].ConvertToDecimal(),
                TotalValueNumbers4 = nodes[22].ConvertToDecimal(),
                TotalValueNumbers3 = nodes[23].ConvertToDecimal(),
                TeamValue = nodes[24].ConvertToDecimal(),
                AccumulatedValue = nodes[25].ConvertToDecimal(),
                EstimatedPrize = nodes[26].ConvertToDecimal()
            };
    }
}
