namespace Stll.Bridge.Public.Interfaces;

public interface IAuthTokenStore
{
    string GetToken();
    void WriteToken(string token);
    void Clear();
}