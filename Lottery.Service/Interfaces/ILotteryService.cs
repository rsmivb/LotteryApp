using Lottery.Models.Lotteries;

namespace Lottery.Services
{
    public interface ILotteryService
    {
        LotteryData Load(LotteryData lottery);
    }
}
