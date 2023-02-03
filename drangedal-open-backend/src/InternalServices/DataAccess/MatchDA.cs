using Common.Database;
using Common.Models.DTOs;
using Common.Models.Tournament;
using InternalServices.DataAccess.Interfaces;
using InternalServices.DataAccess.SqlQuery;
using Npgsql;
using MatchType = Common.Models.Tournament.MatchType;

namespace InternalServices.DataAccess;

public class MatchDA : IMatchDA
{
    
    private readonly IDbConnection _connection;
    public MatchDA(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public Match UpdateMatch(Match match)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(MatchSql.UpdateMatch(match), con);

        cmd.ExecuteNonQuery();
        return match;
    }

    public MatchDTO CreateMatch(MatchDTO match)
    {
        using var con = _connection.Connect();
        using var cmd = new NpgsqlCommand(MatchSql.CreateMatch(match), con);

        cmd.ExecuteNonQuery();
        return match;
    }

    public List<MatchDTO> GetMatches(Guid tournamentId)
    {   
        var con = _connection.Connect();
        var matches = new List<MatchDTO>();
        using (con)
        {

            var cmd = new NpgsqlCommand(TournamentSql.GetMatchesFromTournament(tournamentId), con);
            using (cmd)
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        matches.Add(new MatchDTO()
                        {
                            MatchGuid = (Guid)reader["matchguid"],
                            HomePlayer = reader["playerhome"] != DBNull.Value ? (string)reader["playerhome"] : null,
                            AwayPlayer = reader["playeraway"] != DBNull.Value ? (string)reader["playeraway"] : null,
                            HomeScore = (int)reader["scorehome"],
                            AwayScore =  (int)reader["scoreaway"],
                            MatchRules = new MatchRules()
                            {
                                MatchType = (MatchType) ((int)reader["matchtypeid"]),
                                ScoreToWin = (int)reader["scoretowin"]
                            },
                            NextMatch = reader["nextmatch"] != DBNull.Value ? (Guid)reader["nextmatch"] : Guid.Empty,
                        });
                        
                    }
                }
            }
        }

        return matches;
    }
}