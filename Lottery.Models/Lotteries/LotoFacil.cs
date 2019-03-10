using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class LotoFacil : MongoObject
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public int Winners15 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public int Winners14 { get; set; }
        public int Winners13 { get; set; }
        public int Winners12 { get; set; }
        public int Winners11 { get; set; }
        public decimal AverageAmount15 { get; set; }
        public decimal AverageAmount14 { get; set; }
        public decimal AverageAmount13 { get; set; }
        public decimal AverageAmount12 { get; set; }
        public decimal AverageAmount11 { get; set; }
        public decimal Accumulated15 { get; set; }
        public decimal EstimatedPrize { get; set; }
        public decimal SpecialAmount { get; set; }
    }

    public static class LotoFacilExtensionMethods
    {
        public static LotoFacil Load(IList<string> nodes) => new LotoFacil
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Dozens = new int[] { nodes[2].ConvertToInt(),
                                     nodes[3].ConvertToInt(),
                                     nodes[4].ConvertToInt(), nodes[5].ConvertToInt(),
                                     nodes[6].ConvertToInt(), nodes[7].ConvertToInt(),
                                     nodes[8].ConvertToInt(), nodes[9].ConvertToInt(),
                                     nodes[10].ConvertToInt(), nodes[11].ConvertToInt(),
                                     nodes[12].ConvertToInt(), nodes[13].ConvertToInt(),
                                     nodes[14].ConvertToInt(), nodes[15].ConvertToInt(), nodes[16].ConvertToInt()},
                TotalAmount = nodes[17].ConvertToDecimal(),
                Winners15 = nodes[18].ConvertToInt(),
                City = nodes[19].ConvertEmptyToString(),
                UF = nodes[20].ConvertWithMetaChatToString(),
                Winners14 = nodes[21].ConvertToInt(),
                Winners13 = nodes[22].ConvertToInt(),
                Winners12 = nodes[23].ConvertToInt(),
                Winners11 = nodes[24].ConvertToInt(),
                AverageAmount15 = nodes[25].ConvertToDecimal(),
                AverageAmount14 = nodes[26].ConvertToDecimal(),
                AverageAmount13 = nodes[27].ConvertToDecimal(),
                AverageAmount12 = nodes[28].ConvertToDecimal(),
                AverageAmount11 = nodes[29].ConvertToDecimal(),
                Accumulated15 = nodes[30].ConvertToDecimal(),
                EstimatedPrize = nodes[31].ConvertToDecimal(),
                SpecialAmount = nodes[32].ConvertToDecimal()
            };
    }
}
