using System.Text.Json.Serialization;

namespace Stll.Sessions.Types;

public class AuthStrategyResult
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; }

    public AuthStrategyResult(string accessToken)
    {
        AccessToken = accessToken;
    }
}