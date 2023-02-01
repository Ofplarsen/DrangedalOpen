namespace Common.Models.DTOs;

public class TournamentDTO
{
    public Guid TournamentGuid { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    
}