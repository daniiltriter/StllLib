using Stll.Sessions.Types;

namespace Stll.Sessions.Abstractions;

public interface IAuthService
{
    Task<AuthResult> AuthorizeAsync(AuthContext context);
}