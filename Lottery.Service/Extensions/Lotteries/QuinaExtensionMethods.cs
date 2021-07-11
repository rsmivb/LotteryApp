using Lottery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services
{
    public static class QuinaExtensionMethods
    {
        public static IEnumerable<Quina> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new Quina
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(), item[3].ConvertToInt(),
                                             item[4].ConvertToInt(), item[5].ConvertToInt(),
                                             item[6].ConvertToInt() }.OrderBy(c => c).ToList(),
                    TotalAmount = item[7].ConvertToDecimal(),
                    Winners5 = item[8].ConvertToInt(),
                    City = item[9].ConvertEmptyToString(),
                    UF = item[10].ConvertWithMetaChatToString(),
                    Average5Numbers = item[11].ConvertToDecimal(),
                    Winners4 = item[12].ConvertToInt(),
                    Average4Numbers = item[13].ConvertToDecimal(),
                    Winners3 = item[14].ConvertToInt(),
                    Average3Numbers = item[15].ConvertToDecimal(),
                    Winners2 = item[16].ConvertToInt(),
                    Average2Numbers = item[17].ConvertToDecimal(),
                    IsAccumulated = item[18].ConvertToBoolean(),
                    AccumulatedValue = item[19].ConvertToDecimal(),
                    EstimatePrize = item[20].ConvertToDecimal(),
                    AccumulatedSorteioSaoJoao = item[21].ConvertToDecimal()
                };
            }
        }
    }
}
