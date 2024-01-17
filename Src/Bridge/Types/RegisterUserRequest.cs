namespace Stll.Bridge.Types;

public class RegisterUserRequest
{
    public string Name { get; set; }
    public string Password { get; set; }
    
    public RegisterUserRequest(string name, string password)
    {
        Name = name;
        Password = password;
    }
}