using Stll.Sessions.Abstractions;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class AuthorizationFacade
{
    private readonly IAuthService _auth;
    private readonly ISessionService _session;

    public AuthorizationFacade(IAuthService auth, ISessionService session)
    {
        _auth = auth;
        _session = session;
    }

    public async Task<bool> TryAuthWithSessionAsync(AuthContext context)
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