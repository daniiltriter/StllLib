using Refit;
using Stll.Library.Api.Objects;

namespace Stll.Library.Api.Interfaces;

internal interface IAuthenticationApi
{
    [Post("/api/oauth2/token")]
    Task<ApiResponse<string>> Token([Body]JwtTokenApiRequest request);
}