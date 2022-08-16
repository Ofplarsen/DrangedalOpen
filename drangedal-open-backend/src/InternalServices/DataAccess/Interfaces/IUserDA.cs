using Common.Models;
using Common.Models.Login;

namespace InternalServices.DataAccess.Interfaces;

public interface IUserDA
{
    public User CreateUser(UserRegister user);
}