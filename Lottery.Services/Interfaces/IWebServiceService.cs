using System;
using System.IO;

namespace Lottery.Services
{
    public interface IWebServiceService
    {
        Stream GetStreamFileFromWebService(Uri lotteryWebServiceUrl);
    }
}