using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.SqlQuery;

public static class MatchSql
{
    public static string CreateMatch(MatchDTO match)
    {
        if (match.AwayPlayer == null && match.HomePlayer == null)
        {
            if(match.NextMatch == Guid.Empty)
                return String.Format("Insert into match (matchguid, scorehome, scoreaway, matchtypeid)" + 
                                     " values ('{0}',0,0, {1})",
                    match.MatchGuid,  (int)match.MatchRules.MatchType);
            
            return String.Format("Insert into match (matchguid,  scorehome, scoreaway, matchtypeid, nextmatch)" + 
                                 " values ('{0}',0,0, {1}, '{2}')",
                match.MatchGuid,  (int)match.MatchRules.MatchType,  match.NextMatch);
        }
        

        if (match.AwayPlayer == null)
        {
            if(match.NextMatch == Guid.Empty)
                return String.Format("Insert into match (matchguid, playerhome, scorehome, scoreaway, matchtypeid)" + 
                                     " values ('{0}', '{1}',0,0, {2})",
                    match.MatchGuid, match.HomePlayer, (int)match.MatchRules.MatchType);
            return String.Format("Insert into match (matchguid, playerhome, scorehome, scoreaway, matchtypeid, nextmatch)" + 
                                 " values ('{0}', '{1}',0,0, {2}, '{3}')",
                match.MatchGuid, match.HomePlayer, (int)match.MatchRules.MatchType,  match.NextMatch);
        }
        
        if(match.NextMatch == Guid.Empty)
            return String.Format("Insert into match (matchguid, playerhome, playeraway, scorehome, scoreaway, matchtypeid, nextmatch)" + 
                                 " values ('{0}','{1}','{2}',0,0, {3}, '{4}')",
                match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType,  match.NextMatch);

        return String.Format("Insert into match (matchguid, playerhome, playeraway, scorehome, scoreaway, matchtypeid, nextmatch)" + 
                             " values ('{0}','{1}','{2}',0,0, {3}, '{4}')",
                match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType, match.NextMatch);
    }
    
    
    
    public static string UpdateMatch(MatchDTO match)
    {
        if (match.HomePlayer == null && match.AwayPlayer == null)
            return "";
        if(match.HomePlayer == null)
            return String.Format("Update match set scorehome = {0}, scoreaway= {1}, playeraway = '{2}' where matchguid = '{3}'",
                match.HomeScore, match.AwayScore,match.AwayPlayer, match.MatchGuid);
        if(match.AwayPlayer == null)
            return String.Format("Update match set scorehome = {0}, scoreaway= {1}, playerhome = '{2}' where matchguid = '{3}'",
                match.HomeScore, match.AwayScore,match.HomePlayer, match.MatchGuid);
        return String.Format("Update match set scorehome = {0}, scoreaway= {1}, playerhome = '{2}', playeraway = '{3}' where matchguid = '{4}'",
            match.HomeScore, match.AwayScore,match.HomePlayer,match.AwayPlayer, match.MatchGuid);
    }
    
    public static string GetMatch(Guid matchId)
    {
        return String.Format("select * from match, matchrules, matchtype, tournamentmatch where " +
                             "match.matchtypeid = matchrules.matchtypeid and match.matchtypeid = matchtype.matchtypeid and match.matchguid " +
                             "and match.matchguid = '{0}'", matchId);
    }
    
}