using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.IoC;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Configurations;
using Stll.Sessions.Services;
using Stll.Sessions.Shared;

namespace Stll.Sessions.IoC;

public static class StllServiceBuilderExtensions
{
    public static void WithStllSessions(this StllServiceBuilder builder, Action<AuthSettings> settingsModifier)
    {
        builder.Services.AddOptions<AuthSettings>();
        builder.Services.Configure(settingsModifier);

        builder.Services.AddSingleton<IAuthService, AuthService>();
        builder.Services.AddSingleton<IAuthStrategyResolver, AuthStrategyResolver>()
            .AddSingleton<LoginAuthStrategy>()
            .AddSingleton<SigninAuthStrategy>();
        
        builder.Services.AddSingleton<AuthorizationFacade>();
        
        builder.Services.AddSingleton<ISessionStorage, SessionStorage>();
        builder.Services.AddSingleton<ISessionService, SessionService>();
    }
}