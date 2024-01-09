using Stll.Library.Implementation.Interfaces;

namespace Stll.Library.Abstractions;

public interface IApiProvider
{
    IAuthenticationBridge AuthenticationBridge { get; }
}