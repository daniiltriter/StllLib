using Stll.Bridge.Sessions.Types;

namespace Stll.Bridge.Sessions.Abstractions;

public interface ISessionService
{
    Task CreateAsync(SessionContext context);
    Task<Session> CurrentAsync();
    Task RefreshAsync();
    bool Remove();
}