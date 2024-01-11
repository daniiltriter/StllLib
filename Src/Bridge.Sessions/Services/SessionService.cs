using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Sessions.Abstractions;
using Stll.Bridge.Sessions.Shared;
using Stll.Bridge.Sessions.Types;

namespace Stll.Bridge.Sessions.Services;

internal class SessionService : ISessionService
{
    private readonly ISessionStorage _storage;
    private readonly IAuthTokenStore _tokenStore;
    public SessionService(ISessionStorage storage, IAuthTokenStore tokenStore)
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