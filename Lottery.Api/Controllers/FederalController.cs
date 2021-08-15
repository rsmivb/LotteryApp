using Lottery.Models;
using Lottery.Repository;
using Lottery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Api.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/[controller]")]
    public class FederalController : Controller
    {
        private readonly IRepository<Federal> _repository;
        private readonly ILogger<FederalController> _logger;
        private readonly ILotteryService _lotteryService;
        /// <summary>
        ///
        /// </summary>
        /// <param name="webService"></param>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="lotteryService"></param>
        public FederalController(IRepository<Federal> repository,
                                    ILogger<FederalController> logger,
                                    ILotteryService lotteryService)
        {
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
        }
        // GET api/loteca/allLoteries
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("Results")]
        [SwaggerOperation(Summary = "Gets all results for Federal Lottery", Description = "This is a description examples")]
        public async Task<IActionResult> GetResults()
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
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("DozenByQuantity")]
        [SwaggerOperation(Summary = "Gets info from dozens by quantity", Description = "This is a description examples")]
        public async Task<IActionResult> GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/loteca/dozenByQuantity - Getting data from mongo database");
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
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet("DownloadResultsFromSource")]
        [SwaggerOperation(Summary = "Gets file from Caixa and load it into MongoDB", Description = "This is a description examples")]
        public async Task<IActionResult> DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("Get information from CEF server");
                //download file
                //_webService.ProcessLotteryFile(Constants.Federal);
                _logger.LogInformation("Load HTML file into Objects");
                //load file into object
                //var results = (IEnumerable<Federal>)_lotteryService.Load(Constants.Federal);
                _logger.LogInformation("loading into database");
                //_repository.CreateDatabase();
                //_repository.InsertMany(results);

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
