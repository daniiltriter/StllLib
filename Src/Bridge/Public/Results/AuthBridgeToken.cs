using System.Text.Json.Serialization;

namespace Stll.Bridge.Public.Results;

public class AuthBridgeToken
{
    [JsonPropertyName("accessToken")]
    public string Value { get; set; }
}