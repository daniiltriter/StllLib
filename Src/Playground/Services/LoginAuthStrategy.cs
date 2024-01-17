using System.Text.Json;
using Stll.Bridge.Interfaces;
using Stll.Bridge.Types;
using Stll.Sessions.Services;
using Stll.Sessions.Types;

namespace Stll.Playground.Services;

public class LoginAuthStrategy : ILoginAuthStrategy
{
    private readonly IApiProvider _api;
    public LoginAuthStrategy(IApiProvider api)
    {
        _api = api;
    }
    public async Task<AuthStrategyResult> AuthAsync(string name, string password)
    {
        var authRequest = new AuthTokenRequest(name, password);
        var authResponse = await _api.AuthBridge.GetTokenAsync(authRequest);
        if (!authResponse.Success)
        {
            return new AuthStrategyResult(string.Empty);
        }
    
        // TODO: make IApiResponseParser service into the Bridge project
        return JsonSerializer.Deserialize<AuthStrategyResult>(authResponse.Content);
    }
}