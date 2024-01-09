using Stll.Bridge.Abstractions;
using Stll.Bridge.Public.Interfaces;

namespace Stll.Bridge.Services;

internal class StllApiProvider : IStllApiProvider
{
    public StllApiProvider(IAuthenticationBridge authenticationBridge)
    {
        AuthBridge = authenticationBridge;
    }

    public IAuthenticationBridge AuthBridge { get; }
};
