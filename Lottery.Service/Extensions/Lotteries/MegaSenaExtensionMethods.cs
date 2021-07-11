using Lottery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services
{
    public static class MegaSenaExtensionMethods
    {
        public static IEnumerable<MegaSena> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new MegaSena
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(), item[3].ConvertToInt(),
                                     item[4].ConvertToInt(), item[5].ConvertToInt(),
                                     item[6].ConvertToInt(), item[7].ConvertToInt() }.OrderBy(c => c).ToList(),
                    TotalCollection = item[8].ConvertToDecimal(),
                    Winners6Numbers = item[9].ConvertToInt(),
                    City = item[10].ConvertEmptyToString(),
                    UF = item[11].ConvertWithMetaChatToString(),
                    Average6Numbers = item[12].ConvertToDecimal(),
                    Winners5Numbers = item[13].ConvertToInt(),
                    Average5Numbers = item[14].ConvertToDecimal(),
                    Winners4Numbers = item[15].ConvertToInt(),
                    Average4Numbers = item[16].ConvertToDecimal(),
                    IsAccumulated = item[17].ConvertToBoolean(),
                    AccumulatedPrize = item[18].ConvertToDecimal(),
                    EstimatedPrize = item[19].ConvertToDecimal(),
                    AccumulatedMegaSenaVirada = item[20].ConvertToDecimal()
                };
            }
        }
    }
}
