using System.Collections.Generic;
using System.IO;

namespace Lottery.Services
{
    public interface IHTMLHandlerService
    {
        List<List<string>> LoadHTMLFile(string HtmlFilePath, int columnLimit);
    }
}