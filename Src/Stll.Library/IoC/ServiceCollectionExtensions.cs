using Microsoft.Extensions.DependencyInjection;
using Stll.Library.Abstractions;
using Stll.Library.Implementation.Interfaces;
using Stll.Library.Implementation.Services;
using Stll.Library.Services;
using Stll.Library.Settings;

namespace Stll.Library.IoC;

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