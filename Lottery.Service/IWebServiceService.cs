using System.IO;

namespace Lottery.Services
{
    public interface IWebServiceService
    {
        Stream GetStreamFileFromWebService(string lotteryWebServiceUrl);
    }
}