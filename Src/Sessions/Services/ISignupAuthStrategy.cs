using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public interface ISignupAuthStrategy : IAuthStrategy
{
    Task<AuthStrategyResult> AuthAsync(string name, string password);
    
}