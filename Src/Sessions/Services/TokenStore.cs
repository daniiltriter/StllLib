using Stll.Sessions.Abstractions;

namespace Stll.Sessions.Services;

internal class TokenStore : ITokenStore
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