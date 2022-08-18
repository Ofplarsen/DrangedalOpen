using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.Repository.Interfaces;

namespace InternalServices.Repository;

public class MatchRepository : IMatchRepository
{
    private readonly IMatchDA _matchDa;

    public MatchRepository(IMatchDA matchDa)
    {
        _matchDa = matchDa;
    }

    public Match UpdateMatch(Match match)
    {
        return _matchDa.UpdateMatch(match);
    }

    public MatchDTO CreateMatch(MatchDTO match)
    {
        return _matchDa.CreateMatch(match);
    }
}