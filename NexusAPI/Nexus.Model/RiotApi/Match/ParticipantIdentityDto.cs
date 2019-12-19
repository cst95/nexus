using Nexus.Model.RiotApi.Match;

namespace Nexus.Model.RiotApi.Match
{
    public class ParticipantIdentityDto
    {
        public PlayerDto Player { get; set; }
        public int ParticipantId { get; set; }
    }
}