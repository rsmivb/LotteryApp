using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryApi.Controllers
{
    [Route("api/[controller]")]
    public class LotecaController : Controller
    {
        private readonly AppSettings _settings;
        private readonly IWebService _webService;

        public LotecaController(AppSettings settings, IWebService webService)
        {
            _settings = settings;
            _webService = webService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("DownloadResultsFromSource")]
        public IActionResult DownloadResultsFromSource()
        {
            try
            {
                _webService.DownloadFile(_settings.Lotteries.Where(lottery => lottery.Name == "Loteca").SingleOrDefault(),
                                         string.Concat(Environment.CurrentDirectory, _settings.TempFilePath));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
