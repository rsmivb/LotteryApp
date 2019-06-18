using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;

namespace Lottery.Services
{
    public class WebServiceService : IWebServiceService
    {
        private readonly ILogger<IWebServiceService> _logger;

        public WebServiceService(ILogger<IWebServiceService> logger)
        {
            _logger = logger;
        }
        public Stream GetStreamFileFromWebService(string lotteryWebServiceUrl)
        {
            try
            {
                _logger.LogDebug($"Connecting with web service url: {lotteryWebServiceUrl}.");
                CookieContainer myContainer = new CookieContainer();
                var request = WebRequest.CreateHttp(lotteryWebServiceUrl);
                request.MaximumAutomaticRedirections = 1;
                request.AllowAutoRedirect = true;
                request.CookieContainer = myContainer;
                return request.GetResponse().GetResponseStream();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to get file from url {lotteryWebServiceUrl}. Message -> {e.Message}. StackTrace -> {e.StackTrace}.");
                throw;
            }
        }
    }
}
