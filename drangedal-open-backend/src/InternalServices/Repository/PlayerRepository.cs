using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.Repository.Interfaces;

namespace InternalServices.Repository;

public class PlayerRepository : IPlayerRepository
{

    private readonly IPlayerDA _playerDa;

    public PlayerRepository(IPlayerDA playerDa)
    {
        _playerDa = playerDa;
    }


    public Player GetPlayer(string username)
    {
        return _playerDa.GetPlayer(username);
    }

    public List<Player> GetPlayers()
    {
        return _playerDa.GetPlayers();
    }

    public List<PlayerDTO> GetPlayersSimple()
    {
        return _playerDa.GetPlayersSimple();
    }
}