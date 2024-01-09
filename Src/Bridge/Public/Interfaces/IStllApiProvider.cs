using Stll.Bridge.Public.Interfaces;

namespace Stll.Bridge.Abstractions;

public interface IStllApiProvider
{
    IAuthenticationBridge AuthBridge { get; }
}