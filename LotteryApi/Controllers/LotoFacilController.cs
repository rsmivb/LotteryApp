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
    public class LotoFacilController : Controller
    {
        private readonly IProcessLotteryService _webService;
        private readonly IRepository<LotoFacil> _repository;
        private readonly ILogger<LotoFacilController> _logger;
        private readonly ILotteryService _lotteryService;
        /// <summary>
        ///
        /// </summary>
        /// <param name="webService"></param>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="lotteryService"></param>
        public LotoFacilController(IProcessLotteryService webService,
            IRepository<LotoFacil> repository,
            ILogger<LotoFacilController> logger,
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
        // GET api/lotofacil/results
        [HttpGet("Results")]
        [SwaggerOperation(Summary = "Gets all results for LotoFacil Lottery", Description = "This is a description examples")]
        public async Task<IActionResult> GetResults()
        {
            try
            {
                _logger.LogInformation("api/lotofacil/results - Getting data from mongo database");
                var result = _repository.GetAll();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/lotofacil/results - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/lotofacil/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        [SwaggerOperation(Summary = "Gets info from dozens by quantity", Description = "This is a description examples")]
        public async Task<IActionResult> GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/lotofacil/dozenByQuantity - Getting data from mongo database");
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
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/lotofacil/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        [SwaggerOperation(Summary = "Gets file from Caixa and load it into MongoDB", Description = "This is a description examples")]
        public async Task<IActionResult> DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("api/lotofacil/downloadResultsFromSource - Get information from CEF server");
                //download file
                _webService.ProcessLotteryFile(Constants.LOTOFACIL);
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
