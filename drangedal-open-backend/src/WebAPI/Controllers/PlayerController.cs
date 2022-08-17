using Common.Models;
using Common.Models.Login;
using Common.Models.Tournament;
using InternalServices.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
//Used to make sure token is used
//[Authorize]
[Route("api/v1/[controller]")]
public class PlayerController : ControllerBase
{
    
    private readonly ILogger<PlayerController> _logger;
    private readonly IUserService _userService;
    public PlayerController(ILogger<PlayerController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    
    
    [HttpPut("update")]
    public ActionResult UpdateUser([FromBody] User user, [FromQuery] Guid id)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public ActionResult GetUser([FromQuery] string id)
    {
        throw new NotImplementedException();
    }
}