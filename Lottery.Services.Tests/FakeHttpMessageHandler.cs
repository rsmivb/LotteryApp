using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lottery.Services.Tests
{
    internal class FakeHttpMessageHandler : DelegatingHandler
    {
        private List<HttpResponseMessage> _httpResponseMessages;

        public FakeHttpMessageHandler(List<HttpResponseMessage> httpResponseMessages)
        {
            _httpResponseMessages = httpResponseMessages;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = _httpResponseMessages.FirstOrDefault();
            if (response != null)
                _httpResponseMessages.Remove(response);
            return await Task.FromResult(response);
        }
    }
}
