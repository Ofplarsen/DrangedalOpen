using Common.Models.Tournament;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class MatchService : IMatchService
{
    public Match GetMatch(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Match> GetMatches(Guid tournamentId)
    {
        throw new NotImplementedException();
    }

    public List<Match> GetMatches()
    {
        throw new NotImplementedException();
    }

    public void UpdateMatch(Match match, Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteMatch(Guid id)
    {
        throw new NotImplementedException();
    }
}