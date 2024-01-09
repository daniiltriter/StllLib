using Stll.Bridge.Public.Results;

namespace Stll.Library.Public.Interfaces;

public interface IFilesBridge
{
    Task<FileBridgeResponse> DownloadJavaAsync();
    Task<FileBridgeResponse> DownloadMinecraftAsync();
}