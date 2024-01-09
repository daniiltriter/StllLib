using System.Text.Json.Serialization;

namespace Stll.Library.Public.Results;

public class AuthBridgeTokenResult
{
    [JsonPropertyName("accessToken")]
    public string AccessToken { get; set; }
}