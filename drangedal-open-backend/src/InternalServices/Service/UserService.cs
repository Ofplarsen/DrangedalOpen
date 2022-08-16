using Common.Models;
using Common.Models.Login;
using InternalServices.Repository.Interfaces;
using InternalServices.Service.Interfaces;
namespace InternalServices.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository repository)
    {
        _userRepository = repository;
    }
    
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

    public User CreateUser(UserRegister user)
    {
        _userRepository.CreateUser(user);
        return new() {Username = user.Username};
    }
}