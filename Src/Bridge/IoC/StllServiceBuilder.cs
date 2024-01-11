using Microsoft.Extensions.DependencyInjection;

namespace Stll.Bridge.IoC;

public class StllServiceBuilder
{
    public IServiceCollection Services { get; }
    private StllServiceBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public static StllServiceBuilder Initialize(IServiceCollection _services) => new(_services);
}