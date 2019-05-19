using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace LotteryApi.Controllers
{
    [Route("api/[controller]")]
    public class DuplaSenaController : Controller
    {
        private readonly IProcessLotteryService _webService;
        private readonly IRepository<DuplaSena> _repository;
        private readonly ILogger<DuplaSenaController> _logger;
        private readonly ILotteryService _lotteryService;

        public DuplaSenaController(IProcessLotteryService webService,
                                    IRepository<DuplaSena> repository,
                                    ILogger<DuplaSenaController> logger,
                                    ILotteryService lotteryService)
        {
            _webService = webService;
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
        }
        // GET api/duplasena/results
        /// <summary>
        /// It gets information for all DuplaSena results
        /// </summary>
        /// <returns>All DuplaSena results </returns>
        [HttpGet("Results")]
        [SwaggerOperation(Summary = "Gets all results for DuplaSena Lottery", Description = "This is a description examples")]
        //[SwaggerResponse(200, "I guess everything worked")]
        //[SwaggerResponse(400, "BAD REQUUUUEST")]
        public async Task<IActionResult> GetResults()
        {
            try
            {
                _logger.LogInformation("api/duplasena/results - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/duplasena/results - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }

        // GET api/duplasena/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        [SwaggerOperation(Summary = "Gets info from dozens by quantity", Description = "This is a description examples")]
        public IActionResult GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/duplasena/dozenByQuantity - Getting data from mongo database");
                var projectNumbers1 = _repository.GetAll() //get all megasena lottery entries
                                    .SelectMany(lottery => lottery.DozensRound1) //select all list of dozens
                                    .GroupBy(dozens => dozens) // group into a new list
                                    .Select(s => new { Dozen = s.Key, Quantity = s.Count() }) // runs each number and count it
                                    .OrderBy(o => o.Dozen); //order by ascending
                var projectNumbers2 = _repository.GetAll()
                                                    .SelectMany(lottery => lottery.DozensRound2)
                                                    .GroupBy(dozens => dozens)
                                                    .Select(s => new { Dozen = s.Key, Quantity = s.Count() })
                                                    .OrderBy(o => o.Dozen);
                var list = new
                {
                    DozensRound1 = projectNumbers1,
                    DozensRound2 = projectNumbers2
                };
                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/duplasena/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        // GET api/duplasena/downloadResultsFromSource
        [SwaggerOperation(Summary = "Gets file from Caixa and load it into MongoDB", Description = "This is a description examples")]
        [HttpGet("DownloadResultsFromSource")]
        public IActionResult DownloadResultsFromSource()
        {
            try
            {
                // TODO: move to background job using Hangfire
                //https://jonhilton.net/simple-background-jobs-with-hangfire-and-aspnet-core/
                //https://www.hangfire.io/
                _logger.LogInformation("Get information from CEF server");
                _webService.ProcessLotteryFile(Constants.DUPLASENA);
                _logger.LogInformation("Load HTML file into Objects");
                var results = (IEnumerable<DuplaSena>)_lotteryService.Load(Constants.DUPLASENA);
                _logger.LogInformation("loading into database");
                _repository.CreateDatabase();
                _repository.InsertMany(results);
                return Ok("Loaded itens on database.");
            }
            catch (Exception e)
            {
                _logger.LogError($"Error when try to call DownloadResultsFromSource {e.Message} - {e.StackTrace}");
                return NotFound("An error was found.");
            }
        }
    }
}
