using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class TimeMania : MongoModel, IEquatable<TimeMania>
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public string Team { get; set; }
        public decimal TotalValue { get; set; }
        public int TotalWinners7 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int TotalWinners6 { get; set; }
        public int TotalWinners5 { get; set; }
        public int TotalWinners4 { get; set; }
        public int TotalWinners3 { get; set; }
        public int WinnersTeam { get; set; }
        public decimal TotalValueNumbers7 { get; set; }
        public decimal TotalValueNumbers6 { get; set; }
        public decimal TotalValueNumbers5 { get; set; }
        public decimal TotalValueNumbers4 { get; set; }
        public decimal TotalValueNumbers3 { get; set; }
        public decimal TeamValue { get; set; }
        public decimal AccumulatedValue { get; set; }
        public decimal EstimatedPrize { get; set; }

        public override bool Equals(object obj) => Equals(obj as TimeMania);
        public bool Equals(TimeMania other) => other != null &&
                   LotteryId == other.LotteryId &&
                   DateRealized == other.DateRealized &&
                   Dozens.SequenceEqual(other.Dozens) &&
                   Team == other.Team &&
                   TotalValue == other.TotalValue &&
                   TotalWinners7 == other.TotalWinners7 &&
                   City == other.City &&
                   UF == other.UF &&
                   TotalWinners6 == other.TotalWinners6 &&
                   TotalWinners5 == other.TotalWinners5 &&
                   TotalWinners4 == other.TotalWinners4 &&
                   TotalWinners3 == other.TotalWinners3 &&
                   WinnersTeam == other.WinnersTeam &&
                   TotalValueNumbers7 == other.TotalValueNumbers7 &&
                   TotalValueNumbers6 == other.TotalValueNumbers6 &&
                   TotalValueNumbers5 == other.TotalValueNumbers5 &&
                   TotalValueNumbers4 == other.TotalValueNumbers4 &&
                   TotalValueNumbers3 == other.TotalValueNumbers3 &&
                   TeamValue == other.TeamValue &&
                   AccumulatedValue == other.AccumulatedValue &&
                   EstimatedPrize == other.EstimatedPrize;

        public override int GetHashCode()
        {
            var hashCode = -1788079105;
            hashCode = hashCode * -1521134295 + LotteryId.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRealized.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<int>>.Default.GetHashCode(Dozens);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Team);
            hashCode = hashCode * -1521134295 + TotalValue.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalWinners7.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UF);
            hashCode = hashCode * -1521134295 + TotalWinners6.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalWinners5.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalWinners4.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalWinners3.GetHashCode();
            hashCode = hashCode * -1521134295 + WinnersTeam.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalValueNumbers7.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalValueNumbers6.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalValueNumbers5.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalValueNumbers4.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalValueNumbers3.GetHashCode();
            hashCode = hashCode * -1521134295 + TeamValue.GetHashCode();
            hashCode = hashCode * -1521134295 + AccumulatedValue.GetHashCode();
            hashCode = hashCode * -1521134295 + EstimatedPrize.GetHashCode();
            return hashCode;
        }

        public override string ToString() => $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                   $"{Team}-{TotalValue}-{TotalWinners7}-{City}-{UF}-" +
                   $"{TotalWinners6}-{TotalWinners5}-{TotalWinners4}-" +
                   $"{TotalWinners3}-{WinnersTeam}-{TotalValueNumbers7}-" +
                   $"{TotalValueNumbers6}-{TotalValueNumbers5}-" +
                   $"{TotalValueNumbers4}-{TotalValueNumbers3}-" +
                   $"{TeamValue}-{AccumulatedValue}-{EstimatedPrize} }}";
    }
}
