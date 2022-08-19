using Common.Models.Tournament;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;

namespace InternalServices.Service;

public class PlayerService : IPlayerService
{

    private readonly IPlayerRepository _playerRepository;

    public PlayerService(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public Player GetPlayer(string username)
    {
        return _playerRepository.GetPlayer(username);
    }
}