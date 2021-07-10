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

        public override bool Equals(object obj) => obj is LotteryData data &&
                   Name == data.Name &&
                   EqualityComparer<Uri>.Default.Equals(SenderUrlPath, data.SenderUrlPath) &&
                   ZipPath == data.ZipPath &&
                   HtmlFilePath == data.HtmlFilePath &&
                   Columns == data.Columns;

        public override int GetHashCode() => HashCode.Combine(Name, SenderUrlPath, ZipPath, HtmlFilePath, Columns);

        public override string ToString() => $"{nameof(Name)}={Name}, {nameof(SenderUrlPath)}={SenderUrlPath.AbsoluteUri},{nameof(ZipPath)}={ZipPath},{nameof(HtmlFilePath)}={HtmlFilePath},{nameof(Columns)}={Columns}";

    }
}
