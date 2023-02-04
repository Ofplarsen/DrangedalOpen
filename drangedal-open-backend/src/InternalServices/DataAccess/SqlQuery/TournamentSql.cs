using Common.Models.DTOs;
using Common.Models.Tournament;

namespace InternalServices.DataAccess.SqlQuery;

public static class TournamentSql
{
    public static string CreateTournament(TournamentDTO tournament)
    {
        return String.Format("Insert into tournament (tournamentguid, name)" + 
            " values ('{0}','{1}')",
            tournament.TournamentGuid, tournament.Name);
    }

    public static string MapTournamentMatch(Guid tournamentGuid, Guid matchGuid)
    {

        return String.Format("Insert into tournamentmatch (tournamentguid, matchguid)" + 
                             " values ('{0}','{1}')",
            tournamentGuid, matchGuid);
    }

    public static string GetMatchesFromTournament(Guid tournamentId)
    {
        return String.Format("select * from match,matchinfo, matchrules, matchtype, tournamentmatch where " +
        "match.matchtypeid = matchrules.matchtypeid and match.matchtypeid = matchtype.matchtypeid and match.matchguid " +
            "= tournamentmatch.matchguid and matchinfo.matchguid = match.matchguid " +
            "and tournamentmatch.tournamentguid = '{0}'", tournamentId);
    }
}