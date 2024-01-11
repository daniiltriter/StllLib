using Stll.Sessions.Types;

namespace Stll.Sessions.Shared;

public interface ISessionStorage
{
    Task WriteAsync(SessionContext context);

    Task<Session> CurrentAsync();

    bool Remove();
}