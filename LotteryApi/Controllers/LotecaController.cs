using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IWebService _webService;
        private readonly IRepository<Loteca> _repository;
        private readonly ILogger<LotecaController> _logger;
        private readonly ILotteryService _lotteryService;

        public LotecaController(IWebService webService,
            IRepository<Loteca> repository,
            ILogger<LotecaController> logger,
            ILotteryService lotteryService)
        {
            _webService = webService;
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
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
                                                            //.ToDictionary(d => d.Number, d => d.Quantity); // project into dictionary list
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
                _logger.LogInformation("api/loteca/downloadResultsFromSource - Get information from CEF server");
                //download file
                _webService.DownloadFile(Constants.LOTECA);
                _logger.LogInformation("api/loteca/downloadResultsFromSource - Load HTML file into Objects");
                //load file into object
                var results = (IEnumerable<Loteca>)_lotteryService.Load(Constants.LOTECA);
                _logger.LogInformation("loading into database");
                _repository.CreateDatabase();
                _repository.InsertMany(results);
                return Ok("Loaded itens on database.");
            }
            catch (Exception e)
            {
                _logger.LogError($"api/loteca/downloadResultsFromSource - Error when try to call DownloadResultsFromSource {e.Message} - {e.StackTrace}");
                return NotFound("An error was found.");
            }
        }
    }
}
