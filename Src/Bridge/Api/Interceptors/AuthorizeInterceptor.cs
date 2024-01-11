using System.Net.Http.Headers;
using Stll.Library.Public.Interfaces;

namespace Stll.Library.Api.Interceptors;

internal class AuthorizeInterceptor : DelegatingHandler
{
    private readonly IAuthTokenStore _authToken;

    public AuthorizeInterceptor(IAuthTokenStore authToken)
    {
        _authToken = authToken;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = _authToken.GetToken();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}