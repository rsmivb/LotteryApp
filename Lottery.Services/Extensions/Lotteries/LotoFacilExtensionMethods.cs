using Lottery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services
{
    public static class LotoFacilExtensionMethods
    {
        public static IEnumerable<LotoFacil> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new LotoFacil
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(),
                                     item[3].ConvertToInt(),
                                     item[4].ConvertToInt(), item[5].ConvertToInt(),
                                     item[6].ConvertToInt(), item[7].ConvertToInt(),
                                     item[8].ConvertToInt(), item[9].ConvertToInt(),
                                     item[10].ConvertToInt(), item[11].ConvertToInt(),
                                     item[12].ConvertToInt(), item[13].ConvertToInt(),
                                     item[14].ConvertToInt(), item[15].ConvertToInt(), item[16].ConvertToInt()}.OrderBy(c => c).ToList(),
                    TotalAmount = item[17].ConvertToDecimal(),
                    Winners15 = item[18].ConvertToInt(),
                    City = item[19].ConvertEmptyToString(),
                    UF = item[20].ConvertWithMetaChatToString(),
                    Winners14 = item[21].ConvertToInt(),
                    Winners13 = item[22].ConvertToInt(),
                    Winners12 = item[23].ConvertToInt(),
                    Winners11 = item[24].ConvertToInt(),
                    AverageAmount15 = item[25].ConvertToDecimal(),
                    AverageAmount14 = item[26].ConvertToDecimal(),
                    AverageAmount13 = item[27].ConvertToDecimal(),
                    AverageAmount12 = item[28].ConvertToDecimal(),
                    AverageAmount11 = item[29].ConvertToDecimal(),
                    Accumulated15 = item[30].ConvertToDecimal(),
                    EstimatedPrize = item[31].ConvertToDecimal(),
                    SpecialAmount = item[32].ConvertToDecimal()
                };
            }
        }
    }
}
