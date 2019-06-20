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
        public List<string> Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal EstimatedPrize { get; set; }
        public override bool Equals(object obj)
        {
            return Equals(obj as LotoGol);
        }

        public bool Equals(LotoGol other)
        {
            return other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   City == other.City &&
                   UF == other.UF &&
                   Winners5 == other.Winners5 &&
                   Average5 == other.Average5 &&
                   IsAcumlated5 == other.IsAcumlated5 &&
                   Acumulated5 == other.Acumulated5 &&
                   Winners4 == other.Winners4 &&
                   Average4 == other.Average4 &&
                   IsAcumlated4 == other.IsAcumlated4 &&
                   Acumulated4 == other.Acumulated4 &&
                   Winners3 == other.Winners3 &&
                   Average3 == other.Average3 &&
                   IsAcumlated3 == other.IsAcumlated3 &&
                   Acumulated3 == other.Acumulated3 &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   TotalAmount == other.TotalAmount &&
                   EstimatedPrize == other.EstimatedPrize;
        }

        public override int GetHashCode()
        {
            var hashCode = -710035858;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + Winners5.GetHashCode();
            hashCode = hashCode * -1521134295 + Average5.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAcumlated5.GetHashCode();
            hashCode = hashCode * -1521134295 + Acumulated5.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners4.GetHashCode();
            hashCode = hashCode * -1521134295 + Average4.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAcumlated4.GetHashCode();
            hashCode = hashCode * -1521134295 + Acumulated4.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners3.GetHashCode();
            hashCode = hashCode * -1521134295 + Average3.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAcumlated3.GetHashCode();
            hashCode = hashCode * -1521134295 + Acumulated3.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + TotalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatedPrize.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{ {LotteryId}-{DateRealized}-{City}-{UF}-" +
                   $"{Winners5}-{Average5}-{IsAcumlated5}-{Acumulated5}-" +
                   $"{Winners4}-{Average4}-{IsAcumlated4}-{Acumulated4}-" +
                   $"{Winners3}-{Average3}-{IsAcumlated3}-{Acumulated3}-" +
                   $"[{string.Join(",", Dozens)}]-{TotalAmount}-{EstimatedPrize} }}";
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
                    Dozens = new List<string> { item[16].ConvertToAChar(), item[17].ConvertToAChar(), item[18].ConvertToAChar(), item[19].ConvertToAChar(),
                                      item[20].ConvertToAChar(), item[21].ConvertToAChar(), item[22].ConvertToAChar(), item[23].ConvertToAChar(),
                                      item[24].ConvertToAChar(), item[25].ConvertToAChar() }.OrderBy(c => c).ToList(),
                    TotalAmount = item[26].ConvertToDecimal(),
                    EstimatedPrize = item[27].ConvertToDecimal()
                };
            }
        }
    }
}
