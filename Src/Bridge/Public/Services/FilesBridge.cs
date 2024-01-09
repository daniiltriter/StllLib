using Microsoft.Extensions.Options;
using Refit;
using Stll.Bridge.Api.Abstractions;
using Stll.Bridge.Internal.Extensions;
using Stll.Bridge.Public.Results;
using Stll.Bridge.Settings;
using Stll.Library.Public.Interfaces;

namespace Stll.Library.Public.Services;

public class FilesBridge : IFilesBridge
{
    private readonly IFilesApi _api;
    
    public FilesBridge(IOptions<ApiSettings> settings)
    {
        _api = RestService.For<IFilesApi>(settings.Value.ApiUrl);
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