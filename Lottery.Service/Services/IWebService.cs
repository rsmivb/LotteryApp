using System.IO;

namespace Lottery.Services
{
    public interface IWebService
    {
        bool DownloadFile(string lotteryName);
        Stream GetStreamFileFromWebService(string lotteryWebServiceUrl);
    }
}