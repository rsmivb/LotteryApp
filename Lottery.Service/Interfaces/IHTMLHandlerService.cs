using System.Collections.Generic;

namespace Lottery.Services
{
    public interface IHtmlHandlerService
    {
        List<List<string>> LoadHtmlFile(string HtmlFilePath, int columnLimit);
    }
}