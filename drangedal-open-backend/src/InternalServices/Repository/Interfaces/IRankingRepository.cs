using Common.Models.DTOs;

namespace InternalServices.Repository.Interfaces;

public interface IRankingRepository
{
    public bool UpdateRatings(List<PlayerDTO> playerDtos);
}