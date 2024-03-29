using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface IPlayerService
{
    public Player GetPlayer(string username);
    public List<Player> GetPlayers();
    public List<PlayerDTO> GetPlayersSimple();
}