using Common.Models.Tournament;

namespace Common.Models.DTOs;

public class MatchDTO
{
    public Guid MatchGuid { get; set; } = Guid.NewGuid();
    public string HomePlayer { get; set; }
    public string AwayPlayer { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public Guid? NextMatch { get; set; } = Guid.Empty;
    public MatchRules MatchRules { get; set; }
    
    public string? Winner { get; set; }
}