using Common.Models;

namespace InternalServices.Service.Interfaces;

public interface IUserService
{
    public User GetUser(string username);

    public List<User> GetUsers();
    public void UpdateUser(User user);
    public void DisableUser(string username);


}