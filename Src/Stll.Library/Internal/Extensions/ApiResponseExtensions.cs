using System.Text.Json;
using Refit;
using Stll.Library.Public.Results;

namespace Stll.Library.Internal.Extensions;

public static class ApiResponseExtensions
{
    public static ApiBridgeResponse<T> ToBridgeResponse<T>(this ApiResponse<string> source) =>new ApiBridgeResponse<T>
    {
        Code = (uint)source.StatusCode,
        Success = source.IsSuccessStatusCode,
        Error = source.Error?.Message,
        Value = source.IsSuccessStatusCode ? JsonSerializer.Deserialize<T>(source.Content) : default
    };
}