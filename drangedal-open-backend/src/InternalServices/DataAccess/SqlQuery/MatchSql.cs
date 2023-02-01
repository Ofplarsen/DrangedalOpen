using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.SqlQuery;

public static class MatchSql
{
    public static string CreateMatch(MatchDTO match)
    {
        var next = match.NextMatch != Guid.Empty;
        Console.Out.WriteLine(next);
        if(next)
            return String.Format("Insert into match (matchguid, playerhome, playeraway, scorehome, scoreaway, matchtypeid, nextmatch)" + 
            " values ('{0}','{1}','{2}',0,0, {3}, '{4}')",
            match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType,  match.NextMatch );
        else
            return String.Format("Insert into match (matchguid, playerhome, playeraway, scorehome, scoreaway, matchtypeid, nextmatch)" + 
                                 " values ('{0}','{1}','{2}',0,0, {3})",
                match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType);
    }
    
    
    
    public static string UpdateMatch(Match match)
    {
        return String.Format("Update match set scorehome = {0}, scoreaway= {1} where matchguid = '{2}'",
            match.HomeScore, match.AwayScore, match.MatchGuid.ToString());
    }
    
}