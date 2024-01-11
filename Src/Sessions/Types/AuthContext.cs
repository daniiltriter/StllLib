using Stll.Sessions.Primitives;

namespace Stll.Sessions.Types;

public class AuthContext
{
    public AuthContext(string username, string password, AuthAction action)
    {
        Username = username;
        Password = password;
        Action = action;
    }

    public string Username { get; set; }
    public string Password { get; set; }
    public AuthAction Action { get; set; }
}