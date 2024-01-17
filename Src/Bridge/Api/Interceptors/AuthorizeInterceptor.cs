using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Interfaces;
using Stll.Sessions.Abstractions;

namespace Stll.Bridge.Api.Interceptors;

internal class AuthorizeInterceptor : DelegatingHandler
{
    private readonly IAuthTokenStore _authToken;

    public AuthorizeInterceptor(IServiceProvider services, bool useDI = true)
    {
        _authToken = services.GetService<IAuthTokenStore>();
        //DI InnerHandler null bugfix
        if (useDI) return;
        InnerHandler = new HttpClientHandler();
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _authToken.GetToken();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}