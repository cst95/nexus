using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Summoner.Service;

namespace SummonerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SummonerController : ControllerBase
    {
        private const string RiotApiKeyEnvVariableName = "RIOT_APIKEY";
        private readonly ISummonerService _summonerService;
        private readonly IConfiguration _config;

        public SummonerController(ISummonerService summonerService, IConfiguration config)
        {
            _summonerService = summonerService;
            _config = config;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok(_config[RiotApiKeyEnvVariableName]);
        }
        
    }
}