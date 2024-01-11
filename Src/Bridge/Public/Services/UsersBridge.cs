using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Api.Objects;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Public.Results;
using Stll.Bridge.Public.Types;

namespace Stll.Bridge.Public.Services;

public class UsersBridge : IUsersBridge
{
    private readonly IUsersApi _api;

    public UsersBridge(IServiceProvider _services)
    {
        _api = _services.GetService<IUsersApi>();
    }
    
    public async Task<JsonBridgeResponse> RegisterAsync(RegisterUserRequest request)
    {
        var apiRequest = new RegisterUserApiRequest
        {
            Name = request.Name,
            Password = request.Password
        };
        var apiResponse = await _api.RegisterAsync(apiRequest);
        return apiResponse.ToBridgeResponse();
    }

    public async Task<JsonBridgeResponse> GetAsync()
    {
        var apiResponse = await _api.GetAsync();
        return apiResponse.ToBridgeResponse();
    }
}