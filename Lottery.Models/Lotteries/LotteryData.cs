using Lottery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models.Lotteries
{
    public class LotteryData : IEquatable<LotteryData>
    {
        public string Name { get; set; }
        public string CaixaLotteryURL { get; set; }
        public string HtmlFilePath { get; set; }
        public int? Columns { get; set; }
        public List<MongoModel> Entries { get; set; }

        public override bool Equals(object obj) => Equals(obj as LotteryData);

        public bool Equals(LotteryData obj) => obj is LotteryData data &&
                   Name == data.Name &&
                   CaixaLotteryURL == data.CaixaLotteryURL &&
                   HtmlFilePath == data.HtmlFilePath &&
                   Columns == data.Columns &&
                   Entries.SequenceEqual(data.Entries);



        public override int GetHashCode() => HashCode.Combine(Name, CaixaLotteryURL, HtmlFilePath, Columns, Entries);

        public override string ToString() => $"{nameof(Name)}={Name}, {nameof(CaixaLotteryURL)}={CaixaLotteryURL},{nameof(HtmlFilePath)}={HtmlFilePath},{nameof(Columns)}={Columns},{nameof(Entries)}={Entries}";

    }
}
