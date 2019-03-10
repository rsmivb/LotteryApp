using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class LotoGol : MongoObject
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int Winners5 { get; set; }
        public decimal Average5 { get; set; }
        public bool IsAcumlated5 { get; set; }
        public decimal Acumulated5 { get; set; }
        public int Winners4 { get; set; }
        public decimal Average4 { get; set; }
        public bool IsAcumlated4 { get; set; }
        public decimal Acumulated4 { get; set; }
        public int Winners3 { get; set; }
        public decimal Average3 { get; set; }
        public bool IsAcumlated3 { get; set; }
        public decimal Acumulated3 { get; set; }
        public char[] Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal EstimatedPrize { get; set; }
    }
    public static class LotoGolExtensionMethods
    {
        public static LotoGol Load(IList<string> nodes) => new LotoGol
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                City = nodes[2].ConvertEmptyToString(),
                UF = nodes[3].ConvertWithMetaChatToString(),
                Winners5 = nodes[4].ConvertToInt(),
                Average5 = nodes[5].ConvertToDecimal(),
                IsAcumlated5 = nodes[6].ConvertToBoolean(),
                Acumulated5 = nodes[7].ConvertToDecimal(),
                Winners4 = nodes[8].ConvertToInt(),
                Average4 = nodes[9].ConvertToDecimal(),
                IsAcumlated4 = nodes[10].ConvertToBoolean(),
                Acumulated4 = nodes[11].ConvertToDecimal(),
                Winners3 = nodes[12].ConvertToInt(),
                Average3 = nodes[13].ConvertToDecimal(),
                IsAcumlated3 = nodes[14].ConvertToBoolean(),
                Acumulated3 = nodes[15].ConvertToDecimal(),
                Dozens = new char[] { nodes[16].ConvertToChar(), nodes[17].ConvertToChar(), nodes[18].ConvertToChar(), nodes[19].ConvertToChar(),
                                      nodes[20].ConvertToChar(), nodes[21].ConvertToChar(), nodes[22].ConvertToChar(), nodes[23].ConvertToChar(),
                                      nodes[24].ConvertToChar(), nodes[25].ConvertToChar() },
                TotalAmount = nodes[26].ConvertToDecimal(),
                EstimatedPrize = nodes[27].ConvertToDecimal()
            };
    }
}
