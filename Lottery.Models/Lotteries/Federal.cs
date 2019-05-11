using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models
{
    public class Federal : MongoModel
    {
        public int LotteryId { get; set; }
        public DateTime DateRealized { get; set; }
        public List<int> Dozens { get; set; }
        public decimal Prize1 { get; set; }
        public decimal Prize2 { get; set; }
        public decimal Prize3 { get; set; }
        public decimal Prize4 { get; set; }
        public decimal Prize5 { get; set; }

        public override string ToString()
        {
            return $"{{ {LotteryId}-{DateRealized}-[{string.Join(",", Dozens)}]-{Prize1}-{Prize2}-{Prize3}-{Prize4}-{Prize5} }}";
        }
    }

    public static class FederalExtensionMethods
    {
        public static IEnumerable<Federal> Load(List<List<string>> items)
        {
            foreach (var item in items)
            {
                yield return new Federal
                {
                    LotteryId = item[0].ConvertToInt(),
                    DateRealized = item[1].ConvertToDateTime(),
                    Dozens = new List<int> { item[2].ConvertToInt(),
                                     item[3].ConvertToInt(),
                                     item[4].ConvertToInt(),
                                     item[5].ConvertToInt(),
                                     item[6].ConvertToInt()}.OrderBy(c => c).ToList(),
                    Prize1 = item[7].ConvertToDecimal(),
                    Prize2 = item[8].ConvertToDecimal(),
                    Prize3 = item[9].ConvertToDecimal(),
                    Prize4 = item[10].ConvertToDecimal(),
                    Prize5 = item[11].ConvertToDecimal()
                };
            }
        }
    }
}
