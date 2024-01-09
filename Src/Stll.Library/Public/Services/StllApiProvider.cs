using Stll.Library.Abstractions;
using Stll.Library.Implementation.Interfaces;

namespace Stll.Library.Services;

public class StllApiProvider : IStllApiProvider
{
    public StllApiProvider(IAuthenticationBridge authenticationBridge)
    {
        AuthBridge = authenticationBridge;
    }

    public IAuthenticationBridge AuthBridge { get; }
};
