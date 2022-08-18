using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface IMatchService
{
    public MatchDTO CreateMatch(MatchDTO match);
    public Match GetMatch(Guid id);

    public List<Match> GetMatches(Guid tournamentId);

    public List<Match> GetMatches();

    public Match UpdateMatch(Match match, Guid id);

    public void DeleteMatch(Guid id);
    
}