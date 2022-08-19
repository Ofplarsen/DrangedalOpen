using Common.Models;
using Common.Models.Login;
using Common.Models.Tournament;
using Npgsql;

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
}