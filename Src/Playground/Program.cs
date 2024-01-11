using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Abstractions;
using Stll.Bridge.IoC;
using Stll.Bridge.Settings;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Primitives;
using Stll.Sessions.Shared;
using Stll.Sessions.Types;

var services = new ServiceCollection();

services.AddOptions<ApiSettings>();
services.WithStllApiBridge(settings =>
{
    settings.ApiUrl = "http://127.0.0.1:5000";
    settings.SessionsPath = "sessions/user.json";
});

var provider = services.BuildServiceProvider();

var authFacade = provider.GetService<AuthSessionsFacade>();
var authContext = new AuthContext("username", "#Password123!", AuthAction.LogIn);
var sessionCreated = await authFacade.SessionAuthAsync(authContext);
Console.WriteLine($"Session created: {sessionCreated}");

var sessions = provider.GetService<ISessionService>();
sessions.RefreshAsync();

var currentSession = await sessions.CurrentAsync();
Console.WriteLine($"Current token: {currentSession.AccessToken}");

var stllApi = provider.GetService<IApiProvider>();
var user = await stllApi.UsersBridge.GetAsync();

Console.WriteLine($"Session created: {user.Success}");


#region OLD CODE

#if false
var stllApi = provider.GetService<IApiProvider>();
var registerUserRequest = new RegisterUserRequest("username", "#Password123!");
var registerResponse = await stllApi.UsersBridge.RegisterAsync(registerUserRequest);
if (!registerResponse.Success)
{
    Console.WriteLine($"CODE: {registerResponse.Code}; ERROR: {registerResponse.Error}");
}

var accessTokenRequest = new AuthTokenRequest("username", "#Password123!");
var tokenResponse = await stllApi.AuthBridge.GetTokenAsync(accessTokenRequest);
if (!tokenResponse.Success)
{
    Console.WriteLine($"CODE: {tokenResponse.Code}; ERROR: {tokenResponse.Error}");
}

if (!Directory.Exists("downloads"))
{
    Directory.CreateDirectory("downloads");
}

var fileResponse = await stllApi.FilesBridge.DownloadJavaAsync();

const string fileName = "downloads/jdk17.zip";

var file = await fileResponse.Content.ReadAsByteArrayAsync();
await using var fileStream = new FileStream(fileName, FileMode.Create);
await fileStream.WriteAsync(file);
#endif

#endregion
