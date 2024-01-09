using Stll.Bridge.Public.Types;
using Stll.Bridge.Public.Results;

namespace Stll.Bridge.Public.Interfaces;

public interface IAuthenticationBridge
{
    Task<JsonBridgeResponse> GetTokenAsync(AuthTokenRequest request);
}