using Stll.Bridge.Public.Interfaces;

namespace Stll.Bridge.Public.Services;

internal class AuthTokenStore : IAuthTokenStore
{
    private string _token = string.Empty;
    public string GetToken()
    {
        return _token;
    }

    public void WriteToken(string token)
    {
        var isEmpty = string.IsNullOrWhiteSpace(token);
        if (isEmpty)
        {
            return;
        }
        
        _token = token;
    }

    public void Clear()
    {
        _token = string.Empty;
    }
}