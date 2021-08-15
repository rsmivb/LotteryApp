using System;
using System.Linq;
using System.Reflection;

namespace Lottery.Services.Extensions.Lotteries
{
    public static class GenericExtensions
    {
        public static Type GetLotteryType(this string lotteryName)
        {
            return Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .FirstOrDefault(method => method.Name.Equals($"{lotteryName}ExtensionMethods")) ?? throw new Exception($"Lottery {lotteryName} wasn't implemented.");
        }
    }
}
