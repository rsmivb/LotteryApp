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
                    City = item[1].ToUpper().ConvertEmptyToString(),
                    DateRealized = item[2].ConvertToDateTime(),
                    Dozens = new List<int> { item[3].ConvertToInt(), item[4].ConvertToInt(),
                                     item[5].ConvertToInt(), item[6].ConvertToInt(),
                                     item[7].ConvertToInt(), item[8].ConvertToInt() }.OrderBy(c => c).ToList(),
                    WinnersSena = item[9].ConvertToInt(),
                    WinnersQuina = item[10].ConvertToInt(),
                    WinnersQuadra = item[11].ConvertToInt(),
                    WinnersSenaValue = item[12].ConvertToDecimal(),
                    WinnersQuinaValue = item[13].ConvertToDecimal(),
                    WinnersQuadraValues = item[14].ConvertToDecimal()
                };
            }
        }
    }
}
