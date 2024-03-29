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
public class TournamentController : ControllerBase
{
    
    private readonly ILogger<TournamentController> _logger;
    private readonly ITournamentService _tournamentService;

    public TournamentController(ILogger<TournamentController> logger, ITournamentService tournamentService)
    {
        _logger = logger;
        _tournamentService = tournamentService;
    }

    
    //[Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<TournamentMatchesDTO> GetTournament([FromQuery] Guid id)
    {
        return Ok(_tournamentService.GetTournament(id));
    }
    
    [HttpGet("matches")]
    public ActionResult<List<MatchDTO>> GetMatches([FromQuery] Guid id)
    {
        return _tournamentService.GetMatches(id);
    }
    
    [HttpPost()]
    public ActionResult<Tournament> GenerateTournament([FromBody] TournamentPlayersDTO tournamentPlayersDto)
    {
        return _tournamentService.GenerateTournament(tournamentPlayersDto);
    }
    
    
    [HttpGet("all")]
    public ActionResult<List<TournamentDTO>> GetTournaments([FromQuery] bool old)
    {
        return old ? _tournamentService.GetTournamentsArchived() : _tournamentService.GetTournamentsOngoing();
    }
    
}