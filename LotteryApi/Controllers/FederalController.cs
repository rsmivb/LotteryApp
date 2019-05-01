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
    public class FederalController : Controller
    {
        private readonly AppSettings _settings;
        private readonly IWebService _webService;
        private readonly IRepository<Federal> _repository;
        private readonly ILogger<FederalController> _logger;

        public FederalController(AppSettings settings, IWebService webService, IRepository<Federal> repository, ILogger<FederalController> logger)
        {
            _settings = settings;
            _webService = webService;
            _repository = repository;
            _logger = logger;
        }
        // GET api/loteca/allLoteries
        [HttpGet("AllLoteries")]
        public IActionResult GetAllLoteries()
        {
            try
            {
                _logger.LogInformation("api/loteca/allLoteries - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/loteca/allLoteries - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }

        // GET api/loteca/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        public IActionResult GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/loteca/dozenByQuantity - Getting data from mongo database");
                var result = _repository.GetAll();
                var projectNumbers = _repository.GetAll() //get all megasena lottery entries
                                    .SelectMany(lottery => lottery.Dozens) //select all list of dozens
                                    .GroupBy(dozens => dozens) // group into a new list
                                    .Select(s => new { Dozen = s.Key, Quantity = s.Count() }) // runs each number and count it
                                    .OrderBy(o => o.Dozen); //order by ascending
                return Ok(projectNumbers);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/loteca/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        // GET api/loteca/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        public IActionResult DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("Get information from CEF server");
                //download file
                var setting = _settings.Lotteries.Where(lottery => lottery.Name == Constant.FEDERAL).SingleOrDefault();
                _webService.DownloadFile(setting,
                                         string.Concat(Environment.CurrentDirectory, _settings.TempFilePath));
                _logger.LogInformation("Load HTML file into Objects");
                //load file into object
                HTMLHandler handler = new HTMLHandler();
                var path = string.Concat(string.Concat(Environment.CurrentDirectory, _settings.TempFilePath), string.Concat($@"{setting.Name}\", setting.HtmlFileName));
                var results = (IEnumerable<Federal>)handler.LoadHTMLFile(path, setting);
                _logger.LogInformation("loading into database");
                _repository.CreateDatabase();
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
