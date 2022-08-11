namespace Common.Models.Tournament;

public struct Match
{
    public Guid MatchGuid { get; set; } = Guid.NewGuid();
    public Player HomePlayer { get; set; }
    public Player AwayPlayer { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public MatchRules MatchRules { get; set; }
}