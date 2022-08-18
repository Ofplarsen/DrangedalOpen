using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.SqlQuery;

public static class RankingSql
{
    public static string UpdateRating(PlayerDTO playerDto)
    {
        return String.Format("Update ranking set gameswon = {1}, gameslost = {2}, rating = {3} where username = '{0}'",
            playerDto.Username, playerDto.Ranking.GamesWon, playerDto.Ranking.GamesLost, playerDto.Ranking.Rating);
    }
}