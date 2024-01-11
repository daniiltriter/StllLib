using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Api.Objects;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Public.Results;
using Stll.Bridge.Public.Types;

namespace Stll.Bridge.Public.Services;

internal class AuthenticationBridge : IAuthenticationBridge
{
    private readonly IAuthenticationApi _api;

    public AuthenticationBridge(IServiceProvider _services)
    {
        _api = _services.GetService<IAuthenticationApi>();
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