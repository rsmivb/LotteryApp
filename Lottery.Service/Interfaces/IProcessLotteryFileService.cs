using Lottery.Models.Lotteries;

namespace Lottery.Services
{
    public interface IProcessLotteryFileService
    {
        bool Execute(LotteryData lottery);
    }
}