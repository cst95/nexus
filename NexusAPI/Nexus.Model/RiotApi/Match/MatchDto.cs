using System.Collections.Generic;

namespace Nexus.Model.RiotApi.Match
{
    public class MatchDto
    {
        public int SeasonId { get; set; }
        public int QueueId { get; set; }
        public long GameId { get; set; }
        public List<ParticipantIdentityDto> ParticipantIdentities { get; set; }
        public string GameVersion { get; set; }
        public string PlatformId { get; set; }
        public string GameMode { get; set; }
        public int MapId { get; set; }
        public string GameType { get; set; }
        public List<TeamStatsDto> Teams { get; set; }
        public List<ParticipantDto> Participants { get; set; }
        public long GameDuration { get; set; }
        public long GameCreation { get; set; }
    }
}