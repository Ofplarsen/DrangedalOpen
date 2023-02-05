using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Repository.Interfaces;

public interface IMatchRepository
{
    public MatchDTO UpdateMatch(MatchDTO match);
    public MatchDTO CreateMatch(MatchDTO match);
    public MatchDTO GetMatch(Guid matchId);
    public List<MatchDTO> GetMatchesPlayer(string username);
    public List<MatchDTO> GetMatchesPlayerUpcoming(string username);
    public MatchDTO SetMatch(MatchDTO match, bool homeWin);
}