using Stll.Sessions.Types;

namespace Stll.Sessions.Shared;

public interface ISessionStorage
{
    Task WriteAsync(Session session);

    Task<Session> CurrentAsync();

    bool Remove();
}