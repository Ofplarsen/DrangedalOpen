using Common.Exceptions;
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
    private readonly IPlayerService _playerService;
    public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService)
    {
        _logger = logger;
        _playerService = playerService;
    }

    [HttpGet()]
    public ActionResult<Player> GetPlayer([FromQuery] string username)
    {
        try
        {
            var player = _playerService.GetPlayer(username);
            return player == null ? NotFound() : player;
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpGet("all")]
    public ActionResult<List<Player>> GetPlayers()
    {
        try
        {
            return _playerService.GetPlayers();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}