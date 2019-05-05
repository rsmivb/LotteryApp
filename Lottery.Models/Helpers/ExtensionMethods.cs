using System;
using System.Text;

namespace Lottery.Models
{
    public static class ExtensionMethods
    {
        public static string ConvertEmptyToString(this string node) => node.Trim().Equals(Constant.HTML_EMPTY) ? string.Empty : node.Trim();

        public static string ConvertWithMetaChatToString(this string node) => node.Trim().Equals(Constant.HTML_EMPTY) ? string.Empty : node.Trim().Split(Constant.METACHAR_R)[0];

        public static decimal ConvertToDecimal(this string node) => node.Trim().Equals(string.Empty) || node.Trim().Equals(Constant.DASH) ? Constant.ZERO : Decimal.Parse(node.Trim(), Constant.Info);

        public static DateTime ConvertToDateTime(this string node) => DateTime.ParseExact(node.Trim(), Constant.BR_DATE_FORMAT, Constant.Info);

        public static int ConvertToInt(this string node) => node.Trim().Equals(string.Empty) ? Constant.ZERO : Int32.Parse(node);

        public static bool ConvertToBoolean(this string node) => node.Trim().ToUpper().Equals(Constant.YES) ? true : false;

        public static char ConvertToChar(this string node)
        {
            try
            {
                return Char.Parse(node.Trim());
            }
            catch (Exception)
            {
                return Char.Parse(string.Empty);
            }
        }
    }
}
