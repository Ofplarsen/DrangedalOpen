using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.Repository.Interfaces;

namespace InternalServices.Repository;

public class TournamentRepository : ITournamentRepository
{
    private readonly ITournamentDA _tournamentDa;
    private readonly IMatchDA _matchDa;

    public TournamentRepository(ITournamentDA tournamentDa, IMatchDA matchDa)
    {
        _tournamentDa = tournamentDa;
        _matchDa = matchDa;
    }

    public bool CreateTournament(Tournament tournament)
    {
        return _tournamentDa.CreateTournament(new TournamentDTO()
            {TournamentGuid = tournament.TournamentGuid, Name = tournament.Name});
        
    }

    public bool MapTournamentMatch(Tournament tournament, MatchDTO match)
    {
        return _tournamentDa.MapTournamentMatch(tournament.TournamentGuid, match.MatchGuid);
    }

    public List<MatchDTO> GetMatches(Guid tournamentGuid)
    {
        return _matchDa.GetMatches(tournamentGuid);
    }
}