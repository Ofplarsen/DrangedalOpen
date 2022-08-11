namespace Common.Models.Tournament;

public struct Tournament
{
    public Guid TournamentGuid { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    
    public List<Match> Matches { get; set; }

}