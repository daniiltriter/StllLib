using Stll.Bridge.Sessions.Types;

namespace Stll.Bridge.Sessions.Abstractions;

public interface IAuthService
{
    Task<AuthResult> AuthorizeAsync(AuthContext context);
}