using Microsoft.Extensions.Options;
using Refit;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Api.Objects;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Public.Results;
using Stll.Bridge.Public.Types;
using Stll.Bridge.Settings;
using Stll.Library.Public.Interfaces;

namespace Stll.Library.Public.Services;

public class UsersBridge : IUsersBridge
{
    private readonly IUsersApi _api;

    public UsersBridge(IOptions<ApiSettings> settings)
    {
        _api = RestService.For<IUsersApi>(settings.Value.ApiUrl);
    }
    
    public async Task<ApiBridgeResponse> RegisterAsync(RegisterUserRequest request)
    {
        var apiRequest = new RegisterUserApiRequest
        {
            Name = request.Name,
            Password = request.Password
        };
        var apiResponse = await _api.RegisterAsync(apiRequest);
        return apiResponse.ToBridgeResponse();
    }
}