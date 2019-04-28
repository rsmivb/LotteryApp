using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class DuplaSena : MongoModel
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
        public static IEnumerable<DuplaSena> Load(IList<IList<string>> items)
        {
            foreach (var item in items)
            {
                yield return new DuplaSena
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    DozensRound1 = new int[] { item[2].ConvertToInt(), item[3].ConvertToInt(),
                                           item[4].ConvertToInt(), item[5].ConvertToInt(),
                                           item[6].ConvertToInt(), item[7].ConvertToInt() }.OrderBy(c => c).ToArray(),
                    TotalAmount = item[8].ConvertToDecimal(),
                    Winners6NumbersRound1 = item[9].ConvertToInt(),
                    City = item[10].ConvertEmptyToString(),
                    UF = item[11].ConvertWithMetaChatToString(),
                    Average6NumbersRound1 = item[12].ConvertToDecimal(),
                    IsAccumulated = item[13].ConvertToBoolean(),
                    AccumulatedValueRound1 = item[14].ConvertToDecimal(),
                    Winners5NumbersRound1 = item[15].ConvertToInt(),
                    Average5NumbersRound1 = item[16].ConvertToDecimal(),
                    Winners4NumbersRound1 = item[17].ConvertToInt(),
                    Average4NumbersRound1 = item[18].ConvertToDecimal(),
                    Winners3NumbersRound1 = item[19].ConvertToInt(),
                    Average3NumbersRound1 = item[20].ConvertToDecimal(),

                    DozensRound2 = new int[] { item[21].ConvertToInt(), item[22].ConvertToInt(),
                                           item[23].ConvertToInt(), item[24].ConvertToInt(),
                                           item[25].ConvertToInt(), item[26].ConvertToInt() }.OrderBy(c => c).ToArray(),
                    Winners6NumbersRound2 = item[27].ConvertToInt(),
                    Average6NumbersRound2 = item[28].ConvertToDecimal(),
                    Winners5NumbersRound2 = item[29].ConvertToInt(),
                    Average5NumbersRound2 = item[30].ConvertToDecimal(),
                    Winners4NumbersRound2 = item[31].ConvertToInt(),
                    Average4NumbersRound2 = item[32].ConvertToDecimal(),
                    Winners3NumbersRound2 = item[33].ConvertToInt(),
                    Average3NumbersRound2 = item[34].ConvertToDecimal(),

                    EstimatedPrize = item[35].ConvertToDecimal(),
                    AccumulatedEspecialPascoa = item[36].ConvertToDecimal()
                };
            }
        }
    }
}