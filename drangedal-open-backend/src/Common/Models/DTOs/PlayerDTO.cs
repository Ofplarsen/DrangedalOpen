using Common.Models.Tournament;

namespace Common.Models.DTOs;

public class PlayerDTO
{
    public string Username { get; set; }
    public Ranking Ranking { get; set; }
}