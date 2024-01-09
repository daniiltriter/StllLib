using Microsoft.Extensions.DependencyInjection;
using Stll.Library.Abstractions;
using Stll.Library.Implementation.Types;
using Stll.Library.IoC;
using Stll.Library.Settings;

var services = new ServiceCollection();

services.AddOptions<ApiSettings>();
services.WithStllApi(settings =>
{
    settings.ApiUrl = "http://127.0.0.1:5000";
});

var provider = services.BuildServiceProvider();

var stllApi = provider.GetService<IStllApiProvider>();

var tokenRequest = new AuthTokenRequest
{
    Name = "user",
    Password = "password"
};

var bridgeResult = await stllApi.AuthBridge.GetTokenAsync(tokenRequest);


Console.WriteLine(bridgeResult.Value.AccessToken);
