using Common.Models.Login;

namespace InternalServices.DataAccess.SqlQuery;

public static class UserSql
{
    public static string RegisterUser(UserRegister user)
    {
        return String.Format("Insert Into \"user\"(username, firstname, lastname, phonenumber, email, password) values "+
        "('{0}', '{1}', '{2}', {3}, '{4}', '{5}'); INSERT into player(username) values ('{0}'); insert into "
        +"ranking (username) values ('{0}')",
            user.Username, user.FirstName, user.LastName, user.PhoneNumber, user.Email, user.Password);
    }
    
    
    public static string GetUserLogin(string username)
    {
        return String.Format("Select username, password from \"user\" where username = '{0}'", username);
    }

    public static string GetUser(string username)
    {
        return String.Format("Select username, firstname, lastname, phonenumber, email from \"user\" where username = '{0}'", username);
    }
    
    public static string GetPlayer(string username)
    {
        return String.Format("select p.username, firstname, lastname, phonenumber, email, rating, gameswon, gameslost from " +
        "\"user\" join player p on \"user\".username = p.username join ranking r on p.username = r.username where \"user\".username = '{0}'", username);
    }
}