using Stll.Bridge.Abstractions;
using Stll.Bridge.Implementation.Interfaces;

namespace Stll.Bridge.Services;

public class StllApiProvider : IStllApiProvider
{
    public StllApiProvider(IAuthenticationBridge authenticationBridge)
    {
        AuthBridge = authenticationBridge;
    }

    public IAuthenticationBridge AuthBridge { get; }
};
