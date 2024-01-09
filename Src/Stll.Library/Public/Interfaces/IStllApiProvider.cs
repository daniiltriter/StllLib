using Stll.Library.Implementation.Interfaces;

namespace Stll.Library.Abstractions;

public interface IStllApiProvider
{
    IAuthenticationBridge AuthBridge { get; }
}