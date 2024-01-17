using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Api.Objects;
using Stll.Bridge.Interfaces;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Results;
using Stll.Bridge.Types;

namespace Stll.Bridge.Services;

internal class AuthenticationBridge : IAuthenticationBridge
{
    private readonly IAuthenticationApi _api;

    public AuthenticationBridge(IServiceProvider services)
    {
        _api = services.GetService<IAuthenticationApi>();
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