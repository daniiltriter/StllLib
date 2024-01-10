using Stll.Sessions.Types;

namespace Stll.Sessions.Abstractions;

public interface IAuthStrategy
{
    // TODO: can be refactored with a chain of responsibility design pattern
    Task<AuthStrategyResult> AuthAsync(string name, string password);
}