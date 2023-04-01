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
                return String.Format("Insert into match (matchguid, matchtypeid)" + 
                    " values ('{0}', {1}); INSERT INTO matchinfo(matchguid) values ('{0}')",
                    match.MatchGuid,  (int)match.MatchRules.MatchType);
            
            return String.Format("Insert into match (matchguid,  matchtypeid, nextmatch)" + 
                                 " values ('{0}', {1}, '{2}'); INSERT INTO matchinfo(matchguid) values ('{0}')",
                match.MatchGuid,  (int)match.MatchRules.MatchType,  match.NextMatch);
        }
        

        if (match.AwayPlayer == null)
        {
            if(match.NextMatch == Guid.Empty)
                return String.Format("Insert into match (matchguid, matchtypeid)" + 
                                     " values ('{0}', {2}); INSERT INTO matchinfo(matchguid, playerhome, winner) values ('{0}', '{1}', '{1}')",
                    match.MatchGuid, match.HomePlayer, (int)match.MatchRules.MatchType);
            return String.Format("Insert into match (matchguid, matchtypeid, nextmatch)" + 
                                 " values ('{0}', {2}, '{3}'); INSERT INTO matchinfo(matchguid, playerhome, winner) values ('{0}', '{1}', '{1}')",
                match.MatchGuid, match.HomePlayer, (int)match.MatchRules.MatchType,  match.NextMatch);
        }
        
        if(match.NextMatch == Guid.Empty)
            return String.Format("Insert into match (matchguid, matchtypeid, nextmatch)" + 
                                 " values ('{0}', {3}, '{4}'); INSERT INTO matchinfo(matchguid, playerhome, playeraway) values ('{0}', '{1}', '{2}')",
                match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType,  match.NextMatch);

        return String.Format("Insert into match (matchguid, matchtypeid, nextmatch)" + 
                             " values ('{0}', {3}, '{4}');INSERT INTO matchinfo(matchguid, playerhome, playeraway) values ('{0}', '{1}', '{2}')",
                match.MatchGuid, match.HomePlayer, match.AwayPlayer, (int)match.MatchRules.MatchType, match.NextMatch);
    }
    
    public static string GetMatchesPlayer(String username)
    {
        return String.Format("select * from match, matchinfo, matchtype, matchrules where (playeraway = '{0}' or playerhome = '{0}') and match.matchguid = matchinfo.matchguid"
        + " and match.matchtypeid = matchrules.matchtypeid and match.matchtypeid = matchtype.matchtypeid", username);
    }
    
    public static string GetMatchesPlayerUpcoming(String username)
    {
        return String.Format("select * from match, matchinfo, matchtype, matchrules where (playeraway = '{0}' or playerhome = '{0}')"
        + "and match.matchtypeid = matchrules.matchtypeid and match.matchtypeid = matchtype.matchtypeid and match.matchguid = matchinfo.matchguid and  matchinfo.winner is null", username);
        
    }
    
    public static string UpdateMatch(MatchDTO match)
    {
        if (match.HomePlayer == null && match.AwayPlayer == null)
            return "";
        if(match.HomePlayer == null)
            return String.Format("Update matchinfo set scorehome = {0}, scoreaway= {1}, playeraway = '{2}' where matchguid = '{3}'",
                match.HomeScore, match.AwayScore,match.AwayPlayer, match.MatchGuid);
        if(match.AwayPlayer == null)
            return String.Format("Update matchinfo set scorehome = {0}, scoreaway= {1}, playerhome = '{2}' where matchguid = '{3}'",
                match.HomeScore, match.AwayScore,match.HomePlayer, match.MatchGuid);
        return String.Format("Update matchinfo set scorehome = {0}, scoreaway= {1}, playerhome = '{2}', playeraway = '{3}' where matchguid = '{4}'",
            match.HomeScore, match.AwayScore,match.HomePlayer,match.AwayPlayer, match.MatchGuid);
    }

    public static string SetWinner(MatchDTO match, bool playerHome)
    {
        if (playerHome)
            return String.Format(
            "Update matchinfo set winner = '{0}' where matchguid = '{1}'",
            match.HomePlayer, match.MatchGuid);
        return String.Format(
            "Update matchinfo set winner = '{0}' where matchguid = '{1}'",
            match.AwayPlayer, match.MatchGuid);
    }
    
    public static string GetMatch(Guid matchId)
    {
        return String.Format("select distinct match.*, matchinfo.*, matchrules.*, matchtype.*  from match, matchrules, "+
                             "matchinfo, matchtype, tournamentmatch where match.matchtypeid = matchrules.matchtypeid and "+
                             "match.matchtypeid = matchtype.matchtypeid and matchinfo.matchguid = match.matchguid and match.matchguid = '{0}'", matchId);
    }
    
}