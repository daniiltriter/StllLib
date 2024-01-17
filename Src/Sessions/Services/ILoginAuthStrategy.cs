using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public interface ILoginAuthStrategy : IAuthStrategy
{
    Task<AuthStrategyResult> AuthAsync(string name, string password);
}