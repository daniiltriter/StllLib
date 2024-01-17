namespace Stll.Bridge.Interfaces;

public interface IApiProvider
{
    IAuthenticationBridge AuthBridge { get; }
    IUsersBridge UsersBridge { get; }
    IFilesBridge FilesBridge { get; }
}