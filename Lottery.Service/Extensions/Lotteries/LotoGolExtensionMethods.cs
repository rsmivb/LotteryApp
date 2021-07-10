using Lottery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services.Extensions
{
    public static class LotoGolExtensionMethods
    {
        public static IEnumerable<LotoGol> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new LotoGol
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    City = item[2].ConvertEmptyToString(),
                    UF = item[3].ConvertWithMetaChatToString(),
                    Winners5 = item[4].ConvertToInt(),
                    Average5 = item[5].ConvertToDecimal(),
                    IsAcumlated5 = item[6].ConvertToBoolean(),
                    Acumulated5 = item[7].ConvertToDecimal(),
                    Winners4 = item[8].ConvertToInt(),
                    Average4 = item[9].ConvertToDecimal(),
                    IsAcumlated4 = item[10].ConvertToBoolean(),
                    Acumulated4 = item[11].ConvertToDecimal(),
                    Winners3 = item[12].ConvertToInt(),
                    Average3 = item[13].ConvertToDecimal(),
                    IsAcumlated3 = item[14].ConvertToBoolean(),
                    Acumulated3 = item[15].ConvertToDecimal(),
                    Dozens = new List<string> { item[16].ConvertToAChar(), item[17].ConvertToAChar(), item[18].ConvertToAChar(), item[19].ConvertToAChar(),
                                      item[20].ConvertToAChar(), item[21].ConvertToAChar(), item[22].ConvertToAChar(), item[23].ConvertToAChar(),
                                      item[24].ConvertToAChar(), item[25].ConvertToAChar() }.OrderBy(c => c).ToList(),
                    TotalAmount = item[26].ConvertToDecimal(),
                    EstimatedPrize = item[27].ConvertToDecimal()
                };
            }
        }
    }
}
