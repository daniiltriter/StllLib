using Microsoft.Extensions.Options;
using Refit;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Api.Objects;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Public.Results;
using Stll.Bridge.Public.Types;
using Stll.Bridge.Settings;

namespace Stll.Bridge.Public.Services;

internal class AuthenticationBridge : IAuthenticationBridge
{
    private readonly IAuthenticationApi _api;

    public AuthenticationBridge(IOptions<ApiSettings> settings)
    {
        _api = RestService.For<IAuthenticationApi>(settings.Value.ApiUrl);
    }
    
    public async Task<JsonBridgeResponse> GetTokenAsync(AuthTokenRequest request)
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