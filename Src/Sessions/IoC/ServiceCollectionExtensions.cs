using Microsoft.Extensions.DependencyInjection;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Configurations;
using Stll.Sessions.Services;
using Stll.Sessions.Shared;

namespace Stll.Sessions.IoC;

public static class ServiceCollectionExtensions
{
    public static SessionsServiceBuilder AddSessions(this IServiceCollection services, Action<AuthSettings> settingsModifier)
    {
        services.AddOptions<AuthSettings>();
        services.Configure(settingsModifier);

        services.AddSingleton<IAuthService, AuthService>();
        services.AddSingleton<IAuthStrategyResolver, AuthStrategyResolver>();
        services.AddSingleton<IAuthTokenStore, AuthTokenStore>();
        
        services.AddSingleton<ISessionStorage, SessionStorage>();
        services.AddSingleton<ISessionService, SessionService>();
        
        services.AddSingleton<AuthSessionsFacade>();

        return SessionsServiceBuilder.Initialize(services);
    }
}

