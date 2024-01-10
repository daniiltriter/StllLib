using Stll.Sessions.Primitives;

namespace Stll.Sessions.Types;

public class AuthContext
{
    public string Username { get; set; }
    public string Password { get; set; }
    public AuthAction Action { get; set; }
}