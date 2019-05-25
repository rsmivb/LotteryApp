using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class LotteryData : IEquatable<LotteryData>
    {
        //Lottery name
        public string LotteryName { get; set; }
        // total de concursos e o total de premiações
        public ArwardsData AwardData { get; set; }
        // total de pessoas que ganharam dividindo a media por tipo de premiação
        public IEnumerable<AverageData> AverageWinnersData { get; set; }
        // total de resultado por dezena
        public List<DozenData> DozenByQuantity { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as LotteryData);
        }

        public bool Equals(LotteryData other)
        {
            return other != null &&
                   LotteryName == other.LotteryName &&
                   EqualityComparer<ArwardsData>.Default.Equals(AwardData, other.AwardData) &&
                   EqualityComparer<IEnumerable<AverageData>>.Default.Equals(AverageWinnersData, other.AverageWinnersData) &&
                   EqualityComparer<List<DozenData>>.Default.Equals(DozenByQuantity, other.DozenByQuantity);
        }

        public override int GetHashCode()
        {
            var hashCode = -1462996908;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LotteryName);
            hashCode = hashCode * -1521134295 + EqualityComparer<ArwardsData>.Default.GetHashCode(AwardData);
            hashCode = hashCode * -1521134295 + EqualityComparer<IEnumerable<AverageData>>.Default.GetHashCode(AverageWinnersData);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<DozenData>>.Default.GetHashCode(DozenByQuantity);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{ {LotteryName}-{AwardData}-[{string.Join(",",AverageWinnersData)}]-[{string.Join(",", DozenByQuantity)}] }}";
        }

    }

    public class DozenData
    {
        public int Dozen { get; set; }
        public int SumOf { get; set; }

        public override string ToString()
        {
            return $"{{ {Dozen}-{SumOf} }}";
        }
    }

    public class ArwardsData : IEquatable<ArwardsData>
    {
        public int TotalLotteries { get; set; }
        public decimal TotalAward { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ArwardsData);
        }

        public bool Equals(ArwardsData other)
        {
            return other != null &&
                   TotalLotteries == other.TotalLotteries &&
                   TotalAward == other.TotalAward;
        }

        public override int GetHashCode()
        {
            var hashCode = -1537093732;
            hashCode = hashCode * -1521134295 + TotalLotteries.GetHashCode();
            hashCode = hashCode * -1521134295 + TotalAward.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{ {TotalLotteries}-{TotalAward} }}";
        }

    }
    public class AverageData : IEquatable<AverageData>
    {
        public string TypeOfAward { get; set; }
        public decimal TotalPeopleWhoWon { get; set; }
        public decimal AwardAverage { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as AverageData);
        }

        public bool Equals(AverageData other)
        {
            return other != null &&
                   TypeOfAward == other.TypeOfAward &&
                   TotalPeopleWhoWon == other.TotalPeopleWhoWon &&
                   AwardAverage == other.AwardAverage;
        }

        public override int GetHashCode()
        {
            var hashCode = 1373798323;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeOfAward);
            hashCode = hashCode * -1521134295 + TotalPeopleWhoWon.GetHashCode();
            hashCode = hashCode * -1521134295 + AwardAverage.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{{ {TypeOfAward}-{TotalPeopleWhoWon}-{AwardAverage} }}";
        }

    }
}
