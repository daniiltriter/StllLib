using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using Stll.Sessions.Configurations;
using Stll.Sessions.Types;

namespace Stll.Sessions.Shared;

// TODO: require to refactoring. Single responsibility.
public class SessionStorage : ISessionStorage
{
    private Session _cache;
    
    private readonly IOptions<AuthSettings> _settings;
    
    public SessionStorage(IOptions<AuthSettings> settings)
    {
        _settings = settings;
    }
    public async Task WriteAsync(SessionContext context)
    {
        var session = new Session(context.Username, context.AccessToken, context.ClientToken);
        
        var path = _settings.Value.SessionPath;
        if (!Directory.Exists(path))
        {
            var directory = Path.GetDirectoryName(path);
            Directory.CreateDirectory(directory);
        }

        var content = JsonSerializer.Serialize(session);
        await File.WriteAllTextAsync(path, content, Encoding.UTF8);
        _cache = session;
    }

    public async Task<Session> CurrentAsync()
    {
        if (_cache != null)
        {
            return _cache;
        }
        var path = _settings.Value.SessionPath;
        var isExists = File.Exists(path);
        if (!isExists)
        {
            return null;
        }

        var content = await File.ReadAllTextAsync(path);
        var session = JsonSerializer.Deserialize<Session>(content);
        _cache = session;
        return JsonSerializer.Deserialize<Session>(content);
    }

    public bool Remove()
    {
        try
        {
            File.Delete(_settings.Value.SessionPath);
            return true;
        }
        catch
        {
            return false;
        }
    }
}