using System.Collections.Generic;

namespace Nexus.Model.RiotApi.Match
{
    public class MatchlistDto
    {
        public List<MatchReferenceDto> Matches { get; set; }
        public int TotalGames { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}