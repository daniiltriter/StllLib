using Refit;
using Stll.Bridge.Api.Objects;

namespace Stll.Bridge.Api.Abstractions;

internal interface IAuthenticationApi
{
    [Post("/api/oauth2/token")]
    Task<ApiResponse<string>> Token([Body]JwtTokenApiRequest request);
}