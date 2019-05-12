using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Models.Lotteries
{
    public class LotteryProcessedValue
    {
        //list of numbers
        public List<int> Values { get; set; }
        // numero de vezes que apareceu cada numero
        public IDictionary<int, int> DozenTimes { get; set; }
        // media dos valores pagos
        public decimal AveragePrize { get; set; }
        // media das pessoas que ganharam por estado
        public IDictionary<string, int> AverageByState { get; set; }

    }
}
