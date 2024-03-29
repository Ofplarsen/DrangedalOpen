using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.Interfaces;

public interface IPlayerDA
{
    public Player GetPlayer(string username);
    public List<Player> GetPlayers();
    public List<PlayerDTO> GetPlayersSimple();
}