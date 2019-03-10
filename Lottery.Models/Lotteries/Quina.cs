using System;
using System.Collections.Generic;

namespace Lottery.Models
{
    public class Quina : MongoObject
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public int[] Dozens { get; set; }
        public decimal TotalAmount { get; set; }
        public int Winners5 { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public decimal Average5Numbers { get; set; }
        public int Winners4 { get; set; }
        public decimal Average4Numbers { get; set; }
        public int Winners3 { get; set; }
        public decimal Average3Numbers { get; set; }
        public int Winners2 { get; set; }
        public decimal Average2Numbers { get; set; }
        public bool IsAccumulated { get; set; }
        public decimal AccumulatedValue { get; set; }
        public decimal EstimatePrize { get; set; }
        public decimal AccumulatedSorteioSaoJoao { get; set; }

    }

    public static class QuinaExtensionMethods
    {
        public static Quina LoadQuina(IList<string> nodes) =>  new Quina
            {
                LotteryId = nodes[0].ConvertToInt(),
                DateRealized = nodes[1].ConvertToDateTime(),
                Dozens = new int[] { nodes[2].ConvertToInt(), nodes[3].ConvertToInt(),
                                             nodes[4].ConvertToInt(), nodes[5].ConvertToInt(),
                                             nodes[6].ConvertToInt() },
                TotalAmount = nodes[7].ConvertToDecimal(),
                Winners5 = nodes[8].ConvertToInt(),
                City = nodes[9].ConvertEmptyToString(),
                UF = nodes[10].ConvertWithMetaChatToString(),
                Average5Numbers = nodes[11].ConvertToDecimal(),
                Winners4 = nodes[12].ConvertToInt(),
                Average4Numbers = nodes[13].ConvertToDecimal(),
                Winners3 = nodes[14].ConvertToInt(),
                Average3Numbers = nodes[15].ConvertToDecimal(),
                Winners2 = nodes[16].ConvertToInt(),
                Average2Numbers = nodes[17].ConvertToDecimal(),
                IsAccumulated = nodes[18].ConvertToBoolean(),
                AccumulatedValue = nodes[19].ConvertToDecimal(),
                EstimatePrize = nodes[20].ConvertToDecimal(),
                AccumulatedSorteioSaoJoao = nodes[21].ConvertToDecimal()
            };
    }
}
