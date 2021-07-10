using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class Quina : MongoModel
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public int Winners5 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public decimal Average5Numbers { get; set; }
        public int Winners4 { get; set; }
        public decimal Average4Numbers { get; set; }
        public int Winners3 { get; set; }
        public decimal Average3Numbers { get; set; }
        public int Winners2 { get; set; }
        public decimal Average2Numbers { get; set; }
        public bool IsAccumulated { get; set; }
        public decimal AccumulatedValue { get; set; }
        public decimal EstimatePrize { get; set; }
        public decimal AccumulatedSorteioSaoJoao { get; set; }

        public override bool Equals(object obj) => Equals(obj as Quina);

        public bool Equals(Quina other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   TotalAmount == other.TotalAmount &&
                   Winners5 == other.Winners5 &&
                   City == other.City &&
                   UF == other.UF &&
                   Average5Numbers == other.Average5Numbers &&
                   Winners4 == other.Winners4 &&
                   Average4Numbers == other.Average4Numbers &&
                   Winners3 == other.Winners3 &&
                   Average3Numbers == other.Average3Numbers &&
                   Winners2 == other.Winners2 &&
                   Average2Numbers == other.Average2Numbers &&
                   IsAccumulated == other.IsAccumulated &&
                   AccumulatedValue == other.AccumulatedValue &&
                   EstimatePrize == other.EstimatePrize &&
                   AccumulatedSorteioSaoJoao == other.AccumulatedSorteioSaoJoao;

        public override int GetHashCode()
        {
            var hashCode = -32890929;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + TotalAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners5.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + Average5Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners4.GetHashCode();
            hashCode = hashCode * -1521134295 + Average4Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners3.GetHashCode();
            hashCode = hashCode * -1521134295 + Average3Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + Winners2.GetHashCode();
            hashCode = hashCode * -1521134295 + Average2Numbers.GetHashCode();
            hashCode = hashCode * -1521134295 + IsAccumulated.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedValue.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatePrize.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedSorteioSaoJoao.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                   $"{TotalAmount}-{Winners5}-{City}-{UF}-" +
                   $"{Average5Numbers}-{Winners4}-{Average4Numbers}-" +
                   $"{Winners3}-{Average3Numbers}-{Winners2}-{Average2Numbers}-" +
                   $"{IsAccumulated}-{AccumulatedValue}-" +
                   $"{EstimatePrize}-{AccumulatedSorteioSaoJoao} }}";
    }
}
