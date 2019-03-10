using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class LotoMania : MongoObject
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] Dozens { get; set; }
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
    }

    public static class LotoManiaExtensonMethods
    {
        public static LotoMania Load(IList<string> nodes) => new LotoMania
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Dozens = new int[] { nodes[2].ConvertToInt(),  nodes[3].ConvertToInt(),
                                     nodes[4].ConvertToInt(),  nodes[5].ConvertToInt(),
                                     nodes[6].ConvertToInt(),  nodes[7].ConvertToInt(),
                                     nodes[8].ConvertToInt(),  nodes[9].ConvertToInt(),
                                     nodes[10].ConvertToInt(), nodes[11].ConvertToInt(),
                                     nodes[12].ConvertToInt(), nodes[13].ConvertToInt(),
                                     nodes[14].ConvertToInt(), nodes[15].ConvertToInt(),
                                     nodes[16].ConvertToInt(), nodes[17].ConvertToInt(),
                                     nodes[18].ConvertToInt(), nodes[19].ConvertToInt(),
                                     nodes[20].ConvertToInt(), nodes[21].ConvertToInt()},
                TotalValue = nodes[22].ConvertToDecimal(),
                TotalWinners20 = nodes[23].ConvertToInt(),
                City = nodes[24].ConvertEmptyToString(),
                UF = nodes[25].ConvertEmptyToString(),
                TotalWinners19 = nodes[26].ConvertToInt(),
                TotalWinners18 = nodes[27].ConvertToInt(),
                TotalWinners17 = nodes[28].ConvertToInt(),
                TotalWinners16 = nodes[29].ConvertToInt(),
                TotalWinnersNoNumbers = nodes[30].ConvertToInt(),
                TotalValueNumbers20 = nodes[31].ConvertToDecimal(),
                TotalValueNumbers19 = nodes[32].ConvertToDecimal(),
                TotalValueNumbers18 = nodes[33].ConvertToDecimal(),
                TotalValueNumbers17 = nodes[34].ConvertToDecimal(),
                TotalValueNumbers16 = nodes[35].ConvertToDecimal(),
                TotalValueNoNumbers = nodes[36].ConvertToDecimal(),
                Acumulated20 = nodes[37].ConvertToDecimal(),
                Acumulated19 = nodes[38].ConvertToDecimal(),
                Acumulated18 = nodes[39].ConvertToDecimal(),
                Acumulated17 = nodes[40].ConvertToDecimal(),
                Acumulated16 = nodes[41].ConvertToDecimal(),
                AcumulatedNoNumbers = nodes[42].ConvertToDecimal(),
                PrizeEstimated = nodes[43].ConvertToDecimal(),
                SpecialPrizeEstimated = nodes[44].ConvertToDecimal()
            };
    }
}
