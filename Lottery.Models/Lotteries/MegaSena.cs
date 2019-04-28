﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lottery.Models
{
    public class MegaSena : MongoModel
    {
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
        public static IEnumerable<MegaSena> Load(IList<IList<string>> items)
        {
            foreach (var item in items)
            {
                yield return new MegaSena
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new int[] { item[2].ConvertToInt(), item[3].ConvertToInt(),
                                     item[4].ConvertToInt(), item[5].ConvertToInt(),
                                     item[6].ConvertToInt(), item[7].ConvertToInt() },
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
