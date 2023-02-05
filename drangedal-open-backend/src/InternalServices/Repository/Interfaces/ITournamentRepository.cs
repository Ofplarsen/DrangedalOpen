using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Repository.Interfaces;

public interface ITournamentRepository
{
    public bool CreateTournament(Tournament tournament);
    public bool MapTournamentMatch(Tournament tournament, MatchDTO match);

    public List<MatchDTO> GetMatches(Guid tournamentGuid);
    public TournamentDTO GetTournament(Guid tournamentGuid);
    public List<TournamentDTO> GetTournamentsOngoing();
    public List<TournamentDTO> GetTournamentsArchived();
}