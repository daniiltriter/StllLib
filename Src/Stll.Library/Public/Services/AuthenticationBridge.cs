using Microsoft.Extensions.Options;
using Refit;
using Stll.Library.Api.Interfaces;
using Stll.Library.Api.Objects;
using Stll.Library.Implementation.Interfaces;
using Stll.Library.Implementation.Types;
using Stll.Library.Settings;

namespace Stll.Library.Implementation.Services;

public class AuthenticationBridge : IAuthenticationBridge
{
    private readonly IAuthenticationApi _api;

    public AuthenticationBridge(IOptions<ApiSettings> settings)
    {
        _api = RestService.For<IAuthenticationApi>(settings.Value.ApiUrl);
    }
    
    public async Task<string> GetTokenAsync(AuthTokenRequest request)
    {
        var apiRequest = new JwtTokenApiRequest
        {
            Name = request.Name,
            Password = request.Password
        };
        return await _api.Token(apiRequest);
    }
}