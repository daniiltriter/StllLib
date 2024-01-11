namespace Stll.Library.Public.Interfaces;

public interface IAuthTokenStore
{
    string GetToken();
    void WriteToken(string token);
    void Clear();
}