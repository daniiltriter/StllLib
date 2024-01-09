using Stll.Bridge.Public.Interfaces;
using Stll.Library.Public.Interfaces;

namespace Stll.Bridge.Abstractions;

public interface IStllApiProvider
{
    IAuthenticationBridge AuthBridge { get; }
    IUsersBridge UsersBridge { get; }
}