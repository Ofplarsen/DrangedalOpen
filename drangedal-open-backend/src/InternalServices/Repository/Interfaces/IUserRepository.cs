using Common.Models;
using Common.Models.Login;

namespace InternalServices.Repository.Interfaces;

public interface IUserRepository
{
    public User CreateUser(UserRegister user);
    public UserLogin GetUserLogin(string username);
}