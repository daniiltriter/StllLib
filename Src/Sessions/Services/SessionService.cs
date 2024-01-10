using System.Text.Json;
using Microsoft.Extensions.Options;
using Stll.Sessions.Abstractions;
using Stll.Sessions.Configurations;
using Stll.Sessions.Shared;
using Stll.Sessions.Types;

namespace Stll.Sessions.Services;

public class SessionService : ISessionService
{
    private readonly IFileService _file;
    private readonly IOptions<AuthSettings> _settings;
    public SessionService(IFileService file, IOptions<AuthSettings> settings)
    {
        _file = file;
        _settings = settings;
    }
    
    public async Task CreateAsync(SessionContext context)
    {
        var session = new Session(context.Username, context.AccessToken, string.Empty);
        var content = JsonSerializer.Serialize(session);
        await _file.WriteAsync(_settings.Value.SessionPath,  content);
    }

    public async Task<Session> GetOrDefaultAsync()
    {
        var json = await _file.ReadOrDefaultAsync(_settings.Value.SessionPath);
        if (json is null)
        {
            return null;
        }
        
        return JsonSerializer.Deserialize<Session>(json);
    }

    public bool Remove()
    {
        return _file.Remove(_settings.Value.SessionPath);
    }   
}