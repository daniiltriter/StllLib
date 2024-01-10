using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class SessionService : ISessionService
{
    
    public void BuildSession(SessionContext context)
    {
        throw new NotImplementedException();
    }

    public Session CurrentSession()
    {
        return new Session();
    }
}