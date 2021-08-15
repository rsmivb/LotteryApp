using Lottery.Models.Lotteries;
using System.Collections.Generic;

namespace Lottery.Services
{
    public interface ILotteryService
    {
        LotteryData Load(List<List<string>> htmlLines, LotteryData lotteryData);
    }
}
