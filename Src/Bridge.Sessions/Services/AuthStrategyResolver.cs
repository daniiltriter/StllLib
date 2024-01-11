using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Sessions.Abstractions;
using Stll.Bridge.Sessions.Primitives;

namespace Stll.Bridge.Sessions.Services;

internal class AuthStrategyResolver : IAuthStrategyResolver
{
    private readonly IServiceProvider _services;
    
    public AuthStrategyResolver(IServiceProvider services)
    {
        _services = services;
    }
    
    public IAuthStrategy Resolve(AuthAction action) => action switch
    {
        AuthAction.LogIn => _services.GetService<LoginAuthStrategy>(),
        AuthAction.SignIn => _services.GetService<SigninAuthStrategy>()
    };
}