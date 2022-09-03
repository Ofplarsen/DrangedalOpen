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
[Authorize]
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
    public ActionResult<Tournament> GetTournament([FromQuery] Guid id)
    {
        return Ok(new Tournament() {Name = "Name", TournamentGuid = Guid.NewGuid()});
    }
    
    [HttpPost()]
    public ActionResult<Tournament> GenerateTournament([FromBody] TournamentPlayersDTO tournamentPlayersDto)
    {
        return _tournamentService.GenerateTournament(tournamentPlayersDto);
    }
    
    /*
    [HttpGet()]
    public ActionResult<List<Tournament>> GetTournaments()
    {
        return Ok(new Tournament() {Name = "Name", TournamentGuid = Guid.NewGuid()});
    }
    */
}