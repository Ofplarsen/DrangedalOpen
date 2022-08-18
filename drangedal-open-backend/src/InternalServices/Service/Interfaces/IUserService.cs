using Common.Models;
using Common.Models.DTOs;
using Common.Models.Login;
using Common.Models.Tournament;

namespace InternalServices.Service.Interfaces;

public interface IUserService
{
    public User GetUser(string username);

    public List<User> GetUsers();
    public void UpdateUser(User user);
    public void DisableUser(string username);

    public User CreateUser(UserRegister user);
    public UserLogin GetUserLogin(string username);

    public Player GetPlayer(string username);
}