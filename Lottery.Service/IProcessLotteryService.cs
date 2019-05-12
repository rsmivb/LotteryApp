namespace Lottery.Services
{
    public interface IProcessLotteryService
    {
        bool ProcessLotteryFile(string lotteryName);
    }
}