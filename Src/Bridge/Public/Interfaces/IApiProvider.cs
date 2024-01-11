using Stll.Bridge.Public.Interfaces;

namespace Stll.Bridge.Abstractions;

public interface IApiProvider
{
    IAuthenticationBridge AuthBridge { get; }
    IUsersBridge UsersBridge { get; }
    IFilesBridge FilesBridge { get; }
}