namespace Common.Models.Login;

public class UserLogin
{
    public string Username { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return Username + ", " + Password;
    }
}