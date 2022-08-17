using Common.Extentions.Elo;
using Common.Models.DTOs;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class RatingService : IRatingService
{
    private readonly IRankingRepository _rankingRepository;

    public RatingService(IRankingRepository rankingRepository)
    {
        _rankingRepository = rankingRepository;
    }

    public bool UpdateRatings(PlayerDTO winner, PlayerDTO loser)
    {
        EloCalculator.EloRating(winner.Ranking, loser.Ranking);
        
        return _rankingRepository.UpdateRatings(new(){winner,loser});
    }
    
    
}