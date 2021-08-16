using System;
using System.IO;

namespace Lottery.Services
{
    public interface ICaixaWSService
    {
        string GetContent(string caixaLotteryUrl);
    }
}