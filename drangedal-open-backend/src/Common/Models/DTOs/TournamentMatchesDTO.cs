namespace Common.Models.DTOs;

public class TournamentMatchesDTO
{
    public Guid TournamentGuid { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<MatchDTO> Matches { get; set; }
}