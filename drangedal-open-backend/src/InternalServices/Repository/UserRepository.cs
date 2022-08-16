using Common.Models;
using Common.Models.Login;
using InternalServices.DataAccess.Interfaces;
using InternalServices.Repository.Interfaces;

namespace InternalServices.Repository;

public class UserRepository : IUserRepository
{
    private readonly IUserDA _userDa;

    public UserRepository(IUserDA userDa)
    {
        _userDa = userDa;
    }
    
    public User CreateUser(UserRegister user)
    {
        return _userDa.CreateUser(user);
    }
}