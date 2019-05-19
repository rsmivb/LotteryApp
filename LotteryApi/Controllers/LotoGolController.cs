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
    public class LotoGolController : Controller
    {
        private readonly IProcessLotteryService _webService;
        private readonly IRepository<LotoGol> _repository;
        private readonly ILogger<LotoGolController> _logger;
        private readonly ILotteryService _lotteryService;

        public LotoGolController(IProcessLotteryService webService,
            IRepository<LotoGol> repository,
            ILogger<LotoGolController> logger,
            ILotteryService lotteryService)
        {
            _webService = webService;
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
        }
        // GET api/lotogol/results
        [HttpGet("Results")]
        [SwaggerOperation(Summary = "Gets all results for LotoGol Lottery", Description = "This is a description examples")]
        public async Task<IActionResult> GetResults()
        {
            try
            {
                _logger.LogInformation("api/lotogol/results - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/lotogol/results - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        // GET api/lotogol/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        [SwaggerOperation(Summary = "Gets info from dozens by quantity", Description = "This is a description examples")]
        public async Task<IActionResult> GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/lotogol/dozenByQuantity - Getting data from mongo database");
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
                _logger.LogError($"api/lotogol/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        // GET api/lotogol/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        [SwaggerOperation(Summary = "Gets file from Caixa and load it into MongoDB", Description = "This is a description examples")]
        public async Task<IActionResult> DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("Get information from CEF server");
                //download file
                _webService.ProcessLotteryFile(Constants.LOTOGOL);
                _logger.LogInformation("Load HTML file into Objects");
                var results = (IEnumerable<LotoGol>)_lotteryService.Load(Constants.LOTOGOL);
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
