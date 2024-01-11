using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public abstract class SigninAuthStrategy : IAuthStrategy
{
    // public SigninAuthStrategy(IApiProvider api)
    // {
    //     _api = api;
    // }
    public abstract Task<AuthStrategyResult> AuthAsync(string name, string password);
    // {
    //     var registerRequest = new RegisterUserRequest(name, password);
    //     
    //     var registerResult = await _api.UsersBridge.RegisterAsync(registerRequest);
    //     if (!registerResult.Success)
    //     {
    //         // TODO: use any logger. 
    //         return new AuthStrategyResult(string.Empty);
    //     }
    //     
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