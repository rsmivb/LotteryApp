using System.Collections.Generic;

namespace Lottery.Models
{
    public class AppSettings
    {
        public string TempFilePath { get; set; }
        public IEnumerable<LotterySetting> Lotteries { get; set; }
    }
}
