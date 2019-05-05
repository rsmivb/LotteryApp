﻿using System;
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
    public class TimeManiaController : Controller
    {
        private readonly IWebService _webService;
        private readonly IRepository<TimeMania> _repository;
        private readonly ILogger<TimeManiaController> _logger;
        private readonly ILotteryService _lotteryService;

        public TimeManiaController( IWebService webService,
            IRepository<TimeMania> repository,
            ILogger<TimeManiaController> logger,
            ILotteryService lotteryService)
        {
            _webService = webService;
            _repository = repository;
            _logger = logger;
            _lotteryService = lotteryService;
        }
        // GET api/timemania/allLoteries
        [HttpGet("AllLoteries")]
        public IActionResult GetAllLoteries()
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

        // GET api/timemania/dozenByQuantity
        [HttpGet("DozenByQuantity")]
        public IActionResult GetDozenByQuantity()
        {
            try
            {
                _logger.LogInformation("api/timemania/dozenByQuantity - Getting data from mongo database");
                var result = _repository.GetAll();
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
        // GET api/timemania/downloadResultsFromSource
        [HttpGet("DownloadResultsFromSource")]
        public IActionResult DownloadResultsFromSource()
        {
            try
            {
                _logger.LogInformation("Get information from CEF server");
                //download file
                _webService.DownloadFile(Constant.TIMEMANIA);

                _logger.LogInformation("Load HTML file into Objects");
                var results = (IEnumerable<TimeMania>)_lotteryService.Load(Constant.TIMEMANIA);
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
