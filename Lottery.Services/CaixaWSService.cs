using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace Lottery.Services
{
    public class CaixaWSService : ICaixaWSService
    {
        private readonly ILogger<ICaixaWSService> _logger;
        private readonly HttpClient _httpClient;

        public CaixaWSService(ILogger<ICaixaWSService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public string GetContent(string caixaLotteryUrl)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Cookie", "DigestTracker=AAABe0wQCss; JSESSIONID=000047SvUPv-19cArWUPIEDWJtZ:18l93egtr; security=true");
                using (var response = _httpClient.GetAsync(caixaLotteryUrl).Result)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to get file from {caixaLotteryUrl}. Message -> {e.Message}. StackTrace -> {e.StackTrace}.");
                throw;
            }
        }
    }
}
