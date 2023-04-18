using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
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
        Response<USER> ValidatePwd(string password, int userId);
        Response<string> ResetPwd(int userId, string password);
        Response<string> SendEmail(string email);
        Response<string> RenewPassword(RESET_PASSWORD resetPassword);
    }
}
