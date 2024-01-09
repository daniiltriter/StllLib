using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Abstractions;
using Stll.Bridge.Public.Types;
using Stll.Bridge.IoC;
using Stll.Bridge.Settings;using StreamWriter = System.IO.StreamWriter;

var services = new ServiceCollection();

services.AddOptions<ApiSettings>();
services.WithStllApi(settings =>
{
    settings.ApiUrl = "http://127.0.0.1:5000";
});

var provider = services.BuildServiceProvider();

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

Console.WriteLine(tokenResponse.Content);
