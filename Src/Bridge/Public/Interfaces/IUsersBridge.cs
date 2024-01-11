using Stll.Bridge.Public.Results;
using Stll.Bridge.Public.Types;

namespace Stll.Bridge.Public.Interfaces;

public interface IUsersBridge
{
    Task<JsonBridgeResponse> RegisterAsync(RegisterUserRequest request);

    Task<JsonBridgeResponse> GetAsync();
}