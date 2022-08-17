using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Models.Login;
using InternalServices.Service.Interfaces;
using Common.Exceptions;
using Common.Models.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LoginController : ControllerBase
{
    
    private readonly ILogger<LoginController> _logger;
    private readonly IAuthenticationService _authentication;
    private readonly IUserService _userService;
    public LoginController(ILogger<LoginController> logger, IAuthenticationService authentication, IUserService userService )
    {
        _logger = logger;
        _authentication = authentication;
        _userService = userService;
    }
    //[Authorize(Roles = "Admin")]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    [HttpPost]
    public ActionResult<TokenUserDTO> Login([FromBody]UserLogin user)
    {
        try
        {
            string token = _authentication.AuthenticateUser(user);
            User userInfo = _userService.GetUser(user.Username);
            return Ok(new TokenUserDTO() {Token = token, User = userInfo});
        }
        catch (NotFoundException e)
        {
            return Unauthorized(e.Message);
        }
        catch (NotAuthorizedException e)
        {
            return Unauthorized(e.Message);
        }
    }
    
}