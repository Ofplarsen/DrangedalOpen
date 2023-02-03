using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface ITournamentService
{
    public Tournament GenerateTournament(TournamentPlayersDTO tournamentPlayersDto);

    public List<MatchDTO> GetMatches(Guid tournamentGuid);
}