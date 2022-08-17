using Common.Models.Login;

namespace InternalServices.DataAccess.Sql;

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
}