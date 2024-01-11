namespace Stll.Bridge.Sessions.Types;

public class SessionContext
{
    public SessionContext(string username, string accessToken)
    {
        Username = username;
        AccessToken = accessToken;
    }

    public string Username { get; set; }
    public string AccessToken { get; set; }
    
    public string ClientToken { get; set; }
}