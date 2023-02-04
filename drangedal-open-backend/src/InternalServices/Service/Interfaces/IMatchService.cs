using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface IMatchService
{
    public MatchDTO CreateMatch(MatchDTO match);
    public MatchDTO GetMatch(Guid matchId);

    public List<Match> GetMatches(Guid tournamentId);

    public List<Match> GetMatches();

    public MatchDTO UpdateMatch(MatchDTO match, Guid id);

    public void DeleteMatch(Guid id);
    
    public List<MatchDTO> GetMatchesPlayer(string username, bool all);
    
}