using Lottery.Models.Lotteries;
using System.Collections.Generic;

namespace Lottery.Services
{
    public interface IHtmlHandlerService
    {
        List<List<string>> ConvertHtmlTo(LotteryData lottery);
    }
}