using Common.Models.DTOs;

namespace InternalServices.Service.Interfaces;

public interface IRatingService
{
    public bool UpdateRatings(PlayerDTO winner, PlayerDTO loser);
}