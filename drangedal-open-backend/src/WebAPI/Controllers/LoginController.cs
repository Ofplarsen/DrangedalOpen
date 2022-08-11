using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Common.Exceptions;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LoginController : ControllerBase
{
    
    private readonly ILogger<LoginController> _logger;
    private readonly IConfiguration _config;
    
    public LoginController(ILogger<LoginController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    
    [AllowAnonymous]
    [HttpPost(Name = "GetWeatherForecast")]
    public ActionResult<User> Login([FromBody]UserLogin user)
    {
        try
        {
            User u = AuthenticateUser(user);
            return Ok(new {token = GenerateJsonWebToken(), u});
        }
        catch (NotAuthorizedException e)
        {
            return Unauthorized(e.Message);
        }
    }
    
    private string GenerateJsonWebToken()    
    {    
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
            _config["Jwt:Issuer"],    
            null,    
            expires: DateTime.Now.AddMinutes(120),    
            signingCredentials: credentials);    
    
        return new JwtSecurityTokenHandler().WriteToken(token);    
    }    
    
    private User AuthenticateUser(UserLogin login)
    {
          
    
        //Validate the User Credentials    
        //Demo Purpose, I have Passed HardCoded User Information    
        return login.Username == "123" ? new User { Username = "Jignesh Trivedi",Email = "test.btest@gmail.com" }
            : throw new NotAuthorizedException("Wrong login");    
    }    
}