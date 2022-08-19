using Common.Models.Tournament;

namespace InternalServices.DataAccess.Interfaces;

public interface IPlayerDA
{
    public Player GetPlayer(string username);
}