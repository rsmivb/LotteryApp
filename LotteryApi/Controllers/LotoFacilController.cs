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
    public class LotoFacilController : Controller
    {
        private readonly IWebService _webService;
        private readonly IRepository<LotoFacil> _repository;
        private readonly ILogger<LotoFacilController> _logger;
        private readonly ILotteryService _lotteryService;

        public LotoFacilController(IWebService webService,
            IRepository<LotoFacil> repository,
            ILogger<LotoFacilController> logger,
            ILotteryService lotteryService)
        {
            _webService = webService;
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
        }
        // GET api/lotofacil/allLoteries
        [HttpGet("AllLoteries")]
        public IActionResult GetAllLoteries()
        {
            try
            {
                _logger.LogInformation("api/lotofacil/allLoteries - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/lotofacil/allLoteries - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }

        // GET api/lotofacil/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        public IActionResult GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/lotofacil/dozenByQuantity - Getting data from mongo database");
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
                _logger.LogError($"api/lotofacil/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        // GET api/lotofacil/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        public IActionResult DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("api/lotofacil/downloadResultsFromSource - Get information from CEF server");
                //download file
                _webService.DownloadFile(Constants.LOTOFACIL);
                _logger.LogInformation("api/lotofacil/downloadResultsFromSource - Load HTML file into Objects");
                //load file into object
                var results = (IEnumerable<LotoFacil>)_lotteryService.Load(Constants.LOTOFACIL);
                _logger.LogInformation("loading into database");
                _repository.CreateDatabase();
                _repository.InsertMany(results);
                return Ok("Loaded itens on database.");
            }
            catch (Exception e)
            {
                _logger.LogError($"api/lotofacil/downloadResultsFromSource - Error when try to call DownloadResultsFromSource {e.Message} - {e.StackTrace}");
                return NotFound("An error was found.");
            }
        }
    }
}
