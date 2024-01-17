using Stll.Bridge.Results;
using Stll.Bridge.Types;

namespace Stll.Bridge.Interfaces;

public interface IUsersBridge
{
    Task<JsonBridgeResponse> RegisterAsync(RegisterUserRequest request);

    Task<JsonBridgeResponse> GetAsync();
}