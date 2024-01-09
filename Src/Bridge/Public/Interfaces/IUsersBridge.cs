using Stll.Bridge.Public.Results;
using Stll.Bridge.Public.Types;

namespace Stll.Library.Public.Interfaces;

public interface IUsersBridge
{
    Task<JsonBridgeResponse> RegisterAsync(RegisterUserRequest request);
}