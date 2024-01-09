namespace Stll.Bridge.Public.Types;

public class AuthTokenRequest
{
    public string Name { get; set; } 
    public string Password { get; set; } 
    
    public AuthTokenRequest(string name, string password)
    {
        Name = name;
        Password = password;
    }
}