using Stll.Sessions.Primitives;

namespace Stll.Sessions.Abstractions;

public interface IAuthStrategyResolver
{
    IAuthStrategy Resolve(AuthAction action);
}