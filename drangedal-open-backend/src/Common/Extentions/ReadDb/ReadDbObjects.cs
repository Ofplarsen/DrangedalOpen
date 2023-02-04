using Common.Models;
using Common.Models.DTOs;
using Common.Models.Login;
using Common.Models.Tournament;
using Npgsql;
using MatchType = Common.Models.Tournament.MatchType;

namespace Common.Extentions.ReadDb;

public static class ReadDbObjects
{
    
    public static Player ReadPlayer(NpgsqlDataReader reader)
    {
        return new()
        {
            Ranking = ReadRanking(reader),
            User = ReadUser(reader)
        };
    }
    
    public static PlayerDTO ReadPlayerDTO(NpgsqlDataReader reader)
    {
        return new()
        {
            Ranking = ReadRanking(reader),
            Username = (string) reader["username"]
        };
    }

    public static Ranking ReadRanking(NpgsqlDataReader reader)
    {
        return new Ranking()
        {
            Rating = reader.GetInt32(reader.GetOrdinal("rating")),
            GamesLost = reader.GetInt32(reader.GetOrdinal("gameslost")),
            GamesWon = reader.GetInt32(reader.GetOrdinal("gameswon"))
        };
    }
    
    public static User ReadUser(NpgsqlDataReader reader)
    {
        return new User()
        {
            Username = reader["username"] as string,
            FirstName = reader["firstname"] as string,
            LastName = reader["lastname"] as string,
            Email = reader["email"] as string,
            PhoneNumber = reader.GetInt32(reader.GetOrdinal("phonenumber"))
        };
    }

    public static UserLogin ReadUserLogin(NpgsqlDataReader reader)
    {
        string? username = reader["username"] as string;
        string? password = reader["password"] as string;
        return new() {Password = password, Username = username};
    }

    public static MatchDTO ReadMatchDTO(NpgsqlDataReader reader)
    {
        return new MatchDTO()
        {
            MatchGuid = (Guid) reader["matchguid"],
            HomePlayer = reader["playerhome"] != DBNull.Value ? (string) reader["playerhome"] : null,
            AwayPlayer = reader["playeraway"] != DBNull.Value ? (string) reader["playeraway"] : null,
            HomeScore = (int) reader["scorehome"],
            AwayScore = (int) reader["scoreaway"],
            MatchRules = new MatchRules()
            {
                MatchType = (MatchType) ((int) reader["matchtypeid"]),
                ScoreToWin = (int) reader["scoretowin"]
            },
            NextMatch = reader["nextmatch"] != DBNull.Value ? (Guid) reader["nextmatch"] : Guid.Empty,
            Winner = reader["winner"] != DBNull.Value ? (string) reader["winner"] : null
        };
    }
}