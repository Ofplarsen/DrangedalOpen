namespace InternalServices.DataAccess.SqlQuery;

public static class PlayerSql
{
    public static string GetPlayers()
    {
        return String.Format("select p.username, firstname, lastname, phonenumber, email, rating, gameswon, gameslost from " +
                             "\"user\" join player p on \"user\".username = p.username join ranking r on p.username = r.username");
    }
    
    public static string GetPlayersSimple()
    {
        return String.Format("select p.username, rating, gameswon, gameslost from " +
                             "\"user\" join player p on \"user\".username = p.username join ranking r on p.username = r.username");
    }
}