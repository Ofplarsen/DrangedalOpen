namespace Common.Models;

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PhoneNumber { get; set; }
    public UserStatus UserStatus { get; set; } = UserStatus.Active;
}