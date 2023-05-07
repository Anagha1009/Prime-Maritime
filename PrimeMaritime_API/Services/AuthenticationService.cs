using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public AuthenticationService(
            IOptions<JwtSettings> jwtSettings,
           IConfiguration config, IEmailService emailService)
        {
            _jwtSettings = jwtSettings.Value;
            _config = config;
            _emailService = emailService;
        }

        public AuthenticationResponse AuthenticateAsync(AuthenticationRequest request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            var user = DbClientFactory<UserRepo>.Instance.GetUserByUsername(dbConn, request.USERNAME);
            AuthenticationResponse response = new AuthenticationResponse();

            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"No Accounts Registered with {request.USERNAME}.";
                return response;
            }

            var result = DbClientFactory<UserRepo>.Instance.ValidateUser(dbConn, request.USERNAME, request.PASSWORD);

            if (result == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Credentials for '{request.USERNAME} aren't valid";
                return response;
            }

            JwtSecurityToken jwtSecurityToken = GenerateToken(user);

            //if (user.RefreshTokens.Any(a => a.IsActive))
            //{
            //    var activeRefreshToken = user.RefreshTokens.FirstOrDefault(a => a.IsActive);
            //    response.RefreshToken = activeRefreshToken.Token;
            //    response.RefreshTokenExpiration = activeRefreshToken.Expires;
            //}
            //else
            //{
            //    var refreshToken = GenerateRefreshToken();
            //    response.RefreshToken = refreshToken.Token;
            //    response.RefreshTokenExpiration = refreshToken.Expires;
            //    user.RefreshTokens.Add(refreshToken);
            //    //_context.Update(user);
            //    //_context.SaveChanges();
            //}

            //var refreshToken = GenerateRefreshToken();
            //refreshToken.USER_ID = user.ID;

            //response.RefreshToken = refreshToken.TOKEN;
            //response.RefreshTokenExpiration = refreshToken.EXPIRES;
            //user.RefreshTokens.Add(refreshToken);

            //DbClientFactory<UserRepo>.Instance.CreateRefreshToken(dbConn, refreshToken);

            response.IsAuthenticated = true;
            response.Id = user.ID;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.UserName = user.USERNAME;
            response.RoleCode = user.ROLE_ID;
            response.role = user.ROLE_NAME;
            response.UserCode = user.USERCODE;
            response.Port = user.PORT;
            response.Depo = user.DEPO;
            response.countrycode = user.COUNTRYCODE;
            response.orgcode = user.ORG_CODE;

            return response;
        }

        public RefreshTokenResponse RefreshTokenAsync(RefreshTokenRequest request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            var response = new RefreshTokenResponse();
            var user = DbClientFactory<UserRepo>.Instance.GetRefreshToken(dbConn, request.Token);

            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token did not match any users.";
                return response;
            }

            var refreshToken = DbClientFactory<UserRepo>.Instance.GetRefreshTokenByUserId(dbConn, request.Token, user.ID);

            if (!refreshToken.IS_ACTIVE)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token Not Active.";
                return response;
            }

            //Revoke Current Refresh Token
            refreshToken.REVOKED = DateTime.UtcNow;
            DbClientFactory<UserRepo>.Instance.RevokeRefreshToken(dbConn, refreshToken);

            //Generate new Refresh Token and save to Database
            var newRefreshToken = GenerateRefreshToken();
            newRefreshToken.USER_ID = user.ID;
            
            user.RefreshTokens.Add(newRefreshToken);
            DbClientFactory<UserRepo>.Instance.CreateRefreshToken(dbConn, newRefreshToken);

            //Generates new jwt
            response.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = GenerateToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.EMAIL;
            response.UserName = user.USERNAME;
            response.RefreshToken = newRefreshToken.TOKEN;
            response.RefreshTokenExpiration = newRefreshToken.EXPIRES;
            response.IsActive = true;

            return response;
        }

        public Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request)
        {
            throw new NotImplementedException();
        }

        private JwtSecurityToken GenerateToken(USER user)
        {
            //var userClaims = await _userManager.GetClaimsAsync(user);
            //var roles = await _userManager.GetRolesAsync(user);

            //var roleClaims = new List<Claim>();

            //for (int i = 0; i < roles.Count; i++)
            //{
            //    roleClaims.Add(new Claim("roles", roles[i]));
            //}

            var claims = new[]
            {
                new Claim("USERNAME", user.USERNAME),
                new Claim("Jti", Guid.NewGuid().ToString())
            };

            var jwtSettings = new JwtSettings();
            jwtSettings = _config.GetSection("Jwt").Get<JwtSettings>();

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("84322CFB66934ECC86D547C5CF4F2E"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    TOKEN = Convert.ToBase64String(randomNumber),
                    EXPIRES = DateTime.UtcNow.AddDays(10),
                    CREATED = DateTime.UtcNow
                };
            }
        }
        public Response<USER> ValidatePwd(string password, int userId)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<USER> response = new Response<USER>();

            if ((password == "") || (password == null) || (userId == 0))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Data inaccurate";
                return response;
            }


            var data = DbClientFactory<UserRepo>.Instance.ValidatePwd(dbConn, password, userId);

            if ((data != null))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }
        public Response<string> ResetPwd(int userId, string password)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<UserRepo>.Instance.ResetPwd(dbConn, userId, password);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Password Updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> SendEmail(string email)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            var user = DbClientFactory<UserRepo>.Instance.CheckUserByEmail(dbConn, email);

            Response<string> response = new Response<string>();

            if (user != null)
            {
                using (var cryptoProvider = new RNGCryptoServiceProvider())
                {
                    byte[] bytes = new byte[64];
                    cryptoProvider.GetBytes(bytes);                    

                    string emailToken = Convert.ToBase64String(bytes);
                    user.RESET_PASSWORD_TOKEN = emailToken;
                    user.RESET_PASSWORD_EXPIRY = DateTime.Now.AddMinutes(15);
                    var emailModel = new EmailModel(email, "RESET PASSWORD", EmailBody.EmailStringBody(email, emailToken));

                    _emailService.SendEmail(emailModel);

                    DbClientFactory<UserRepo>.Instance.UpdateResetPwd(dbConn, user);
                }

               
                response.Succeeded = true;
                response.ResponseMessage = "Password reset successfull";
                response.ResponseCode = 200;

                return response;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseMessage = "Token Doesn't exist";
                response.ResponseCode = 500;

                return response;
            }            
        }

        public Response<string> RenewPassword(RESET_PASSWORD resetPassword)
        {
            Response<string> response = new Response<string>();
            var newToken = resetPassword.EmailToken.Replace(" ", "+");
            
            string connstring = _config.GetConnectionString("ConnectionString");
           
            var user = DbClientFactory<UserRepo>.Instance.CheckUserByEmail(connstring, resetPassword.Email);

            if (user is null)
            {
                response.Succeeded = true;
                response.ResponseMessage = "User Doesn't exist";
                response.ResponseCode = 500;

                return response;
            }

            var tokenCode = user.RESET_PASSWORD_TOKEN.Replace(" ", "+");
            DateTime emailTokenExpiry = user.RESET_PASSWORD_EXPIRY;
            if (tokenCode != resetPassword.EmailToken || emailTokenExpiry < DateTime.Now)
            {

                response.Succeeded = true;
                response.ResponseMessage = "Token Doesn't exist";
                response.ResponseCode = 500;

                return response;
            }


            DbClientFactory<UserRepo>.Instance.RenewPwd(connstring, user.ID, resetPassword.NewPassword);

            response.Succeeded = true;
            response.ResponseMessage = "Password reset successfull";
            response.ResponseCode = 200;

            return response;
        }
    }
}
