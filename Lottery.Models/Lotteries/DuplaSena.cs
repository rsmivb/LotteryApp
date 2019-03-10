using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class DuplaSena : MongoObject
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] DozensRound1 { get; set; }
        public decimal TotalAmount { get; set; }
        public int Winners6NumbersRound1 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public decimal Average6NumbersRound1 { get; set; }
        public bool IsAccumulated { get; set; }
        public decimal AccumulatedValueRound1 { get; set; }
        public int Winners5NumbersRound1 { get; set; }
        public decimal Average5NumbersRound1 { get; set; }
        public int Winners4NumbersRound1 { get; set; }
        public decimal Average4NumbersRound1 { get; set; }
        public int Winners3NumbersRound1 { get; set; }
        public decimal Average3NumbersRound1 { get; set; }
        public int[] DozensRound2 { get; set; }
        public int Winners6NumbersRound2 { get; set; }
        public decimal Average6NumbersRound2 { get; set; }
        public int Winners5NumbersRound2 { get; set; }
        public decimal Average5NumbersRound2 { get; set; }
        public int Winners4NumbersRound2 { get; set; }
        public decimal Average4NumbersRound2 { get; set; }
        public int Winners3NumbersRound2 { get; set; }
        public decimal Average3NumbersRound2 { get; set; }
        public decimal EstimatedPrize { get; set; }
        public decimal AccumulatedEspecialPascoa { get; set; }
    }

    public static class DuplaSenaExtensionMethods
    {
        public static DuplaSena Load(IEnumerable<string> nodes) => new DuplaSena
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                DozensRound1 = new int[] { nodes[2].ConvertToInt(), nodes[3].ConvertToInt(),
                                           nodes[4].ConvertToInt(), nodes[5].ConvertToInt(),
                                           nodes[6].ConvertToInt(), nodes[7].ConvertToInt() },
                TotalAmount = nodes[8].ConvertToDecimal(),
                Winners6NumbersRound1 = nodes[9].ConvertToInt(),
                City = nodes[10].ConvertEmptyToString(),
                UF = nodes[11].ConvertWithMetaChatToString(),
                Average6NumbersRound1 = nodes[12].ConvertToDecimal(),
                IsAccumulated = nodes[13].ConvertToBoolean(),
                AccumulatedValueRound1 = nodes[14].ConvertToDecimal(),
                Winners5NumbersRound1 = nodes[15].ConvertToInt(),
                Average5NumbersRound1 = nodes[16].ConvertToDecimal(),
                Winners4NumbersRound1 = nodes[17].ConvertToInt(),
                Average4NumbersRound1 = nodes[18].ConvertToDecimal(),
                Winners3NumbersRound1 = nodes[19].ConvertToInt(),
                Average3NumbersRound1 = nodes[20].ConvertToDecimal(),

                DozensRound2 = new int[] { nodes[21].ConvertToInt(), nodes[22].ConvertToInt(),
                                           nodes[23].ConvertToInt(), nodes[24].ConvertToInt(),
                                           nodes[25].ConvertToInt(), nodes[26].ConvertToInt() },
                Winners6NumbersRound2 = nodes[27].ConvertToInt(),
                Average6NumbersRound2 = nodes[28].ConvertToDecimal(),
                Winners5NumbersRound2 = nodes[29].ConvertToInt(),
                Average5NumbersRound2 = nodes[30].ConvertToDecimal(),
                Winners4NumbersRound2 = nodes[31].ConvertToInt(),
                Average4NumbersRound2 = nodes[32].ConvertToDecimal(),
                Winners3NumbersRound2 = nodes[33].ConvertToInt(),
                Average3NumbersRound2 = nodes[34].ConvertToDecimal(),

                EstimatedPrize = nodes[35].ConvertToDecimal(),
                AccumulatedEspecialPascoa = nodes[36].ConvertToDecimal()
            };
    }
}