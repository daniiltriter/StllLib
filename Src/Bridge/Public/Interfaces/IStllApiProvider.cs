using Stll.Bridge.Implementation.Interfaces;

namespace Stll.Bridge.Abstractions;

public interface IStllApiProvider
{
    IAuthenticationBridge AuthBridge { get; }
}