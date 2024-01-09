using Stll.Library.Implementation.Types;

namespace Stll.Library.Implementation.Interfaces;

public interface IAuthenticationBridge
{
    Task<string> GetTokenAsync(AuthTokenRequest request);
}