using Common.Extentions.Elo;
using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class MatchService : IMatchService
{

    private readonly IRatingService _ratingService;
    private readonly IMatchRepository _matchRepository;
    public MatchService(IRatingService ratingService, IMatchRepository matchRepository)
    {
        _ratingService = ratingService;
        _matchRepository = matchRepository;
    }

    public MatchDTO CreateMatch(MatchDTO match)
    {
        match.MatchGuid = Guid.NewGuid();
        return _matchRepository.CreateMatch(match);
    }

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

    public Match UpdateMatch(Match match, Guid id)
    {
        if (match.AwayScore >= match.MatchRules.ScoreToWin && match.HomeScore >= match.MatchRules.ScoreToWin)
        {
            MatchResult(match);
        }

        return _matchRepository.UpdateMatch(match);
    }

    public void DeleteMatch(Guid id)
    {
        throw new NotImplementedException();
    }

    private void MatchResult(Match match)
    {
        
        var winner = match.HomeScore >= match.MatchRules.ScoreToWin ? match.HomePlayer : match.AwayPlayer;
        var loser = match.HomeScore < match.MatchRules.ScoreToWin ? match.HomePlayer : match.AwayPlayer;
        
        EloCalculator.EloRating(winner.Ranking, loser.Ranking);
        _ratingService.UpdateRatings(new(){Username = winner.User.Username, Ranking = winner.Ranking},
            new() {Ranking = loser.Ranking, Username = loser.User.Username});
    }
}