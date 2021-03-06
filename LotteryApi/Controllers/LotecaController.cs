﻿using Lottery.Models;
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
    public class LotecaController : Controller
    {
        private readonly IProcessLotteryService _webService;
        private readonly IRepository<Loteca> _repository;
        private readonly ILogger<LotecaController> _logger;
        private readonly ILotteryService _lotteryService;
        /// <summary>
        ///
        /// </summary>
        /// <param name="webService"></param>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        /// <param name="lotteryService"></param>
        public LotecaController(IProcessLotteryService webService,
            IRepository<Loteca> repository,
            ILogger<LotecaController> logger,
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
        // GET api/loteca/results
        [HttpGet("Results")]
        [SwaggerOperation(Summary = "Gets all results for Loteca Lottery", Description = "This is a description examples")]
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
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/loteca/dozenByQuantity
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
                                                            //.ToDictionary(d => d.Number, d => d.Quantity); // project into dictionary list
                return Ok(projectNumbers);
            }
            catch (Exception e)
            {
                _logger.LogError($"api/loteca/dozenByQuantity - Error when try to get data from database. -> {e.Message} - {e.StackTrace}");
                return NotFound("Error getting data.");
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        // GET api/loteca/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        [SwaggerOperation(Summary = "Gets file from Caixa and load it into MongoDB", Description = "This is a description examples")]
        public async Task<IActionResult> DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("api/loteca/downloadResultsFromSource - Get information from CEF server");
                //download file
                _webService.ProcessLotteryFile(Constants.LOTECA);
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
