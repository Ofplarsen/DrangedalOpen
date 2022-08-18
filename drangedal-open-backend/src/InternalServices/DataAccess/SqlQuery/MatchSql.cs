using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.SqlQuery;

public static class MatchSql
{
    public static string CreateMatch(MatchDTO match)
    {
        return String.Format("Insert into match (matchguid, playerhome, playeraway, scorehome, scoreaway, matchtypeid)" + 
            " values ('{0}','{1}','{2}',0,0, {3})",
            match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType);
    }
    public static string UpdateMatch(Match match)
    {
        return String.Format("Update match set scorehome = {0}, scoreaway= {1} where matchguid = '{2}'",
            match.HomeScore, match.AwayScore, match.MatchGuid.ToString());
    }
    
}