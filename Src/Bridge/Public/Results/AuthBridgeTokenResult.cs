using System.Text.Json.Serialization;

namespace Stll.Bridge.Public.Results;

public class AuthBridgeTokenResult
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
}