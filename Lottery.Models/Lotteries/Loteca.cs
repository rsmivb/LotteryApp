using Lottery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class Loteca : MongoModel, IEquatable<Loteca>
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
        public List<string> Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal EstimatedPrize { get; set; }

        public override bool Equals(object obj) => Equals(obj as Loteca);

        public bool Equals(Loteca other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Winners14 == other.Winners14 &&
                   City == other.City &&
                   UF == other.UF &&
                   Average14 == other.Average14 &&
                   IsAcumulated == other.IsAcumulated &&
                   AmountValue14 == other.AmountValue14 &&
                   Winners13 == other.Winners13 &&
                   AmountValue13 == other.AmountValue13 &&
                   Winners12 == other.Winners12 &&
                   AmountValue12 == other.AmountValue12 &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   TotalAmount == other.TotalAmount &&
                   EstimatedPrize == other.EstimatedPrize;

        public override int GetHashCode()
        {
            var hashCode = 1465743342;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners14.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + Average14.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAcumulated.GetHashCode();
            hashCode = hashCode * -1521134295 + AmountValue14.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners13.GetHashCode();
            hashCode = hashCode * -1521134295 + AmountValue13.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners12.GetHashCode();
            hashCode = hashCode * -1521134295 + AmountValue12.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<string>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + TotalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatedPrize.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-{Winners14}-{City}-{UF}-" +
                   $"{Average14}-{IsAcumulated}-{AmountValue14}-{Winners13}-" +
                   $"{AmountValue13}-{Winners12}-{AmountValue12}-[{string.Join(",", Dozens)}]-" +
                   $"{TotalAmount}{EstimatedPrize} }}";
    }

}
