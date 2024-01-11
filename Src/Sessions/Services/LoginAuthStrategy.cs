using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public abstract class LoginAuthStrategy : IAuthStrategy
{
    // private readonly IApiProvider _api;
    // public LoginAuthStrategy(IApiProvider api)
    // {
    //     _api = api;
    // }
    public abstract Task<AuthStrategyResult> AuthAsync(string name, string password);
    // {
    //     var authRequest = new AuthTokenRequest(name, password);
    //     var authResponse = await _api.AuthBridge.GetTokenAsync(authRequest);
    //     if (!authResponse.Success)
    //     {
    //         return new AuthStrategyResult(string.Empty);
    //     }
    //
    //     // TODO: make IApiResponseParser service into the Bridge project
    //     return JsonSerializer.Deserialize<AuthStrategyResult>(authResponse.Content);
    // }
}