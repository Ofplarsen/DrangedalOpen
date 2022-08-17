using Common.Models.DTOs;
using InternalServices.DataAccess.Interfaces;
using InternalServices.Repository.Interfaces;

namespace InternalServices.Repository;

public class RankingRepository : IRankingRepository
{
    private readonly IRankingDA _rankingDa;

    public RankingRepository(IRankingDA rankingDa)
    {
        _rankingDa = rankingDa;
    }

    public bool UpdateRatings(List<PlayerDTO> playerDtos)
    {
        return _rankingDa.UpdateRatings(playerDtos);
    }
}