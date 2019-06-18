using System;

namespace Lottery.Models
{
    public static class ExtensionMethods
    {
        public static string ConvertEmptyToString(this string node) => node.Trim().Equals(Constants.HTML_EMPTY) ? string.Empty : node.Trim();

        public static string ConvertWithMetaChatToString(this string node) => node.Trim().Equals(Constants.HTML_EMPTY) ? string.Empty : node.Trim().Split(Constants.METACHAR_R)[0];

        public static decimal ConvertToDecimal(this string node) => node.Trim().Equals(string.Empty) || node.Trim().Equals(Constants.DASH) ? Constants.ZERO : Decimal.Parse(node.Trim(), Constants.Info);

        public static DateTime ConvertToDateTime(this string node) => DateTime.ParseExact(node.Trim(), Constants.BR_DATE_FORMAT, Constants.Info);

        public static int ConvertToInt(this string node) => node.Trim().Equals(string.Empty) ? Constants.ZERO : Int32.Parse(node);

        public static bool ConvertToBoolean(this string node) => node.Trim().ToUpper().Equals(Constants.YES);

        public static string ConvertToAChar(this string node)
        {
            try
            {
                return node.Substring(0,1);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
