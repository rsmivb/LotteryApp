using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Models
{
    public class AppSettings
    {
        public string TempFilePath { get; set; }
        public Database Database { get; set; }
        public IEnumerable<LotterySetting> Lotteries { get; set; }
    }
}
