using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class TournamentService : ITournamentService
{
    private readonly IMatchRepository _matchRepository;
    private readonly ITournamentRepository _tournamentRepository;

    public TournamentService(IMatchRepository matchRepository, ITournamentRepository tournamentRepository)
    {
        _matchRepository = matchRepository;
        _tournamentRepository = tournamentRepository;
    }


    public Tournament GenerateTournament(TournamentPlayersDTO tournamentPlayersDto)
    {
        Tournament tournament = new Tournament() {Name = tournamentPlayersDto.Name};

        return new Tournament();
    }
}