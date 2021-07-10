using Lottery.Repository;
using System;
using System.Collections.Generic;

namespace Lottery.Models.Lotteries
{
    public class LotteryData
    {
        public string Name { get; set; }
        public Uri SenderUrlPath { get; set; }
        public string ZipPath { get; set; }
        public string HtmlFilePath { get; set; }
        public int Columns { get; set; }
        public IEnumerable<MongoModel> Entries { get; set; }
    }
}
