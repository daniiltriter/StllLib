using Microsoft.Extensions.DependencyInjection;
using Refit;
using Stll.Bridge.Abstractions;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Public.Services;
using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Services;
using Stll.Bridge.Settings;
using Stll.Bridge.Api.Interceptors;

namespace Stll.Bridge.IoC;

public static class ServiceCollectionExtensions
{
    public static StllServiceBuilder WithStllApiBridge(this IServiceCollection services, 
        Action<ApiSettings> settingsModifier)
    {
        var settings = new ApiSettings();
        settingsModifier(settings);
        services.AddOptions<ApiSettings>();
        services.Configure(settingsModifier);
        services.AddSingleton<IAuthenticationBridge, AuthenticationBridge>();
        services.AddSingleton<IUsersBridge, UsersBridge>();
        services.AddSingleton<IFilesBridge, FilesBridge>();
        // services.AddTransient<AuthorizeInterceptor>();

        var baseUri = new Uri(settings.ApiUrl);
        services.AddApi<IAuthenticationApi>(baseUri);
        services.AddApi<IUsersApi>(baseUri).AddAuthInterceptor();
        services.AddApi<IFilesApi>(baseUri).AddAuthInterceptor();

        services.AddSingleton<IApiProvider, ApiProvider>();
        services.AddSingleton<IAuthTokenStore, AuthTokenStore>();
        
        return StllServiceBuilder.Initialize(services);
    }

    private static IHttpClientBuilder AddApi<TApi>(this IServiceCollection services, Uri uri) 
        where TApi : class
    {
       return services.AddRefitClient<TApi>()
            .ConfigureHttpClient(c => c.BaseAddress = uri);
    }
    
    private static IHttpClientBuilder AddAuthInterceptor(this IHttpClientBuilder services)
    {
        return services.AddHttpMessageHandler(services => new AuthorizeInterceptor(services));
    }
}
