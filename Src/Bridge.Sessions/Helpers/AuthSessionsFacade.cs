using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Sessions.Abstractions;
using Stll.Bridge.Sessions.Types;

namespace Stll.Bridge.Sessions.Shared;

public class AuthSessionsFacade
{
    private readonly IAuthService _auth;
    private readonly ISessionService _session;

    public AuthSessionsFacade(IAuthService auth, ISessionService session)
    {
        _auth = auth;
        _session = session;
    }

    public async Task<bool> SessionAuthAsync(AuthContext context)
    {
        var authResult = await _auth.AuthorizeAsync(context);
        
        var authFailed = string.IsNullOrWhiteSpace(authResult.AccessToken);
        if (authFailed)
        {
            return false;
        }

        var sessionContext = new SessionContext(context.Username, authResult.AccessToken);
        await _session.CreateAsync(sessionContext);
        return true;
    }
}