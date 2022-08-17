using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Models.Login;
using Common.Exceptions;
using Common.Extentions.Encryption;
using Microsoft.IdentityModel.Tokens;

using InternalServices.Service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace InternalServices.Service;

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _config;
    private readonly IUserService _userService;
    public AuthenticationService(IConfiguration config, IUserService userService)
    {
        _config = config;
        _userService = userService;
    }
    
    private string GenerateJsonWebToken(UserLogin user)    
    {    
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub,user.Username),
            // this guarantees the token is unique
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //Adds roles to jwt
            new Claim(ClaimTypes.Role, Roles.Admin.ToString()),
            new Claim(ClaimTypes.Role, Roles.User.ToString())
        };
        
        //Get users role:
        
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));    
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],    
            _config["Jwt:Issuer"],    
            claims,    
            expires: DateTime.Now.AddMinutes(120),    
            signingCredentials: credentials);    
    
        return new JwtSecurityTokenHandler().WriteToken(token);    
    }    
    
    public string AuthenticateUser(UserLogin login)
    {
        //Validate the User Credentials    
        //Demo Purpose, I have Passed HardCoded User Information    
        return CorrectCredentials(login) ? GenerateJsonWebToken(login)
            : throw new NotAuthorizedException("Wrong login");    
    }

    private bool CorrectCredentials(UserLogin login)
    {
        string hashedPassword = _userService.GetUserLogin(login.Username).Password;
        return PasswordEncryption.Verify(login.Password,hashedPassword);
    }
}