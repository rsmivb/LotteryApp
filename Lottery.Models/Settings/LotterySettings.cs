using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Models
{
    public class LotterySetting
    {
        public string Name { get; set; }
        public int Columns { get; set; }
        public string WebService { get; set; }
        public string HtmlFileName { get; set; }
        public string ZipFileName { get; set; }
    }
}
