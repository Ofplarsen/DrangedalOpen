namespace Common.Models.Tournament;

public struct MatchRules
{
    public MatchType MatchType { get; set; }
    public int ScoreToWin { get; set; }
}