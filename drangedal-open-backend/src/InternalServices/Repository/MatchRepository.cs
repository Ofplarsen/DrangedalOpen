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

    public List<MatchDTO> GetMatchesPlayer(string username)
    {
        return _matchDa.GetMatchesPlayer(username);
    }

    public List<MatchDTO> GetMatchesPlayerUpcoming(string username)
    {
        return _matchDa.GetMatchesPlayerUpcoming(username);
    }

    public MatchDTO SetMatch(MatchDTO match, bool homeWin)
    {
        return _matchDa.SetMatch(match, homeWin);
    }
}