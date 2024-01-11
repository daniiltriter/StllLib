using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.IoC;
using Stll.Bridge.Sessions.Abstractions;
using Stll.Bridge.Sessions.Configurations;
using Stll.Bridge.Sessions.Services;
using Stll.Bridge.Sessions.Shared;

namespace Stll.Bridge.Sessions.IoC;

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
        
        builder.Services.AddSingleton<AuthSessionsFacade>();
        
        builder.Services.AddSingleton<ISessionStorage, SessionStorage>();
        builder.Services.AddSingleton<ISessionService, SessionService>();
    }
}