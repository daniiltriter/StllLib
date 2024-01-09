using Refit;
using Stll.Library.Api.Objects;

namespace Stll.Library.Api.Interfaces;

public interface IAuthenticationApi
{
    [Post("api/oauth/token")]
    Task<string> Token(JwtTokenApiRequest request);
}