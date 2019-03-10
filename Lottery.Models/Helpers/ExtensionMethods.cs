using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Models
{
    public static class ExtensionMethods
    {
        public static string ConvertEmptyToString(this string node) => node.Equals(Constant.HTML_EMPTY) ? string.Empty : node;

        public static string ConvertWithMetaChatToString(this string node) => node.Equals(Constant.HTML_EMPTY) ? string.Empty : node.Split(Constant.METACHAR_R)[0];

        public static decimal ConvertToDecimal(this string node) => node.Equals(string.Empty) || node.Equals(Constant.DASH) ? Constant.ZERO : Decimal.Parse(node, Constant.Info);

        public static DateTime ConvertToDateTime(this string node) => DateTime.ParseExact(node, Constant.BR_DATE_FORMAT, Constant.Info);

        public static int ConvertToInt(this string node) => node.Equals(string.Empty) ? Constant.ZERO : Int32.Parse(node);

        public static bool ConvertToBoolean(this string node) => node.ToUpper().Equals(Constant.YES) ? true : false;

        public static char ConvertToChar(this string node) => Char.Parse(node);
    }
}
