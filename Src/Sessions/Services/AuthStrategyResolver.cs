﻿using Microsoft.Extensions.DependencyInjection;
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
    
    public IAuthStrategy Resolve(AuthAction action) => action switch
    {
        AuthAction.LogIn => _services.GetService<LoginAuthStrategy>(),
        AuthAction.SignIn => _services.GetService<SigninAuthStrategy>()
    };
}