using Microsoft.Extensions.DependencyInjection;
using Refit;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Api.Interceptors;
using Stll.Bridge.Interfaces;
using Stll.Bridge.Services;
using Stll.Bridge.Settings;

namespace Stll.Bridge.IoC;

public static class ServiceCollectionExtensions
{
    public static BridgeServiceBuilder WithApiBridge(this IServiceCollection services, 
        Action<ApiSettings> settingsModifier)
    {
        var apiSettings = new ApiSettings();
        settingsModifier(apiSettings);
        services.AddOptions<ApiSettings>();
        services.Configure(settingsModifier);
        services.AddSingleton<IAuthenticationBridge, AuthenticationBridge>();
        services.AddSingleton<IAuthTokenStore, AuthTokenStore>();
        services.AddSingleton<IUsersBridge, UsersBridge>();
        services.AddSingleton<IFilesBridge, FilesBridge>();
        services.AddTransient<AuthorizeInterceptor>();

        var baseUri = new Uri(apiSettings.ApiUrl);
        services.AddApi<IAuthenticationApi>(baseUri);
        services.AddApi<IUsersApi>(baseUri).AddAuthInterceptor();
        services.AddApi<IFilesApi>(baseUri).AddAuthInterceptor();

        services.AddSingleton<IApiProvider, ApiProvider>();

        return BridgeServiceBuilder.Initialize(services);
    }

    private static IHttpClientBuilder AddApi<TApi>(this IServiceCollection services, Uri uri) 
        where TApi : class
    {
       return services.AddRefitClient<TApi>().ConfigureHttpClient(c => c.BaseAddress = uri);
    }
    
    private static IHttpClientBuilder AddAuthInterceptor(this IHttpClientBuilder services)
    {
        return services.AddHttpMessageHandler(services => new AuthorizeInterceptor(services));
    }
}
