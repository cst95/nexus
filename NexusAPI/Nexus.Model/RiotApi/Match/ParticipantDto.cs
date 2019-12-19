using System.Collections.Generic;

namespace Nexus.Model.RiotApi.Match
{
    public class ParticipantDto
    {
        public ParticipantStatsDto Stats { get; set; }
        public int ParticipantId { get; set; }
        public IEnumerable<RuneDto> Runes { get; set; }
        public ParticipantTimelineDto Timeline { get; set; }
        public int TeamId { get; set; }
        public int Spell2Id { get; set; }
        public IEnumerable<MasteryDto> Masteries { get; set; }
        public string HighestAchievedSeasonTier { get; set; }
        public int Spell1Id { get; set; }
        public int ChampionId { get; set; }
    }
}