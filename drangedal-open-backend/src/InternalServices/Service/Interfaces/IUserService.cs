using Common.Models;
using Common.Models.Login;

namespace InternalServices.Service.Interfaces;

public interface IUserService
{
    public User GetUser(string username);

    public List<User> GetUsers();
    public void UpdateUser(User user);
    public void DisableUser(string username);

    public User CreateUser(UserRegister user);
}