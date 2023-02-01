namespace Common.Models.Tournament;

public class MatchRules
{
    public MatchType MatchType { get; set; } = MatchType.Default;
    public int ScoreToWin { get; set; } = 11;
}