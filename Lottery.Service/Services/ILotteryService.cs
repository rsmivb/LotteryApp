using Lottery.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Services
{
    public interface ILotteryService
    {
        IEnumerable<MongoModel> ChooseLottery(List<List<string>> htmlLines, string lotteryName);
        IEnumerable<MongoModel> Load(string lotteryName);
    }
}
