using Refit;
using Stll.Bridge.Api.Objects;

namespace Stll.Bridge.Api.Interfaces;

public interface IUsersApi
{
    [Post("/api/users")]
    Task<ApiResponse<string>> RegisterAsync([Body]RegisterUserApiRequest request);
}