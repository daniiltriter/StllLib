using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Abstractions;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Configurations;
using Stll.Sessions.Services;
using Stll.Sessions.Shared;

namespace Stll.Sessions.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection WithStllSessions(this IServiceCollection services, Action<AuthSettings> settingsModifier)
    {
        services.AddOptions<AuthSettings>();
        services.Configure(settingsModifier);

        services.AddSingleton<IAuthService, AuthService>();
        services.AddSingleton<IAuthStrategyResolver, AuthStrategyResolver>()
            .AddSingleton<LoginAuthStrategy>()
            .AddSingleton<SigninAuthStrategy>();
        
        services.AddSingleton<AuthorizationFacade>();
        
        services.AddSingleton<IFileService, FileService>();
        services.AddSingleton<ISessionService, SessionService>();

        return services;
    }
}