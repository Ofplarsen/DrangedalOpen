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
public class TournamentController : ControllerBase
{
    
    private readonly ILogger<TournamentController> _logger;

    public TournamentController(ILogger<TournamentController> logger)
    {
        _logger = logger;
    }
    //[Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<Tournament> GetTournament([FromQuery] Guid id)
    {
        return Ok(new Tournament() {Name = "Name", TournamentGuid = Guid.NewGuid()});
    }
    
    [HttpGet()]
    public ActionResult<List<Tournament>> GetTournaments()
    {
        return Ok(new Tournament() {Name = "Name", TournamentGuid = Guid.NewGuid()});
    }
}