using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Abstractions;
using Stll.Bridge.Implementation.Interfaces;
using Stll.Bridge.Implementation.Services;
using Stll.Bridge.Services;
using Stll.Bridge.Settings;

namespace Stll.Bridge.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection WithStllApi(this IServiceCollection services, Action<ApiSettings> settingsModifier)
    {
        services.AddOptions<ApiSettings>();
        services.Configure(settingsModifier);
        services.AddSingleton<IAuthenticationBridge, AuthenticationBridge>();

        services.AddSingleton<IStllApiProvider, StllApiProvider>();
        
        return services;
    }
}