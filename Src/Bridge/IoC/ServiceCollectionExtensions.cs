using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Abstractions;
using Stll.Bridge.Public.Services;
using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Services;
using Stll.Bridge.Settings;
using Stll.Library.Public.Interfaces;
using Stll.Library.Public.Services;

namespace Stll.Bridge.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection WithStllApi(this IServiceCollection services, Action<ApiSettings> settingsModifier)
    {
        services.AddOptions<ApiSettings>();
        services.Configure(settingsModifier);
        
        services.AddSingleton<IAuthenticationBridge, AuthenticationBridge>();
        services.AddSingleton<IUsersBridge, UsersBridge>();
        services.AddSingleton<IFilesBridge, FilesBridge>();

        services.AddSingleton<IApiProvider, ApiProvider>();
        
        return services;
    }
}