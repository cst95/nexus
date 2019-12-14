﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexus.Model.RiotApi;
 using Nexus.Service.Interfaces;

 namespace Nexus.API.Controllers
{
    [ApiController]
    [Route("[controller]/{platform}")]
    public class SummonersController : ControllerBase
    {
        private readonly ISummonerService _summonerService;
        private readonly ILogger<SummonersController> _logger;

        public SummonersController(ISummonerService summonerService, ILogger<SummonersController> logger)
        {
            _summonerService = summonerService;
            _logger = logger;
        }

        [HttpGet("by-name/{summonerName}")]
        public async Task<ActionResult> GetSummonerByName([FromRoute] Platform platform, [FromRoute] string summonerName)
        {
            var summonerResponse = await _summonerService.GetSummonerByNameAsync(platform, summonerName);

            switch (summonerResponse.ResponseType)
            {
                case ResponseType.Ok:
                    return Ok(summonerResponse);
                case ResponseType.NotFound:
                    return NotFound(summonerResponse);
                default:
                    return StatusCode(500);
            }
        }
    }
}