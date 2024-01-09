using System.Text.Json;
using Refit;
using Stll.Bridge.Public.Results;

namespace Stll.Bridge.Internal.Extensions;

internal static class ApiResponseExtensions
{
    internal static ApiBridgeResponse ToBridgeResponse(this ApiResponse<string> source) => new()
    {
        Code = (uint)source.StatusCode,
        Success = source.IsSuccessStatusCode,
        Error = source.Error?.Message,
        Content = source.Content
    };
}