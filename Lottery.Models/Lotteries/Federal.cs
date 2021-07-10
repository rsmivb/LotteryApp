using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class Federal : MongoModel, IEquatable<Federal>
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public decimal Prize1 { get; set; }
        public decimal Prize2 { get; set; }
        public decimal Prize3 { get; set; }
        public decimal Prize4 { get; set; }
        public decimal Prize5 { get; set; }

        public override bool Equals(object obj) => Equals(obj as Federal);

        public bool Equals(Federal other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   Prize1 == other.Prize1 &&
                   Prize2 == other.Prize2 &&
                   Prize3 == other.Prize3 &&
                   Prize4 == other.Prize4 &&
                   Prize5 == other.Prize5;

        public override int GetHashCode()
        {
            var hashCode = 2146608948;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + Prize1.GetHashCode();
            hashCode = hashCode * -1521134295 + Prize2.GetHashCode();
            hashCode = hashCode * -1521134295 + Prize3.GetHashCode();
            hashCode = hashCode * -1521134295 + Prize4.GetHashCode();
            hashCode = hashCode * -1521134295 + Prize5.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                    $"{Prize1}-{Prize2}-{Prize3}-{Prize4}-{Prize5} }}";
    }
}
