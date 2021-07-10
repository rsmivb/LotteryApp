using Lottery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class LotoGol : MongoModel, IEquatable<LotoGol>
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

        public override bool Equals(object obj) => Equals(obj as LotoGol);

        public bool Equals(LotoGol other) => other != null &&
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

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-{City}-{UF}-" +
                   $"{Winners5}-{Average5}-{IsAcumlated5}-{Acumulated5}-" +
                   $"{Winners4}-{Average4}-{IsAcumlated4}-{Acumulated4}-" +
                   $"{Winners3}-{Average3}-{IsAcumlated3}-{Acumulated3}-" +
                   $"[{string.Join(",", Dozens)}]-{TotalAmount}-{EstimatedPrize} }}";
    }
}
