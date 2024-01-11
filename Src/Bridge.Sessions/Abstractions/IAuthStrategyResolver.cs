using Stll.Bridge.Sessions.Primitives;

namespace Stll.Bridge.Sessions.Abstractions;

internal interface IAuthStrategyResolver
{
    IAuthStrategy Resolve(AuthAction action);
}