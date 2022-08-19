using Common.Models;
using Common.Models.Login;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.Interfaces;

public interface IUserDA
{
    public User CreateUser(UserRegister user);
    public UserLogin GetUserLogin(string username);

    public User GetUser(string username);

    
    
}