
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

        public WebService(IFileHandlerService fileHandler)
        {
            _fileHandler = fileHandler;
        }

        private void CreateFolder(string path)
        {
            _fileHandler.CreateFolder(path);
        }

        private void ExtractFile(string path, string destinationPath)
        {
            _fileHandler.ExtractFile(path, destinationPath);
        }

        public void DownloadFile(LotterySetting setting, string path)
        {
            try
            {
                if (setting == null) throw new ArgumentNullException("Object Lottery setting must not be null.");
                CreateFolder(path);

                CookieContainer myContainer = new CookieContainer();
                var request = (HttpWebRequest)WebRequest.Create(setting.WebService);
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.CookieContainer = myContainer;
                var response = (HttpWebResponse)request.GetResponse();
                var filePath = Path.Combine(path, setting.ZipFileName);
                var destinationPath = Path.Combine(path, setting.Name);
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        responseStream.CopyTo(fileStream);
                    }
                }
                ExtractFile(filePath, destinationPath);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
