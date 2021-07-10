using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class MegaSena : MongoModel, IEquatable<MegaSena>
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public decimal TotalCollection { get; set; }
        public int Winners6Numbers { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public decimal Average6Numbers { get; set; }
        public int Winners5Numbers { get; set; }
        public decimal Average5Numbers { get; set; }
        public int Winners4Numbers { get; set; }
        public decimal Average4Numbers { get; set; }
        public bool IsAccumulated { get; set; }
        public decimal AccumulatedPrize { get; set; }
        public decimal EstimatedPrize { get; set; }
        public decimal AccumulatedMegaSenaVirada { get; set; }

        public override bool Equals(object obj) => Equals(obj as MegaSena);

        public bool Equals(MegaSena other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   TotalCollection == other.TotalCollection &&
                   Winners6Numbers == other.Winners6Numbers &&
                   City == other.City &&
                   UF == other.UF &&
                   Average6Numbers == other.Average6Numbers &&
                   Winners5Numbers == other.Winners5Numbers &&
                   Average5Numbers == other.Average5Numbers &&
                   Winners4Numbers == other.Winners4Numbers &&
                   Average4Numbers == other.Average4Numbers &&
                   IsAccumulated == other.IsAccumulated &&
                   AccumulatedPrize == other.AccumulatedPrize &&
                   EstimatedPrize == other.EstimatedPrize &&
                   AccumulatedMegaSenaVirada == other.AccumulatedMegaSenaVirada;

        public override int GetHashCode()
        {
            var hashCode = 993017454;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + TotalCollection.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners6Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + Average6Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners5Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Average5Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners4Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Average4Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAccumulated.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedPrize.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatedPrize.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedMegaSenaVirada.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                   $"{TotalCollection}-{Winners6Numbers}-{City}-{UF}-" +
                   $"{Average6Numbers}-{Winners5Numbers}-{Average5Numbers}-" +
                   $"{Winners4Numbers}-{Average4Numbers}-{IsAccumulated}-" +
                   $"{AccumulatedPrize}-{EstimatedPrize}-{AccumulatedMegaSenaVirada} }}";
    }
}
