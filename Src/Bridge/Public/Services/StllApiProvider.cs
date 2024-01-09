using Stll.Bridge.Abstractions;
using Stll.Bridge.Public.Interfaces;
using Stll.Library.Public.Interfaces;

namespace Stll.Bridge.Services;

internal class StllApiProvider : IStllApiProvider
{
    public StllApiProvider(IAuthenticationBridge authentication, IUsersBridge users)
    {
        AuthBridge = authentication;
        UsersBridge = users;
    }

    public IAuthenticationBridge AuthBridge { get; }
    public IUsersBridge UsersBridge { get; }
};
