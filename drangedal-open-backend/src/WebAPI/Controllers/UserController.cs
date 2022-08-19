using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Common.Exceptions;
using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers;

[ApiController]
//Used to make sure token is used
//[Authorize]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;
    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    

    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody] UserRegister user)
    {
        _userService.CreateUser(user);
        return Ok();
    }
    
    [HttpPut("update")]
    public ActionResult UpdateUser([FromBody] User user, [FromQuery] Guid id)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public ActionResult<User> GetUser([FromQuery] string username)
    {
        try
        {
            return _userService.GetUser(username);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    
}