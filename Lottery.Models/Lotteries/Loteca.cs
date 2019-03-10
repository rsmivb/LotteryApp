using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lottery.Models
{
    public class Loteca : MongoObject
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
        public static Loteca Load(IList<string> nodes) => new Loteca
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Winners14 = nodes[2].ConvertToInt(),
                City = nodes[3].ConvertEmptyToString(),
                UF = nodes[4].ConvertWithMetaChatToString(),
                Average14 = nodes[5].ConvertToDecimal(),
                IsAcumulated = nodes[6].ConvertToBoolean(),
                AmountValue14 = nodes[7].ConvertToDecimal(),
                Winners13 = nodes[8].ConvertToInt(),
                AmountValue13 = nodes[9].ConvertToDecimal(),
                Winners12 = nodes[10].ConvertToInt(),
                AmountValue12 = nodes[11].ConvertToDecimal(),
                Dozens = new char[] { nodes[12].ConvertToChar(), nodes[13].ConvertToChar(), nodes[14].ConvertToChar(), nodes[15].ConvertToChar(),
                                      nodes[16].ConvertToChar(), nodes[17].ConvertToChar(), nodes[18].ConvertToChar(), nodes[19].ConvertToChar(),
                                      nodes[20].ConvertToChar(), nodes[21].ConvertToChar(), nodes[22].ConvertToChar(), nodes[23].ConvertToChar(),
                                      nodes[24].ConvertToChar(), nodes[25].ConvertToChar()},
                TotalAmount = nodes[26].ConvertToDecimal(),
                EstimatedPrize = nodes[27].ConvertToDecimal()
            };
    }
}
