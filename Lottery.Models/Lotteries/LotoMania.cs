using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class LotoMania : MongoModel
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
        public override string ToString()
        {
            return $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-" +
                   $"{TotalValue}-{TotalWinners20}-{City}-{UF}-" +
                   $"{TotalWinners19}-{TotalWinners18}-{TotalWinners17}-{TotalWinners16}-" +
                   $"{TotalWinnersNoNumbers}-{TotalValueNumbers20}-{TotalValueNumbers19}-" +
                   $"{TotalValueNumbers18}-{TotalValueNumbers17}-{TotalValueNumbers16}-" +
                   $"{TotalValueNoNumbers}-{Acumulated20}-{Acumulated19}-{Acumulated18}-" +
                   $"{Acumulated17}-{Acumulated16}-{AcumulatedNoNumbers}-" +
                   $"{PrizeEstimated}-{SpecialPrizeEstimated} }}";
        }
    }

    public static class LotoManiaExtensionMethods
    {
        public static IEnumerable<LotoMania> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new LotoMania
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(),  item[3].ConvertToInt(),
                                     item[4].ConvertToInt(),  item[5].ConvertToInt(),
                                     item[6].ConvertToInt(),  item[7].ConvertToInt(),
                                     item[8].ConvertToInt(),  item[9].ConvertToInt(),
                                     item[10].ConvertToInt(), item[11].ConvertToInt(),
                                     item[12].ConvertToInt(), item[13].ConvertToInt(),
                                     item[14].ConvertToInt(), item[15].ConvertToInt(),
                                     item[16].ConvertToInt(), item[17].ConvertToInt(),
                                     item[18].ConvertToInt(), item[19].ConvertToInt(),
                                     item[20].ConvertToInt(), item[21].ConvertToInt()}.OrderBy(c => c).ToList(),
                    TotalValue = item[22].ConvertToDecimal(),
                    TotalWinners20 = item[23].ConvertToInt(),
                    City = item[24].ConvertEmptyToString(),
                    UF = item[25].ConvertEmptyToString(),
                    TotalWinners19 = item[26].ConvertToInt(),
                    TotalWinners18 = item[27].ConvertToInt(),
                    TotalWinners17 = item[28].ConvertToInt(),
                    TotalWinners16 = item[29].ConvertToInt(),
                    TotalWinnersNoNumbers = item[30].ConvertToInt(),
                    TotalValueNumbers20 = item[31].ConvertToDecimal(),
                    TotalValueNumbers19 = item[32].ConvertToDecimal(),
                    TotalValueNumbers18 = item[33].ConvertToDecimal(),
                    TotalValueNumbers17 = item[34].ConvertToDecimal(),
                    TotalValueNumbers16 = item[35].ConvertToDecimal(),
                    TotalValueNoNumbers = item[36].ConvertToDecimal(),
                    Acumulated20 = item[37].ConvertToDecimal(),
                    Acumulated19 = item[38].ConvertToDecimal(),
                    Acumulated18 = item[39].ConvertToDecimal(),
                    Acumulated17 = item[40].ConvertToDecimal(),
                    Acumulated16 = item[41].ConvertToDecimal(),
                    AcumulatedNoNumbers = item[42].ConvertToDecimal(),
                    PrizeEstimated = item[43].ConvertToDecimal(),
                    SpecialPrizeEstimated = item[44].ConvertToDecimal()
                };
            }
        }
    }
}
