
using Lottery.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lottery.Services
{
    public class WebService : IWebService
    {
        private readonly IFileHandlerService _fileHandler;
        private readonly AppSettings _settings;

        public WebService(IFileHandlerService fileHandler, AppSettings settings)
        {
            _fileHandler = fileHandler;
            _settings = settings;
        }
        public void DownloadFile(string lotteryName)
        {
            try
            {
                var _setting = _settings.Lotteries.Where(l => l.Name.Equals(lotteryName)).FirstOrDefault();
                if (_setting == null) throw new ArgumentNullException("Object Lottery setting must not be null.");
                string path = string.Concat(Environment.CurrentDirectory, _settings.TempFilePath);
                _fileHandler.CreateFolder(path);

                CookieContainer myContainer = new CookieContainer();
                var request = (HttpWebRequest)WebRequest.Create(_setting.WebService);
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.CookieContainer = myContainer;
                var response = (HttpWebResponse)request.GetResponse();
                var filePath = Path.Combine(path, _setting.ZipFileName);
                var destinationPath = Path.Combine(path, _setting.Name);
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                _fileHandler.ExtractFile(path, destinationPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
