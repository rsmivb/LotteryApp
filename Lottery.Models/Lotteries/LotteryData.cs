using Lottery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery.Models.Lotteries
{
    public class LotteryData : IEquatable<LotteryData>
    {
        public string Name { get; set; }
        public Uri SenderUrlPath { get; set; }
        public string ZipPath { get; set; }
        public string HtmlFilePath { get; set; }
        public int? Columns { get; set; }
        public List<MongoModel> Entries { get; set; }

        public override bool Equals(object obj) => Equals(obj as LotteryData);

        public bool Equals(LotteryData obj) => obj is LotteryData data &&
                   Name == data.Name &&
                   EqualityComparer<Uri>.Default.Equals(SenderUrlPath, data.SenderUrlPath) &&
                   ZipPath == data.ZipPath &&
                   HtmlFilePath == data.HtmlFilePath &&
                   Columns == data.Columns &&
                   Entries.SequenceEqual(data.Entries);



        public override int GetHashCode() => HashCode.Combine(Name, SenderUrlPath, ZipPath, HtmlFilePath, Columns, Entries);

        public override string ToString() => $"{nameof(Name)}={Name}, {nameof(SenderUrlPath)}={SenderUrlPath?.AbsoluteUri},{nameof(ZipPath)}={ZipPath},{nameof(HtmlFilePath)}={HtmlFilePath},{nameof(Columns)}={Columns},{nameof(Entries)}={Entries}";

    }
}
