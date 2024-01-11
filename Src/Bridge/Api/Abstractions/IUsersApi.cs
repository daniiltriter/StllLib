using Refit;
using Stll.Bridge.Api.Objects;

namespace Stll.Bridge.Api.Abstractions;

internal interface IUsersApi
{
    [Post("/api/users")]
    Task<ApiResponse<string>> RegisterAsync([Body]RegisterUserApiRequest request);

    [Get("/api/users")]
    Task<ApiResponse<string>> GetAsync();
}