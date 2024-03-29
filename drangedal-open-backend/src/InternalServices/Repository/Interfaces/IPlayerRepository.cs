using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.Repository.Interfaces;

public interface IPlayerRepository
{
    public Player GetPlayer(string username);
    public List<Player> GetPlayers();
    public List<PlayerDTO> GetPlayersSimple();
}