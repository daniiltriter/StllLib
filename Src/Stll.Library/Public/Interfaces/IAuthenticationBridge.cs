using Stll.Library.Implementation.Types;
using Stll.Library.Public.Results;

namespace Stll.Library.Implementation.Interfaces;

public interface IAuthenticationBridge
{
    Task<ApiBridgeResponse<AuthBridgeTokenResult>> GetTokenAsync(AuthTokenRequest request);
}