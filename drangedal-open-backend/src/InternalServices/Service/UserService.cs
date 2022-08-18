using Common.Extentions.Encryption;
using Common.Models;
using Common.Models.Login;
using Common.Models.Tournament;
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
        return _userRepository.GetUser(username);
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
        user.Password = PasswordEncryption.Hash(user.Password);
        _userRepository.CreateUser(user);
        return new() {Username = user.Username};
    }

    public UserLogin GetUserLogin(string username)
    {
        return _userRepository.GetUserLogin(username);
    }

    public Player GetPlayer(string username)
    {
        return _userRepository.GetPlayer(username);
    }
}