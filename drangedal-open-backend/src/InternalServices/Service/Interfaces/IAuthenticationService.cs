using Common.Models;
using Common.Models.Login;

namespace InternalServices.Service.Interfaces;

public interface IAuthenticationService
{
    public string AuthenticateUser(UserLogin login);
}