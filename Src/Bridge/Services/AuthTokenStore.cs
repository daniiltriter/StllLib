using Stll.Bridge.Api.Abstractions;

namespace Stll.Bridge.Services;

internal class AuthTokenStore : IAuthTokenStore
{
    private string _token;
    public string GetToken()
    {
        return _token;
    }

    public void WriteToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        _token = token;
    }
}