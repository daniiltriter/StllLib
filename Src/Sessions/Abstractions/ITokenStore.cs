namespace Stll.Sessions.Abstractions;

internal interface ITokenStore
{
    string GetToken();
    void WriteToken(string token);
    void Clear();
}