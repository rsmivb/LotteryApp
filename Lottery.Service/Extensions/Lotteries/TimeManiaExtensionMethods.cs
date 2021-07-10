using Lottery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services.Extensions
{
    public static class TimeManiaExtensionMethods
    {
        public static IEnumerable<TimeMania> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new TimeMania
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(), item[3].ConvertToInt(),
                                     item[4].ConvertToInt(), item[5].ConvertToInt(),
                                     item[6].ConvertToInt(), item[7].ConvertToInt(),
                                     item[8].ConvertToInt()}.OrderBy(c => c).ToList(),
                    Team = item[9].ConvertEmptyToString(),
                    TotalValue = item[10].ConvertToDecimal(),
                    TotalWinners7 = item[11].ConvertToInt(),
                    City = item[12].ConvertEmptyToString(),
                    UF = item[13].ConvertEmptyToString(),
                    TotalWinners6 = item[14].ConvertToInt(),
                    TotalWinners5 = item[15].ConvertToInt(),
                    TotalWinners4 = item[16].ConvertToInt(),
                    TotalWinners3 = item[17].ConvertToInt(),
                    WinnersTeam = item[18].ConvertToInt(),
                    TotalValueNumbers7 = item[19].ConvertToDecimal(),
                    TotalValueNumbers6 = item[20].ConvertToDecimal(),
                    TotalValueNumbers5 = item[21].ConvertToDecimal(),
                    TotalValueNumbers4 = item[22].ConvertToDecimal(),
                    TotalValueNumbers3 = item[23].ConvertToDecimal(),
                    TeamValue = item[24].ConvertToDecimal(),
                    AccumulatedValue = item[25].ConvertToDecimal(),
                    EstimatedPrize = item[26].ConvertToDecimal()
                };
            }
        }
    }
}
