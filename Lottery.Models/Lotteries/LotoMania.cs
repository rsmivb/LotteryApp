using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class LotoMania : MongoModel, IEquatable<LotoMania>
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalWinners20 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int TotalWinners19 { get; set; }
        public int TotalWinners18 { get; set; }
        public int TotalWinners17 { get; set; }
        public int TotalWinners16 { get; set; }
        public int TotalWinnersNoNumbers { get; set; }
        public decimal TotalValueNumbers20 { get; set; }
        public decimal TotalValueNumbers19 { get; set; }
        public decimal TotalValueNumbers18 { get; set; }
        public decimal TotalValueNumbers17 { get; set; }
        public decimal TotalValueNumbers16 { get; set; }
        public decimal TotalValueNoNumbers { get; set; }
        public decimal Acumulated20 { get; set; }
        public decimal Acumulated19 { get; set; }
        public decimal Acumulated18 { get; set; }
        public decimal Acumulated17 { get; set; }
        public decimal Acumulated16 { get; set; }
        public decimal AcumulatedNoNumbers { get; set; }
        public decimal PrizeEstimated { get; set; }
        public decimal SpecialPrizeEstimated { get; set; }

        public override bool Equals(object obj) => Equals(obj as LotoMania);

        public bool Equals(LotoMania other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   TotalValue == other.TotalValue &&
                   TotalWinners20 == other.TotalWinners20 &&
                   City == other.City &&
                   UF == other.UF &&
                   TotalWinners19 == other.TotalWinners19 &&
                   TotalWinners18 == other.TotalWinners18 &&
                   TotalWinners17 == other.TotalWinners17 &&
                   TotalWinners16 == other.TotalWinners16 &&
                   TotalWinnersNoNumbers == other.TotalWinnersNoNumbers &&
                   TotalValueNumbers20 == other.TotalValueNumbers20 &&
                   TotalValueNumbers19 == other.TotalValueNumbers19 &&
                   TotalValueNumbers18 == other.TotalValueNumbers18 &&
                   TotalValueNumbers17 == other.TotalValueNumbers17 &&
                   TotalValueNumbers16 == other.TotalValueNumbers16 &&
                   TotalValueNoNumbers == other.TotalValueNoNumbers &&
                   Acumulated20 == other.Acumulated20 &&
                   Acumulated19 == other.Acumulated19 &&
                   Acumulated18 == other.Acumulated18 &&
                   Acumulated17 == other.Acumulated17 &&
                   Acumulated16 == other.Acumulated16 &&
                   AcumulatedNoNumbers == other.AcumulatedNoNumbers &&
                   PrizeEstimated == other.PrizeEstimated &&
                   SpecialPrizeEstimated == other.SpecialPrizeEstimated;

        public override int GetHashCode()
        {
            var hashCode = -94129212;
            hashCode *= -1521134295 + LotteryId.GetHashCode();
            hashCode *= -1521134295 + DateRealized.GetHashCode();
            hashCode *= -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Dozens);
            hashCode *= -1521134295 + TotalValue.GetHashCode();
            hashCode *= -1521134295 + TotalWinners20.GetHashCode();
            hashCode *= -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode *= -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode *= -1521134295 + TotalWinners19.GetHashCode();
            hashCode *= -1521134295 + TotalWinners18.GetHashCode();
            hashCode *= -1521134295 + TotalWinners17.GetHashCode();
            hashCode *= -1521134295 + TotalWinners16.GetHashCode();
            hashCode *= -1521134295 + TotalWinnersNoNumbers.GetHashCode();
            hashCode *= -1521134295 + TotalValueNumbers20.GetHashCode();
            hashCode *= -1521134295 + TotalValueNumbers19.GetHashCode();
            hashCode *= -1521134295 + TotalValueNumbers18.GetHashCode();
            hashCode *= -1521134295 + TotalValueNumbers17.GetHashCode();
            hashCode *= -1521134295 + TotalValueNumbers16.GetHashCode();
            hashCode *= -1521134295 + TotalValueNoNumbers.GetHashCode();
            hashCode *= -1521134295 + Acumulated20.GetHashCode();
            hashCode *= -1521134295 + Acumulated19.GetHashCode();
            hashCode *= -1521134295 + Acumulated18.GetHashCode();
            hashCode *= -1521134295 + Acumulated17.GetHashCode();
            hashCode *= -1521134295 + Acumulated16.GetHashCode();
            hashCode *= -1521134295 + AcumulatedNoNumbers.GetHashCode();
            hashCode *= -1521134295 + PrizeEstimated.GetHashCode();
            hashCode *= -1521134295 + SpecialPrizeEstimated.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                   $"{TotalValue}-{TotalWinners20}-{City}-{UF}-" +
                   $"{TotalWinners19}-{TotalWinners18}-{TotalWinners17}-{TotalWinners16}-" +
                   $"{TotalWinnersNoNumbers}-{TotalValueNumbers20}-{TotalValueNumbers19}-" +
                   $"{TotalValueNumbers18}-{TotalValueNumbers17}-{TotalValueNumbers16}-" +
                   $"{TotalValueNoNumbers}-{Acumulated20}-{Acumulated19}-{Acumulated18}-" +
                   $"{Acumulated17}-{Acumulated16}-{AcumulatedNoNumbers}-" +
                   $"{PrizeEstimated}-{SpecialPrizeEstimated} }}";
    }
}
