using Common.Models.DTOs;
using Common.Models.Tournament;
using Common.Models.Tournament.Tree;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class TournamentService : ITournamentService
{
    private readonly IMatchRepository _matchRepository;
    private readonly ITournamentRepository _tournamentRepository;
    private readonly IPlayerRepository _playerRepository;

    public TournamentService(IMatchRepository matchRepository, ITournamentRepository tournamentRepository, 
        IPlayerRepository playerRepository)
    {
        _matchRepository = matchRepository;
        _tournamentRepository = tournamentRepository;
        _playerRepository = playerRepository;
    }

    public TournamentMatchesDTO GetTournament(Guid tournamentGuid)
    {
        var tournament = _tournamentRepository.GetTournament(tournamentGuid);
        var matches = _tournamentRepository.GetMatches(tournamentGuid);

        return new TournamentMatchesDTO()
        {
            Name = tournament.Name,
            TournamentGuid = tournament.TournamentGuid,
            Matches = matches
        };
    }

    public List<MatchDTO> GetMatches(Guid tournamentGuid)
    {
        return _tournamentRepository.GetMatches(tournamentGuid);
    }

    public List<TournamentDTO> GetTournamentsOngoing()
    {
        return _tournamentRepository.GetTournamentsOngoing();
    }

    public List<TournamentDTO> GetTournamentsArchived()
    {
        return _tournamentRepository.GetTournamentsArchived();
    }

    public Tournament GenerateTournament(TournamentPlayersDTO tournamentPlayersDto)
    {
        Tournament tournament = new Tournament() {Name = tournamentPlayersDto.Name};
        List<Player> players = new List<Player>();
        foreach (var player in tournamentPlayersDto.Players)
        {
            players.Add(_playerRepository.GetPlayer(player));
        }
        tournament.Matches = BracketGenerator.GenerateMatches(players);
        CreateTournament(tournament);
        return tournament;
    }

    private bool CreateTournament(Tournament tournament)
    {
        List<MatchDTO> matches =  tournament.Matches.Select(m =>
        {
            Guid nextMatch = Guid.Empty;
            string away = null;
            try
            {
                away = m.AwayPlayer.User.Username;
            }
            catch (Exception e)
            {
                
            }

            string home = null;
            try
            {
                home = m.HomePlayer.User.Username;
            }
            catch (Exception e)
            {
                
            }
            try
            {
               nextMatch =  m.NextMatch.MatchGuid;
            }
            catch (Exception e)
            {
                
            }

            if ((home == null || away == null) && !(home == null && away == null))
            {
                tournament.Matches.Where(m => m.MatchGuid == nextMatch).First()
                    .HomePlayer.User.Username = home == null ? away : home;
            }
            
                return new MatchDTO()
                {
                    MatchGuid = m.MatchGuid,
                    MatchRules = m.MatchRules,
                    NextMatch = nextMatch,
                    AwayPlayer = away,
                    HomePlayer = home
                };
        }).ToList();
        _tournamentRepository.CreateTournament(tournament);
        // Should change so not need to connect for each, but all at the same tim
        matches.Reverse();
        foreach (var match in matches)
        {
            _matchRepository.CreateMatch(match); //TODO DEPRECATE
            _tournamentRepository.MapTournamentMatch(tournament, match);
        }
        return true;
    }
}