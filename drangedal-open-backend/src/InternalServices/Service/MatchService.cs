using Common.Extentions.Elo;
using Common.Models.Tournament;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class MatchService : IMatchService
{

    private readonly IRatingService _ratingService;

    public MatchService(IRatingService ratingService)
    {
        _ratingService = ratingService;
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

    public void UpdateMatch(Match match, Guid id)
    {
        throw new NotImplementedException();
    }

    public void DeleteMatch(Guid id)
    {
        throw new NotImplementedException();
    }

    public void MatchResult(Match match)
    {
        if(match.AwayScore < match.MatchRules.ScoreToWin && match.HomeScore < match.MatchRules.ScoreToWin)
            return;
        var winner = match.HomeScore >= match.MatchRules.ScoreToWin ? match.HomePlayer : match.AwayPlayer;
        var loser = match.HomeScore < match.MatchRules.ScoreToWin ? match.HomePlayer : match.AwayPlayer;
        
        EloCalculator.EloRating(winner.Ranking, loser.Ranking);
        _ratingService.UpdateRatings(new(){Username = winner.User.Username, Ranking = winner.Ranking},
            new() {Ranking = loser.Ranking, Username = loser.User.Username});
    }
}