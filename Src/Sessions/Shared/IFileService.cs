namespace Stll.Sessions.Shared;

public interface IFileService
{
    Task WriteAsync(string path, string content);

    Task<string> ReadOrDefaultAsync(string path);

    bool Remove(string path);
}