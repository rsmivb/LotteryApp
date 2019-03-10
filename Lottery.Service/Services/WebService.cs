
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
        private readonly IFileHandler _fileHandler;

        public WebService(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public void DownloadFile(LotterySetting setting, string path)
        {
            try
            {
                if (setting == null) throw new ArgumentNullException("Object Lottery setting must not be null.");

                _fileHandler.CreateFolder(path);
                CookieContainer myContainer = new CookieContainer();
                var request = (HttpWebRequest)WebRequest.Create(setting.WebService);
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.CookieContainer = myContainer;
                var response = (HttpWebResponse)request.GetResponse();
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fileStream = new FileStream(Path.Combine(path, setting.ZipFileName), FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
