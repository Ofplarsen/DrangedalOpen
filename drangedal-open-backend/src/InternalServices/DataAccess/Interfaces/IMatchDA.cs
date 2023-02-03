using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.Interfaces;

public interface IMatchDA
{
    public Match UpdateMatch(Match match);
    public MatchDTO CreateMatch(MatchDTO match);

    public List<MatchDTO> GetMatches(Guid tournamentGuid);
}