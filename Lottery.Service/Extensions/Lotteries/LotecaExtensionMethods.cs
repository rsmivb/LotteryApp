using Lottery.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Services
{
    public static class LotecaExtensionMethods
    {
        public static IEnumerable<Loteca> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new Loteca
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Winners14 = item[2].ConvertToInt(),
                    City = item[3].ConvertEmptyToString(),
                    UF = item[4].ConvertWithMetaChatToString(),
                    Average14 = item[5].ConvertToDecimal(),
                    IsAcumulated = item[6].ConvertToBoolean(),
                    AmountValue14 = item[7].ConvertToDecimal(),
                    Winners13 = item[8].ConvertToInt(),
                    AmountValue13 = item[9].ConvertToDecimal(),
                    Winners12 = item[10].ConvertToInt(),
                    AmountValue12 = item[11].ConvertToDecimal(),
                    Dozens = new List<string> { item[12].ConvertToAChar(), item[13].ConvertToAChar(), item[14].ConvertToAChar(), item[15].ConvertToAChar(),
                                      item[16].ConvertToAChar(), item[17].ConvertToAChar(), item[18].ConvertToAChar(), item[19].ConvertToAChar(),
                                      item[20].ConvertToAChar(), item[21].ConvertToAChar(), item[22].ConvertToAChar(), item[23].ConvertToAChar(),
                                      item[24].ConvertToAChar(), item[25].ConvertToAChar()}.OrderBy(c => c).ToList(),
                    TotalAmount = item[26].ConvertToDecimal(),
                    EstimatedPrize = item[27].ConvertToDecimal()
                };
            }
        }
    }
}
