namespace Stll.Sessions.Types;

public class Session
{
    public Session(string username, string accessToken, string clientToken)
    {
        Username = username;
        AccessToken = accessToken;
        ClienToken = clientToken;
    }

    public string Username { get; set; }
    public string AccessToken { get; set; }
    
    public string ClienToken { get; set; }
}