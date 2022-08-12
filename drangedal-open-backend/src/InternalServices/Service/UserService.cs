using Common.Models;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class UserService : IUserService
{
    public User GetUser(string username)
    {
        return new() {Email = "mail@mail.com", Username = username};
    }

    public List<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DisableUser(string username)
    {
        throw new NotImplementedException();
    }

    
}