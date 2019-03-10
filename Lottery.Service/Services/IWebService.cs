using Lottery.Models;

namespace Lottery.Services
{
    public interface IWebService
    {
        void DownloadFile(LotterySetting setting, string partialPath);
    }
}