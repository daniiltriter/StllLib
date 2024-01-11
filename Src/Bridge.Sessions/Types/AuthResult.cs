namespace Stll.Bridge.Sessions.Types;

public class AuthResult
{
    public string AccessToken { get; set; }

    public AuthResult(string accessToken)
    {
        AccessToken = accessToken;
    }
}