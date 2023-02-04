using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.Interfaces;

public interface IMatchDA
{
    public MatchDTO UpdateMatch(MatchDTO match);
    public MatchDTO CreateMatch(MatchDTO match);

    public List<MatchDTO> GetMatches(Guid tournamentGuid);
    public MatchDTO GetMatch(Guid matchId);

    public List<MatchDTO> GetMatchesPlayer(string username);

    public List<MatchDTO> GetMatchesPlayerUpcoming(string username);
}