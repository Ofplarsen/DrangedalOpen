using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Common.Models;
using Common.Models.Login;
using Microsoft.AspNetCore.Authorization;
using Common.Exceptions;
using Common.Models.Tournament;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers;

[ApiController]
//Used to make sure token is used
[Authorize]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }
    

    [HttpPost("register")]
    public ActionResult RegisterUser()
    {
        return Ok();
    }
    
    [HttpGet("{id}")]
    public ActionResult GetUser([FromQuery] string id)
    {
        return Ok();
    }
}