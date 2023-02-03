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

    public MatchDTO UpdateMatch(MatchDTO match)
    {
        return _matchDa.UpdateMatch(match);
    }

    public MatchDTO CreateMatch(MatchDTO match)
    {
        return _matchDa.CreateMatch(match);
    }

    public MatchDTO GetMatch(Guid matchId)
    {
        return _matchDa.GetMatch(matchId);
    }
}