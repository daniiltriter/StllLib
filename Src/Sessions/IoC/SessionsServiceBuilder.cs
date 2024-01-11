using Microsoft.Extensions.DependencyInjection;
using Stll.Sessions.Services;

namespace Stll.Sessions.IoC;

public class SessionsServiceBuilder
{
    public IServiceCollection Services { get; }
    private SessionsServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public static SessionsServiceBuilder Initialize(IServiceCollection _services) => new(_services);

    public SessionsServiceBuilder AsLoginStrategy<TStrategy>() where TStrategy : LoginAuthStrategy
    {
        Services.AddSingleton<LoginAuthStrategy, TStrategy>();
        return this;
    }
    
    public SessionsServiceBuilder AsSigninStrategy<TStrategy>() where TStrategy : SigninAuthStrategy
    {
        Services.AddSingleton<SigninAuthStrategy, TStrategy>();
        return this;
    }
}