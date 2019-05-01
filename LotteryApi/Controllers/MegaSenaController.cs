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
    public class MegaSenaController : Controller
    {
        private readonly AppSettings _settings;
        private readonly IWebService _webService;
        private readonly IRepository<MegaSena> _repository;
        private readonly ILogger<MegaSenaController> _logger;

        public MegaSenaController(AppSettings settings, IWebService webService, IRepository<MegaSena> repository, ILogger<MegaSenaController> logger)
        {
            _settings = settings;
            _webService = webService;
            _repository = repository;
            _logger = logger;
        }
        // GET api/megasena/allLoteries
        [HttpGet("AllLoteries")]
        public IActionResult GetAllLoteries()
        {
            try
            {
                _logger.LogInformation("api/megasena/allLoteries - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/megasena/allLoteries - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }

        // GET api/megasena/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        public IActionResult GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/megasena/dozenByQuantity - Getting data from mongo database");
                var result = _repository.GetAll();
                //        i.SelectMany(s => s.Many).GroupBy(g => g)
                //.Select(s => new { Key = s.Key, Count = s.Count() })
                //.OrderBy(o => o.Key)
                //.ToDictionary(d => d.Key, d => d.Count);
                var projectNumbers = _repository.GetAll() //get all megasena lottery entries
                                    .SelectMany(lottery => lottery.Dozens) //select all list of dozens
                                    .GroupBy(dozens => dozens) // group into a new list
                                    .Select(s => new { Dozen = s.Key, Quantity = s.Count() }) // runs each number and count it
                                    .OrderBy(o => o.Dozen); //order by ascending
                                    //.ToDictionary(d => d.Number, d => d.Quantity); // project into dictionary list
                return Ok(projectNumbers);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/megasena/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        // GET api/megasena/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        public IActionResult DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("api/megasena/downloadResultsFromSource - Downloading from web service.");
                var setting = _settings.Lotteries.Where(lottery => lottery.Name == Constant.MEGASENA).SingleOrDefault();
                _webService.DownloadFile(setting,
                                         string.Concat(Environment.CurrentDirectory, _settings.TempFilePath));
                _logger.LogInformation("api/megasena/downloadResultsFromSource - Load HTML file into Objects");
                //load file into object
                HTMLHandler handler = new HTMLHandler();
                var path = string.Concat(string.Concat(Environment.CurrentDirectory, _settings.TempFilePath), string.Concat($@"{setting.Name}\", setting.HtmlFileName));
                var results = (IEnumerable<MegaSena>)handler.LoadHTMLFile(path, setting);
                _logger.LogInformation("api/megasena/downloadResultsFromSource - loading into database");
                _repository.CreateDatabase();
                _repository.InsertMany(results);

                return Ok("All items have been loaded to database.");
            }
            catch (Exception e)
            {
                _logger.LogError($"api/megasena/downloadResultsFromSource - Error when try to call DownloadResultsFromSource {e.Message} - {e.StackTrace}");
                return BadRequest("An error was found.");
            }
        }
    }
}
