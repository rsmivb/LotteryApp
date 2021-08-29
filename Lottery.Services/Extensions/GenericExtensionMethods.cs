using Lottery.Models;
using System;
using System.Linq;
using System.Reflection;

namespace Lottery.Services
{
    public static class GenericExtensionMethods
    {
        public static string ConvertEmptyToString(this string node) => node.Trim().Equals(Constants.HtmlEmpty) ? string.Empty : node.Trim();

        public static string ConvertWithMetaChatToString(this string node) => node.Trim().Equals(Constants.HtmlEmpty) ? string.Empty : node.Trim().Split(Constants.MetaChar_R)[0];

        public static decimal ConvertToDecimal(this string node) => node.Trim().Equals(string.Empty) || node.Trim().Equals(Constants.Dash) ? Constants.Zero : Decimal.Parse(node.Trim(), Constants.Info);

        public static DateTime ConvertToDateTime(this string node) => DateTime.ParseExact(node.Trim(), Constants.DateFormatBR, Constants.Info);

        public static int ConvertToInt(this string node) => node.Trim().Equals(string.Empty) ? Constants.Zero : Int32.Parse(node);

        public static bool ConvertToBoolean(this string node) => node.Trim().ToUpper().Equals(Constants.Yes);

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
        public static Type ConvertToExtensionsMethodsType(this string lotteryName) =>
            Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(method => method.Name
                                                    .Equals($"{lotteryName}ExtensionMethods")) ??
                                                throw new Exception($"Lottery {lotteryName} wasn't implemented.");
    }
}
