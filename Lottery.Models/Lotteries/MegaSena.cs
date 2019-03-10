using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lottery.Models
{
    public class MegaSena : MongoObject
    {
        public string LotteryName { get; set; }
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] Dozens { get; set; }
        public decimal TotalCollection { get; set; }
        public int Winners6Numbers  { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public decimal Average6Numbers { get; set; }
        public int Winners5Numbers { get; set; }
        public decimal Average5Numbers { get; set; }
        public int Winners4Numbers { get; set; }
        public decimal Average4Numbers { get; set; }
        public bool IsAccumulated { get; set; }
        public decimal AccumulatedPrize { get; set; }
        public decimal EstimatedPrize { get; set; }
        public decimal AccumulatedMegaSenaVirada { get; set; }
    }

    public static class MegaSenaExtensionMethods
    {
        public static MegaSena Load(IList<string> nodes) => new MegaSena
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Dozens = new int[] { nodes[2].ConvertToInt(), nodes[3].ConvertToInt(),
                                     nodes[4].ConvertToInt(), nodes[5].ConvertToInt(),
                                     nodes[6].ConvertToInt(), nodes[7].ConvertToInt() },
                TotalCollection = nodes[8].ConvertToDecimal(),
                Winners6Numbers = nodes[9].ConvertToInt(),
                City = nodes[10].ConvertEmptyToString(),
                UF = nodes[11].ConvertWithMetaChatToString(),
                Average6Numbers = nodes[12].ConvertToDecimal(),
                Winners5Numbers = nodes[13].ConvertToInt(),
                Average5Numbers = nodes[14].ConvertToDecimal(),
                Winners4Numbers = nodes[15].ConvertToInt(),
                Average4Numbers = nodes[16].ConvertToDecimal(),
                IsAccumulated = nodes[17].ConvertToBoolean(),
                AccumulatedPrize = nodes[18].ConvertToDecimal(),
                EstimatedPrize = nodes[19].ConvertToDecimal(),
                AccumulatedMegaSenaVirada = nodes[20].ConvertToDecimal()
            };
    }
}
