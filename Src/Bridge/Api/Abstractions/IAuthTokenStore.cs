namespace Stll.Bridge.Api.Abstractions;

public interface IAuthTokenStore
{
    string GetToken();
    void WriteToken(string token);
}