using Microsoft.Extensions.DependencyInjection;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Public.Interfaces;
using Stll.Bridge.Public.Results;

namespace Stll.Bridge.Public.Services;

public class FilesBridge : IFilesBridge
{
    private readonly IFilesApi _api;
    
    public FilesBridge(IServiceProvider _services)
    {
        _api = _services.GetService<IFilesApi>();
    }
    public async Task<FileBridgeResponse> DownloadJavaAsync()
    {
        var apiResponse = await _api.DownloadJavaAsync();
        return apiResponse.ToBridgeResponse();
    }

    public async Task<FileBridgeResponse> DownloadMinecraftAsync()
    {
        var apiResponse = await _api.DownloadMinecraftAsync();
        return apiResponse.ToBridgeResponse();
    }
}