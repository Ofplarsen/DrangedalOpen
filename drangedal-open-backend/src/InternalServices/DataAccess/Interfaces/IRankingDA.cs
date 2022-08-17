using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.Interfaces;

public interface IRankingDA
{
    public bool UpdateRatings(List<PlayerDTO> player);
}