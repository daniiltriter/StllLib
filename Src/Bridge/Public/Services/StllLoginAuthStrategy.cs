using System.Text.Json;
using Stll.Bridge.Abstractions;
using Stll.Bridge.Public.Types;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Services;
using Stll.Sessions.Types;

namespace Stll.Bridge.Services;

public class StllLoginAuthStrategy : LoginAuthStrategy
{
    private readonly IApiProvider _api;
    public StllLoginAuthStrategy(IApiProvider api)
    {
        _api = api;
    }
    public override async Task<AuthStrategyResult> AuthAsync(string name, string password)
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