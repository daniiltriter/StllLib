using Refit;

namespace Stll.Bridge.Api.Abstractions;

internal interface IFilesApi
{
    [Get("/api/files/java")]
    Task<ApiResponse<HttpContent>> DownloadJavaAsync();
    
    [Get("/api/files/minecraft")]
    Task<ApiResponse<HttpContent>> DownloadMinecraftAsync();
}