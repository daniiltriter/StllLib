using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class SigninAuthStrategy : IAuthStrategy
{
    public async Task<AuthResult> AuthAsync()
    {
         return new AuthResult();
    }
}