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

        public override bool Equals(object obj) => Equals(obj as LotoFacil);

        public bool Equals(LotoFacil other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Dozens.SequenceEqual(other.Dozens) &&
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

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                   $"{TotalAmount}-{Winners15}-{City}-{UF}-{Winners14}-{Winners13}-" +
                   $"{Winners12}-{Winners11}-{AverageAmount15}-{AverageAmount14}-" +
                   $"{AverageAmount13}-{AverageAmount12}-{AverageAmount11}-" +
                   $"{Accumulated15}-{EstimatedPrize}-{SpecialAmount} }}";
    }
}
