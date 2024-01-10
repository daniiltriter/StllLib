using Stll.Sessions.Abstractions;
using Stll.Sessions.Primitives;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class AuthFacade
{
    private IAuthStrategy _auth;
    private ISessionService _session;

    public AuthFacade(ISessionService session)
    {
        _session = session;
    }

    public async Task<Session> CreateSessionAsync(AuthContext context)
    {
        return new Session();
    }
}