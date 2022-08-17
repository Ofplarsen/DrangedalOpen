using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface IMatchService
{
    public Match GetMatch(Guid id);

    public List<Match> GetMatches(Guid tournamentId);

    public List<Match> GetMatches();

    public void UpdateMatch(Match match, Guid id);

    public void DeleteMatch(Guid id);

    public void MatchResult(Match match);
}