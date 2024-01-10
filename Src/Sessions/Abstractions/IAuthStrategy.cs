using Stll.Sessions.Types;

namespace Stll.Sessions.Abstractions;

public interface IAuthStrategy
{
    Task<AuthResult> AuthAsync();
}