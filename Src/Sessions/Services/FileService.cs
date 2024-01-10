using System.Text;

namespace Stll.Sessions.Shared;

public class FileService : IFileService
{
    public async Task WriteAsync(string path, string content)
    {
        var directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(path, content, Encoding.UTF8);
    }

    public async Task<string> ReadOrDefaultAsync(string path)
    {
        var isExists = File.Exists(path);
        if (!isExists)
        {
            return null;
        }

        var content = await File.ReadAllTextAsync(path);
        return content;
    }

    public bool Remove(string path)
    {
        var isExists = File.Exists(path);
        if (!isExists)
        {
            return false;
        }
        
        File.Delete(path);
        return true;
    }
}