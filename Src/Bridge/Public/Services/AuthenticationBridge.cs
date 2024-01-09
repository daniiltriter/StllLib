using System.Text.Json;
using Microsoft.Extensions.Options;
using Refit;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Api.Interfaces;
using Stll.Bridge.Api.Objects;
using Stll.Bridge.Implementation.Interfaces;
using Stll.Bridge.Implementation.Types;
using Stll.Bridge.Public.Results;
using Stll.Bridge.Settings;

namespace Stll.Bridge.Implementation.Services;

internal class AuthenticationBridge : IAuthenticationBridge
{
    private readonly IAuthenticationApi _api;

    public AuthenticationBridge(IOptions<ApiSettings> settings)
    {
        _api = RestService.For<IAuthenticationApi>(settings.Value.ApiUrl);
    }
    
    public async Task<ApiBridgeResponse> GetTokenAsync(AuthTokenRequest request)
    {
        var apiRequest = new JwtTokenApiRequest
        {
            Name = request.Name,
            Password = request.Password
        };
        var apiResponse = await _api.Token(apiRequest);
        return apiResponse.ToBridgeResponse();
    }
}