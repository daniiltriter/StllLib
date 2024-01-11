using System.Text.Json.Serialization;

namespace Stll.Sessions.Types;

public class Session
{
    [JsonConstructor]
    public Session(string username, string accessToken, string clientToken)
    {
        Username = username;
        AccessToken = accessToken;
        ClientToken = clientToken;
    }
    
    [JsonPropertyName("username")]
    public string Username { get; set; }
    
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
    
    [JsonPropertyName("clientToken")]
    public string ClientToken { get; set; }
}