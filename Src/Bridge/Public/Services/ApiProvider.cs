using Stll.Bridge.Abstractions;
using Stll.Bridge.Public.Interfaces;

namespace Stll.Bridge.Services;

internal class ApiProvider : IApiProvider
{
    public ApiProvider(IAuthenticationBridge authentication, IUsersBridge users, IFilesBridge files)
    {
        AuthBridge = authentication;
        UsersBridge = users;
        FilesBridge = files;
    }

    public IAuthenticationBridge AuthBridge { get; }
    public IUsersBridge UsersBridge { get; }
    public IFilesBridge FilesBridge { get; }
};
