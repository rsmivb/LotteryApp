using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lottery.Models
{
    public class Loteca : MongoModel
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int Winners14 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public decimal Average14 { get; set; }
        public bool IsAcumulated { get; set; }
        public decimal AmountValue14 { get; set; }
        public int Winners13 { get; set; }
        public decimal AmountValue13 { get; set; }
        public decimal Winners12 { get; set; }
        public decimal AmountValue12 { get; set; }
        public char[] Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal EstimatedPrize { get; set; }
    }

    public static class LotecaExtensionMethods
    {
        public static IEnumerable<Loteca> Load(IList<IList<string>> items)
        {
            foreach (var item in items)
            {
                yield return new Loteca
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Winners14 = item[2].ConvertToInt(),
                    City = item[3].ConvertEmptyToString(),
                    UF = item[4].ConvertWithMetaChatToString(),
                    Average14 = item[5].ConvertToDecimal(),
                    IsAcumulated = item[6].ConvertToBoolean(),
                    AmountValue14 = item[7].ConvertToDecimal(),
                    Winners13 = item[8].ConvertToInt(),
                    AmountValue13 = item[9].ConvertToDecimal(),
                    Winners12 = item[10].ConvertToInt(),
                    AmountValue12 = item[11].ConvertToDecimal(),
                    Dozens = new char[] { item[12].ConvertToChar(), item[13].ConvertToChar(), item[14].ConvertToChar(), item[15].ConvertToChar(),
                                      item[16].ConvertToChar(), item[17].ConvertToChar(), item[18].ConvertToChar(), item[19].ConvertToChar(),
                                      item[20].ConvertToChar(), item[21].ConvertToChar(), item[22].ConvertToChar(), item[23].ConvertToChar(),
                                      item[24].ConvertToChar(), item[25].ConvertToChar()}.OrderBy(c => c).ToArray(),
                    TotalAmount = item[26].ConvertToDecimal(),
                    EstimatedPrize = item[27].ConvertToDecimal()
                };
            }
        }
    }
}
