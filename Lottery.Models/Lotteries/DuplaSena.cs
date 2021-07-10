using Lottery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    /// <summary>
    /// Needs to use IEquatable for tests (Equals)
    /// </summary>
    public class DuplaSena : MongoModel, IEquatable<DuplaSena>
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> DozensRound1 { get; set; }
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
        public List<int> DozensRound2 { get; set; }
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

        public override bool Equals(object obj) => Equals(obj as DuplaSena);
        public bool Equals(DuplaSena other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   DozensRound1.SequenceEqual(other.DozensRound1) &&
                   TotalAmount == other.TotalAmount &&
                   Winners6NumbersRound1 == other.Winners6NumbersRound1 &&
                   City == other.City &&
                   UF == other.UF &&
                   Average6NumbersRound1 == other.Average6NumbersRound1 &&
                   IsAccumulated == other.IsAccumulated &&
                   AccumulatedValueRound1 == other.AccumulatedValueRound1 &&
                   Winners5NumbersRound1 == other.Winners5NumbersRound1 &&
                   Average5NumbersRound1 == other.Average5NumbersRound1 &&
                   Winners4NumbersRound1 == other.Winners4NumbersRound1 &&
                   Average4NumbersRound1 == other.Average4NumbersRound1 &&
                   Winners3NumbersRound1 == other.Winners3NumbersRound1 &&
                   Average3NumbersRound1 == other.Average3NumbersRound1 &&
                   DozensRound2.SequenceEqual(other.DozensRound2) &&
                   Winners6NumbersRound2 == other.Winners6NumbersRound2 &&
                   Average6NumbersRound2 == other.Average6NumbersRound2 &&
                   Winners5NumbersRound2 == other.Winners5NumbersRound2 &&
                   Average5NumbersRound2 == other.Average5NumbersRound2 &&
                   Winners4NumbersRound2 == other.Winners4NumbersRound2 &&
                   Average4NumbersRound2 == other.Average4NumbersRound2 &&
                   Winners3NumbersRound2 == other.Winners3NumbersRound2 &&
                   Average3NumbersRound2 == other.Average3NumbersRound2 &&
                   EstimatedPrize == other.EstimatedPrize &&
                   AccumulatedEspecialPascoa == other.AccumulatedEspecialPascoa;

        public override int GetHashCode()
        {
            var hashCode = 553043719;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(DozensRound1);
            hashCode = hashCode * -1521134295 + TotalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners6NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + Average6NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAccumulated.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedValueRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners5NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + Average5NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners4NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + Average4NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners3NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + Average3NumbersRound1.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(DozensRound2);
            hashCode = hashCode * -1521134295 + Winners6NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Average6NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners5NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Average5NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners4NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Average4NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners3NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + Average3NumbersRound2.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatedPrize.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedEspecialPascoa.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", DozensRound1)}]-" +
                $"{TotalAmount}-{Winners6NumbersRound1}-{City}-{UF}-{Average6NumbersRound1}-" +
                $"{IsAccumulated}-{AccumulatedValueRound1}-{Winners5NumbersRound1}-{Average5NumbersRound1}-" +
                $"{Winners4NumbersRound1}-{Average4NumbersRound1}-{Winners3NumbersRound1}-{Average3NumbersRound1}-" +
                $"[{string.Join(",", DozensRound2)}]-{Winners6NumbersRound2}-{Average6NumbersRound2}-{Winners5NumbersRound2}-" +
                $"{Average5NumbersRound2}-{Winners4NumbersRound2}-{Average4NumbersRound2}-{Winners3NumbersRound2}-" +
                $"{Average3NumbersRound2}-{EstimatedPrize}-{AccumulatedEspecialPascoa} }}";
    }
}