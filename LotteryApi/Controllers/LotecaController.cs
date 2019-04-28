using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotteryApi.Controllers
{
    [Route("api/[controller]")]
    public class LotecaController : Controller
    {
        private readonly AppSettings _settings;
        private readonly IWebService _webService;
        private readonly IRepository<Loteca> _repository;
        private readonly ILogger<LotecaController> _logger;

        public LotecaController(AppSettings settings, IWebService webService, IRepository<Loteca> repository, ILogger<LotecaController> logger)
        {
            _settings = settings;
            _webService = webService;
            _repository = repository;
            _logger = logger;
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
                _logger.LogInformation("Get information from CEF server");
                //download file
                var setting = _settings.Lotteries.Where(lottery => lottery.Name == Constant.LOTECA).SingleOrDefault();
                _webService.DownloadFile(setting,
                                         string.Concat(Environment.CurrentDirectory, _settings.TempFilePath));
                _logger.LogInformation("Load HTML file into Objects");
                //load file into object
                HTMLHandler handler = new HTMLHandler();
                var path = string.Concat(string.Concat(Environment.CurrentDirectory, _settings.TempFilePath), string.Concat($@"{setting.Name}\", setting.HtmlFileName));
                var results = (IEnumerable<Loteca>)handler.LoadHTMLFile(path, setting);
                _logger.LogInformation("loading into database");
                _repository.InsertMany(results);
                return Ok("Loaded itens on database.");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to call DownloadResultsFromSource {e.Message} - {e.StackTrace}");
                return BadRequest("An error was found.");
            }
        }
    }
}
