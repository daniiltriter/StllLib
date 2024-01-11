using Stll.Bridge.Sessions.Types;

namespace Stll.Bridge.Sessions.Shared;

public interface ISessionStorage
{
    Task WriteAsync(Session session);

    Task<Session> CurrentAsync();

    bool Remove();
}