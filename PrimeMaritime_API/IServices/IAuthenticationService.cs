using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IAuthenticationService
    {
        AuthenticationResponse AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        RefreshTokenResponse RefreshTokenAsync(RefreshTokenRequest request);
        Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request);
    }
}
