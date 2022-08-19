using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface IPlayerService
{
    public Player GetPlayer(string username);
}