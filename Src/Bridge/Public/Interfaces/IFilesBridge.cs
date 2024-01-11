using Stll.Bridge.Public.Results;

namespace Stll.Bridge.Public.Interfaces;

public interface IFilesBridge
{
    Task<FileBridgeResponse> DownloadJavaAsync();
    Task<FileBridgeResponse> DownloadMinecraftAsync();
}