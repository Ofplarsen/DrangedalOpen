using Common.Models;
using Common.Models.Login;
using Common.Models.Tournament;

namespace InternalServices.Repository.Interfaces;

public interface IUserRepository
{
    public User CreateUser(UserRegister user);
    public UserLogin GetUserLogin(string username);
    public User GetUser(string username);

    
    
}