using Stll.Bridge.Implementation.Types;
using Stll.Bridge.Public.Results;

namespace Stll.Bridge.Implementation.Interfaces;

public interface IAuthenticationBridge
{
    Task<ApiBridgeResponse> GetTokenAsync(AuthTokenRequest request);
}