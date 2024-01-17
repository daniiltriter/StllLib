using Stll.Bridge.Results;
using Stll.Bridge.Types;

namespace Stll.Bridge.Interfaces;

public interface IAuthenticationBridge
{
    Task<JsonBridgeResponse> GetTokenAsync(AuthTokenRequest request);
}