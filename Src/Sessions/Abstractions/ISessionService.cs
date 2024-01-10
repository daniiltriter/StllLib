using Stll.Sessions.Types;

namespace Stll.Sessions.Abstractions;

public interface ISessionService
{
    Task CreateAsync(SessionContext context);
    Task<Session> GetOrDefaultAsync();
    bool Remove();
}