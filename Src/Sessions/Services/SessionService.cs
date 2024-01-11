using Stll.Library.Public.Interfaces;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Shared;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class SessionService : ISessionService
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
        _tokenStore.WriteToken(context.AccessToken);
        await _storage.WriteAsync(context);
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