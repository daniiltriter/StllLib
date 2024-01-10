using Stll.Sessions.Abstractions;
using Stll.Sessions.Primitives;

namespace Stll.Sessions.Services;

public class AuthStrategyResolver : IAuthStrategyResolver
{
    private readonly IServiceProvider _services;
    
    public AuthStrategyResolver(IServiceProvider services)
    {
        _services = services;
    }
    
    public IAuthStrategy Resolve(AuthAction action)
    {
        throw new NotImplementedException();
    }
}