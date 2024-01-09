using Stll.Library.Abstractions;
using Stll.Library.Implementation.Interfaces;

namespace Stll.Library.Services;

public class ApiProvider : IApiProvider
{
    public ApiProvider(IAuthenticationBridge authenticationBridge)
    {
        AuthenticationBridge = authenticationBridge;
    }

    public IAuthenticationBridge AuthenticationBridge { get; }
};
