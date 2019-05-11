using Lottery.Models;
using System.Collections.Generic;

namespace Lottery.Services
{
    public interface ILotteryService
    {
        IEnumerable<MongoModel> ChooseLottery(List<List<string>> htmlLines, string lotteryName);
        IEnumerable<MongoModel> Load(string lotteryName);
    }
}
