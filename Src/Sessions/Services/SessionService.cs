using Stll.Sessions.Abstractions;
using Stll.Sessions.Shared;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

internal class SessionService : ISessionService
{
    private readonly ISessionStorage _storage;
    private readonly ITokenStore _tokenStore;
    public SessionService(ISessionStorage storage, ITokenStore tokenStore)
    {
        _storage = storage;
        _tokenStore = tokenStore;
    }
    
    public async Task CreateAsync(SessionContext context)
    {
        // TODO: replace to AuthFacade
        _tokenStore.WriteToken(context.AccessToken);
        var session = new Session(context.Username, context.AccessToken, context.ClientToken);
        await _storage.WriteAsync(session);
    }

    public async Task RefreshAsync()
    {
        var session = await _storage.CurrentAsync();
        _tokenStore.WriteToken(session.AccessToken);
    }

    public async Task<Session> CurrentAsync()
    {
        return await _storage.CurrentAsync();
    }

    public bool Remove()
    {
        _tokenStore.Clear();
        return _storage.Remove();
    }   
}