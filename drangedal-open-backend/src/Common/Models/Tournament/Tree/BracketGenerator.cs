namespace Common.Models.Tournament.Tree;
using System;
using System.Collections.Generic;
using System.Threading;
public static class Extensions
{
    private static Random rand = new Random();
 
    public static void Shuffle<T>(this IList<T> values)
    {
        for (int i = values.Count - 1; i > 0; i--) {
            int k = rand.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}
public class BracketGenerator
{

    public static List<Match> GenerateMatches(List<Player> players)
    {
        List<Match> matches = new List<Match>();
        players.Shuffle();
        var playersSize = players.Count;

        var size = GetSize(players.Count);

        for (int i = 0; i < size; i += 2)
        {
            Match match = new Match();
            
            if(playersSize > i)
                match.HomePlayer = players[i];
            if(playersSize > (i+1))
                match.AwayPlayer = players[i + 1];
            
            MatchRules matchRules = new MatchRules();
            match.MatchRules = matchRules;
            matches.Add(match);
        }
        matches.AddRange(GenerateNextBracket(matches));
        SetMatchType(matches);
        return matches;
    }

    private  static List<Match>  GenerateNextBracket(List<Match> matches)
    {
        List<Match> matchesLayer = new List<Match>();
        if (matches.Count == 1)
            return matchesLayer;
        for (int i = 0; i < matches.Count; i += 2)
        {
            Match match = new Match();
            matches[i].NextMatch = match;
            matches[i + 1].NextMatch = match;
            matchesLayer.Add(match);
        }
        matchesLayer.AddRange(GenerateNextBracket(matchesLayer));
        return matchesLayer;
    }

    private static void SetMatchType(List<Match> matches)
    {
        var num = 2;
        var matchNumb = 0;
        for (var i = matches.Count - 1; i >= 0; i--)
        {
            switch(matchNumb) 
            {
                case 0:
                    matches[i].MatchRules.MatchType = MatchType.Final;
                    break;
                case <=2:
                    matches[i].MatchRules.MatchType = MatchType.Semi;
                    break;
                case <=6:
                    matches[i].MatchRules.MatchType = MatchType.Quarter;
                    break;
                default:
                    matches[i].MatchRules.MatchType = MatchType.Default;
                    break;
            }
            matchNumb++;
        }
    }

    private static int GetSize(int amount)
    {
        var log = (int)Math.Ceiling(Math.Log2(amount));
        return (int)Math.Pow(2, log);
    }
    
}