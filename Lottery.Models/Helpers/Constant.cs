using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lottery.Models
{
    public static class Constant
    {
        public const string HTML_EMPTY = "&nbsp";
        public const string YES = "SIM";
        public const string BR_DATE_FORMAT = "dd/MM/yyyy";
        public const char METACHAR_R = '\r';
        public const string DASH = "-";
        public const int ZERO = 0;
        public static CultureInfo Info = new CultureInfo("pt-BR");
    }
}
