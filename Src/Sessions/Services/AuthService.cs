﻿using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class AuthService : IAuthService
{
    private readonly IAuthStrategyResolver _resolver;

    public AuthService(IAuthStrategyResolver resolver)
    {
        _resolver = resolver;
    }

    public async Task<AuthResult> AuthorizeAsync(AuthContext context)
    {
        var authStrategy = _resolver.Resolve(context.Action);
        var strategyResult = await authStrategy.AuthAsync(context.Username, context.Password);
        return new AuthResult(strategyResult.AccessToken);
    }
}