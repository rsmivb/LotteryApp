using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    public class TimeManiaController : Controller
    {
        private readonly IProcessLotteryService _webService;
        private readonly IRepository<TimeMania> _repository;
        private readonly ILogger<TimeManiaController> _logger;
        private readonly ILotteryService _lotteryService;
        /// <summary>
        ///
        /// </summary>
        /// <param name="webService"></param>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="lotteryService"></param>
        public TimeManiaController(IProcessLotteryService webService,
            IRepository<TimeMania> repository,
            ILogger<TimeManiaController> logger,
            ILotteryService lotteryService)
        {
            _webService = webService;
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/timemania/results
        [HttpGet("Results")]
        [SwaggerOperation(Summary = "Gets all results for TimeMania Lottery", Description = "This is a description examples")]
        public async Task<IActionResult> GetResults()
        {
            try
            {
                _logger.LogInformation("api/timemania/allLoteries - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/timemania/allLoteries - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/timemania/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        [SwaggerOperation(Summary = "Gets info from dozens by quantity", Description = "This is a description examples")]
        public async Task<IActionResult> GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/timemania/dozenByQuantity - Getting data from mongo database");
                var projectNumbers1 = _repository.GetAll() //get all megasena lottery entries
                                    .SelectMany(lottery => lottery.Dozens) //select all list of dozens
                                    .GroupBy(dozens => dozens) // group into a new list
                                    .Select(s => new { Dozen = s.Key, Quantity = s.Count() }) // runs each number and count it
                                    .OrderBy(o => o.Dozen); //order by ascending
                var projectTeams = _repository.GetAll() //get all megasena lottery entries
                                                    .SelectMany(lottery => lottery.Team) //select all list of dozens
                                                    .GroupBy(teams => teams) // group into a new list
                                                    .Select(s => new { TeamName = s.Key, Quantity = s.Count() }) // runs each number and count it
                                                    .OrderBy(o => o.TeamName); //order by ascending
                var list = new
                {
                    Dozens = projectNumbers1,
                    Teams = projectTeams
                };
                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/timemania/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/timemania/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        [SwaggerOperation(Summary = "Gets file from Caixa and load it into MongoDB", Description = "This is a description examples")]
        public async Task<IActionResult> DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("Get information from CEF server");
                //download file
                _webService.ProcessLotteryFile(Constants.TIMEMANIA);

                _logger.LogInformation("Load HTML file into Objects");
                var results = (IEnumerable<TimeMania>)_lotteryService.Load(Constants.TIMEMANIA);
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
