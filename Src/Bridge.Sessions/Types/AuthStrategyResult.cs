using System.Text.Json.Serialization;

namespace Stll.Bridge.Sessions.Types;

public class AuthStrategyResult
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; }

    public AuthStrategyResult(string accessToken)
    {
        AccessToken = accessToken;
    }
}