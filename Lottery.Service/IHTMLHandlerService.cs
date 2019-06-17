using System.Collections.Generic;
using System.IO;

namespace Lottery.Services
{
    public interface IHtmlHandlerService
    {
        List<List<string>> LoadHtmlFile(string HtmlFilePath, int columnLimit);
    }
}