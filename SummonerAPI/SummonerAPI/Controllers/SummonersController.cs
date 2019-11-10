using Microsoft.AspNetCore.Mvc;
using Summoner.Models.RiotApi;
using Summoner.Service;

namespace SummonerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummonersController : ControllerBase
    {
        private readonly ISummonerService _summonerService;

        public SummonersController(ISummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        [HttpGet("by-name/{summonerName}")]
        public ActionResult GetSummonerByName([FromRoute] string summonerName)
        {
            var summoner = _summonerService.GetSummonerByName(Platform.Euw1, summonerName);
            return Ok(summoner);
        }
        
    }
}