using Microsoft.Extensions.DependencyInjection;

namespace Stll.Bridge.IoC;

public class BridgeServiceBuilder
{
    public IServiceCollection Services { get; }
    private BridgeServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public static BridgeServiceBuilder Initialize(IServiceCollection _services) => new(_services);
}