namespace Stll.Sessions.Abstractions;

public interface IAuthTokenStore
{
    string GetToken();
    void WriteToken(string token);
    void Clear();
}