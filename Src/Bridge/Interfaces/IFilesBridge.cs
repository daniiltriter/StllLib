using Stll.Bridge.Results;

namespace Stll.Bridge.Interfaces;

public interface IFilesBridge
{
    Task<FileBridgeResponse> DownloadJavaAsync();
    Task<FileBridgeResponse> DownloadMinecraftAsync();
}