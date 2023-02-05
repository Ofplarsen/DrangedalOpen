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
public class MatchController : ControllerBase
{
    
    private readonly ILogger<MatchController> _logger;
    private readonly IMatchService _matchService;
    
    public MatchController(ILogger<MatchController> logger, IMatchService matchService)
    {
        _logger = logger;
        _matchService = matchService;
    }
    //[Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<MatchDTO> GetMatch([FromQuery] Guid id)
    {
        return _matchService.GetMatch(id);
    }
    
    [HttpGet("player")]
    public ActionResult<List<MatchDTO>> GetMatchesPlayer([FromQuery] string username, [FromQuery] bool all)
    {
        return _matchService.GetMatchesPlayer(username, all);
    }
    
    [HttpPost()]
    public ActionResult<MatchDTO> GetMatch([FromBody] MatchDTO matchDto)
    {
        return _matchService.CreateMatch(matchDto);

    }
    
    [HttpPut()]
    public ActionResult<MatchDTO> UpdateMatch([FromBody] MatchDTO match)
    {
        try
        {
            return _matchService.UpdateMatch(match);
        }
        catch (Exception e)
        {
            return NotFound("Match not found");
        }
        
    }
}