using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nexus.Model.RiotApi;
using Nexus.Service.Interfaces;

namespace Nexus.API.Controllers
{
    [ApiController]
    [Route("[controller]/{platform}")]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        
        [HttpGet("by-accountid/{encryptedAccountId}")]
        public async Task<ActionResult> GetSummonerByName([FromRoute] Platform platform, [FromRoute] string encryptedAccountId)
        {
            var matchListResponse = await _matchService.GetMatchesByAccountIdAsync(platform, encryptedAccountId);

            switch (matchListResponse.ResponseType)
            {
                case ResponseType.Ok:
                    return Ok(matchListResponse);
                case ResponseType.NotFound:
                    return NotFound(matchListResponse);
                default:
                    return StatusCode(500);
            }
        }
    }
}