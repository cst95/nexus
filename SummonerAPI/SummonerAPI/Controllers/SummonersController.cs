using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Summoner.Models.RiotApi;
using Summoner.Service;

namespace SummonerAPI.Controllers
{
    [ApiController]
    [Route("[controller]/{platform}")]
    public class SummonersController : ControllerBase
    {
        private readonly ISummonerService _summonerService;

        public SummonersController(ISummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        [HttpGet("by-name/{summonerName}")]
        public async Task<ActionResult> GetSummonerByName([FromRoute] Platform platform, [FromRoute] string summonerName)
        {
            var summonerResponse = await _summonerService.GetSummonerByName(platform, summonerName);

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