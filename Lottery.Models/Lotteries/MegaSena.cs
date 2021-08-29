using Lottery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class MegaSena : MongoModel, IEquatable<MegaSena>
    {
        public int LotteryId { get; set; }
        public string City { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public int WinnersSena { get; set; }
        public int WinnersQuina { get; set; }
        public int WinnersQuadra { get; set; }
        public decimal WinnersSenaValue { get; set; }
        public decimal WinnersQuinaValue { get; set; }
        public decimal WinnersQuadraValues { get; set; }

        public override bool Equals(object obj) => Equals(obj as MegaSena);
        public bool Equals(MegaSena sena)
        {
            return _id == sena._id &&
                   LotteryId == sena.LotteryId &&
                   City == sena.City &&
                   DateRealized == sena.DateRealized &&
                   Dozens.SequenceEqual(sena.Dozens) &&
                   WinnersSena == sena.WinnersSena &&
                   WinnersQuina == sena.WinnersQuina &&
                   WinnersQuadra == sena.WinnersQuadra &&
                   WinnersSenaValue == sena.WinnersSenaValue &&
                   WinnersQuinaValue == sena.WinnersQuinaValue &&
                   WinnersQuadraValues == sena.WinnersQuadraValues;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(_id);
            hash.Add(LotteryId);
            hash.Add(City);
            hash.Add(DateRealized);
            hash.Add(Dozens);
            hash.Add(WinnersSena);
            hash.Add(WinnersQuina);
            hash.Add(WinnersQuadra);
            hash.Add(WinnersSenaValue);
            hash.Add(WinnersQuinaValue);
            hash.Add(WinnersQuadraValues);
            return hash.ToHashCode();
        }

        public override string ToString() => $"{{ {LotteryId}-{City}-{DateRealized}-" +
            $"[{string.Join(",", Dozens)}]-{WinnersSena}-{WinnersQuina}-{WinnersQuadra}-"+
                   $"{WinnersSenaValue}-{WinnersQuinaValue}-{WinnersQuadraValues} }}";
    }
}
