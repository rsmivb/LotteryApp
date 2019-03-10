using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class Federal : MongoObject
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] Dozens { get; set; }
        public decimal Prize1 { get; set; }
        public decimal Prize2 { get; set; }
        public decimal Prize3 { get; set; }
        public decimal Prize4 { get; set; }
        public decimal Prize5 { get; set; }
    }

    public static class FederalExtensionMethods
    {
        public static Federal Load(IList<string> nodes) => new Federal
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Dozens = new int[] { nodes[2].ConvertToInt(),
                                     nodes[3].ConvertToInt(),
                                     nodes[4].ConvertToInt(),
                                     nodes[5].ConvertToInt(),
                                     nodes[6].ConvertToInt()},
                Prize1 = nodes[7].ConvertToDecimal(),
                Prize2 = nodes[8].ConvertToDecimal(),
                Prize3 = nodes[9].ConvertToDecimal(),
                Prize4 = nodes[10].ConvertToDecimal(),
                Prize5 = nodes[11].ConvertToDecimal()
            };
    }
}
