using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class LotoGol : MongoModel
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
        public List<char> Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal EstimatedPrize { get; set; }
        public override string ToString()
        {
            return $"{{ {LotteryId}-{DateRealized}-{City}-{UF}-{Winners5}-{Average5}-{IsAcumlated5}-{Acumulated5}-{Winners4}-{Average4}-{IsAcumlated4}-{Acumulated4}-{Winners3}-{Average3}-{IsAcumlated3}-{Acumulated3}-[{string.Join(",", Dozens)}]-{TotalAmount}-{EstimatedPrize} }}";
        }
    }
    public static class LotoGolExtensionMethods
    {
        public static IEnumerable<LotoGol> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new LotoGol
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    City = item[2].ConvertEmptyToString(),
                    UF = item[3].ConvertWithMetaChatToString(),
                    Winners5 = item[4].ConvertToInt(),
                    Average5 = item[5].ConvertToDecimal(),
                    IsAcumlated5 = item[6].ConvertToBoolean(),
                    Acumulated5 = item[7].ConvertToDecimal(),
                    Winners4 = item[8].ConvertToInt(),
                    Average4 = item[9].ConvertToDecimal(),
                    IsAcumlated4 = item[10].ConvertToBoolean(),
                    Acumulated4 = item[11].ConvertToDecimal(),
                    Winners3 = item[12].ConvertToInt(),
                    Average3 = item[13].ConvertToDecimal(),
                    IsAcumlated3 = item[14].ConvertToBoolean(),
                    Acumulated3 = item[15].ConvertToDecimal(),
                    Dozens = new List<char> { item[16].ConvertToChar(), item[17].ConvertToChar(), item[18].ConvertToChar(), item[19].ConvertToChar(),
                                      item[20].ConvertToChar(), item[21].ConvertToChar(), item[22].ConvertToChar(), item[23].ConvertToChar(),
                                      item[24].ConvertToChar(), item[25].ConvertToChar() }.OrderBy(c => c).ToList(),
                    TotalAmount = item[26].ConvertToDecimal(),
                    EstimatedPrize = item[27].ConvertToDecimal()
                };
            }
        }
    }
}
