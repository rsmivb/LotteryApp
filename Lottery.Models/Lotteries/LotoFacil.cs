using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class LotoFacil : MongoModel, IEquatable<LotoFacil>
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public int Winners15 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int Winners14 { get; set; }
        public int Winners13 { get; set; }
        public int Winners12 { get; set; }
        public int Winners11 { get; set; }
        public decimal AverageAmount15 { get; set; }
        public decimal AverageAmount14 { get; set; }
        public decimal AverageAmount13 { get; set; }
        public decimal AverageAmount12 { get; set; }
        public decimal AverageAmount11 { get; set; }
        public decimal Accumulated15 { get; set; }
        public decimal EstimatedPrize { get; set; }
        public decimal SpecialAmount { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as LotoFacil);
        }

        public bool Equals(LotoFacil other)
        {
            return other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   EqualityComparer<List<int>>.Default.Equals(Dozens, other.Dozens) &&
                   TotalAmount == other.TotalAmount &&
                   Winners15 == other.Winners15 &&
                   City == other.City &&
                   UF == other.UF &&
                   Winners14 == other.Winners14 &&
                   Winners13 == other.Winners13 &&
                   Winners12 == other.Winners12 &&
                   Winners11 == other.Winners11 &&
                   AverageAmount15 == other.AverageAmount15 &&
                   AverageAmount14 == other.AverageAmount14 &&
                   AverageAmount13 == other.AverageAmount13 &&
                   AverageAmount12 == other.AverageAmount12 &&
                   AverageAmount11 == other.AverageAmount11 &&
                   Accumulated15 == other.Accumulated15 &&
                   EstimatedPrize == other.EstimatedPrize &&
                   SpecialAmount == other.SpecialAmount;
        }

        public override int GetHashCode()
        {
            var hashCode = 1711522462;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + TotalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners15.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + Winners14.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners13.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners12.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners11.GetHashCode();
            hashCode = hashCode * -1521134295 + AverageAmount15.GetHashCode();
            hashCode = hashCode * -1521134295 + AverageAmount14.GetHashCode();
            hashCode = hashCode * -1521134295 + AverageAmount13.GetHashCode();
            hashCode = hashCode * -1521134295 + AverageAmount12.GetHashCode();
            hashCode = hashCode * -1521134295 + AverageAmount11.GetHashCode();
            hashCode = hashCode * -1521134295 + Accumulated15.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatedPrize.GetHashCode();
            hashCode = hashCode * -1521134295 + SpecialAmount.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-{TotalAmount}-{Winners15}-{City}-{UF}-{Winners14}-{Winners13}-{Winners12}-{Winners11}-{AverageAmount15}-{AverageAmount14}-{AverageAmount13}-{AverageAmount12}-{AverageAmount11}-{Accumulated15}-{EstimatedPrize}-{SpecialAmount} }}";
        }
    }

    public static class LotoFacilExtensionMethods
    {
        public static IEnumerable<LotoFacil> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new LotoFacil
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(),
                                     item[3].ConvertToInt(),
                                     item[4].ConvertToInt(), item[5].ConvertToInt(),
                                     item[6].ConvertToInt(), item[7].ConvertToInt(),
                                     item[8].ConvertToInt(), item[9].ConvertToInt(),
                                     item[10].ConvertToInt(), item[11].ConvertToInt(),
                                     item[12].ConvertToInt(), item[13].ConvertToInt(),
                                     item[14].ConvertToInt(), item[15].ConvertToInt(), item[16].ConvertToInt()}.OrderBy(c => c).ToList(),
                    TotalAmount = item[17].ConvertToDecimal(),
                    Winners15 = item[18].ConvertToInt(),
                    City = item[19].ConvertEmptyToString(),
                    UF = item[20].ConvertWithMetaChatToString(),
                    Winners14 = item[21].ConvertToInt(),
                    Winners13 = item[22].ConvertToInt(),
                    Winners12 = item[23].ConvertToInt(),
                    Winners11 = item[24].ConvertToInt(),
                    AverageAmount15 = item[25].ConvertToDecimal(),
                    AverageAmount14 = item[26].ConvertToDecimal(),
                    AverageAmount13 = item[27].ConvertToDecimal(),
                    AverageAmount12 = item[28].ConvertToDecimal(),
                    AverageAmount11 = item[29].ConvertToDecimal(),
                    Accumulated15 = item[30].ConvertToDecimal(),
                    EstimatedPrize = item[31].ConvertToDecimal(),
                    SpecialAmount = item[32].ConvertToDecimal()
                };
            }
        }
    }
}
