using Stll.Bridge.Sessions.Types;

namespace Stll.Bridge.Sessions.Abstractions;

internal interface IAuthStrategy
{
    // TODO: can be refactored with a chain of responsibility design pattern
    Task<AuthStrategyResult> AuthAsync(string name, string password);
}