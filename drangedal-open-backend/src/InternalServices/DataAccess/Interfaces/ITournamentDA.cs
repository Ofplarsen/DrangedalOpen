using Common.Models.DTOs;

namespace InternalServices.DataAccess.Interfaces;

public interface ITournamentDA
{
    public bool CreateTournament(TournamentDTO tournamentDto);
    public bool MapTournamentMatch(Guid tournamentGuid, Guid matchGuid);
    public TournamentDTO GetTournament(Guid tournamentGuid);
    public List<TournamentDTO> GetTournamentsOngoing();
    public List<TournamentDTO> GetTournamentsArchived();
}