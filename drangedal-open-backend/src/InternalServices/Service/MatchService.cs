using Common.Extentions.Elo;
using Common.Extentions.ReadDb;
using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class MatchService : IMatchService
{
    private readonly IPlayerService _playerService;
    private readonly IRatingService _ratingService;
    private readonly IMatchRepository _matchRepository;
    public MatchService(IRatingService ratingService, IMatchRepository matchRepository, IPlayerService playerService)
    {
        _playerService = playerService;
        _ratingService = ratingService;
        _matchRepository = matchRepository;
    }

    public MatchDTO CreateMatch(MatchDTO match)
    {
        match.MatchGuid = Guid.NewGuid();
        return _matchRepository.CreateMatch(match);
    }

    public MatchDTO GetMatch(Guid matchId)
    {
        return _matchRepository.GetMatch(matchId);
    }

    public List<Match> GetMatches(Guid tournamentId)
    {
        throw new NotImplementedException();
    }

    public List<Match> GetMatches()
    {
        throw new NotImplementedException();
    }

    public MatchDTO UpdateMatch(MatchDTO match)
    {
        //TODO Split these to, one to handle wins, and one to only update match
        if (match.AwayScore >= match.MatchRules.ScoreToWin || match.HomeScore >= match.MatchRules.ScoreToWin)
        {
            MatchResult(match);
        }

        return _matchRepository.UpdateMatch(match);
    }

    public void DeleteMatch(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<MatchDTO> GetMatchesPlayer(string username, bool all)
    {
        return all ? _matchRepository.GetMatchesPlayer(username) : _matchRepository.GetMatchesPlayerUpcoming(username);
    }

    private void MatchResult(MatchDTO match)
    {
        
        var winner = match.HomeScore >= match.MatchRules.ScoreToWin ? _playerService.GetPlayer(match.HomePlayer)
            : _playerService.GetPlayer(match.AwayPlayer);
        var loser = match.HomeScore < match.MatchRules.ScoreToWin ?_playerService.GetPlayer(match.HomePlayer)
            : _playerService.GetPlayer(match.AwayPlayer);

        _matchRepository.SetMatch(match, (winner.User.Username == match.HomePlayer));
        EloCalculator.EloRating(winner.Ranking, loser.Ranking);
        _ratingService.UpdateRatings(new(){Username = winner.User.Username, Ranking = winner.Ranking},
            new() {Ranking = loser.Ranking, Username = loser.User.Username});

        if (match.NextMatch != null)
        {
            
            var nextMatch = _matchRepository.GetMatch((Guid)match.NextMatch);
            if (nextMatch.AwayPlayer != null && nextMatch.HomePlayer != null)
                return;
            if (nextMatch.HomePlayer == null)
                nextMatch.HomePlayer = winner.User.Username;
            else if(nextMatch.AwayPlayer == null)
                nextMatch.AwayPlayer = winner.User.Username;
            
            _matchRepository.UpdateMatch(nextMatch);
        }
            
        
        
    }
}