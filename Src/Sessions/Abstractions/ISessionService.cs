using Stll.Sessions.Types;

namespace Stll.Sessions.Abstractions;

public interface ISessionService
{
    void BuildSession(SessionContext context);
    Session CurrentSession();
}