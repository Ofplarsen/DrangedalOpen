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
public class MatchController : ControllerBase
{
    
    private readonly ILogger<MatchController> _logger;

    public MatchController(ILogger<MatchController> logger)
    {
        _logger = logger;
    }
    //[Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<Match> GetMatch([FromQuery] Guid id)
    {
        throw new NotImplementedException();
    }
    
    [HttpPut()]
    public ActionResult<Match> EditMatch([FromQuery] Guid id, [FromBody] Match match)
    {
        throw new NotImplementedException();
    }
}