using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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

        public AuthenticationService(
            IOptions<JwtSettings> jwtSettings,
           IConfiguration config)
        {
            _jwtSettings = jwtSettings.Value;
            _config = config;
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

            var refreshToken = GenerateRefreshToken();
            refreshToken.USER_ID = user.ID;

            response.RefreshToken = refreshToken.TOKEN;
            response.RefreshTokenExpiration = refreshToken.EXPIRES;
            user.RefreshTokens.Add(refreshToken);

            DbClientFactory<UserRepo>.Instance.CreateRefreshToken(dbConn, refreshToken);

            response.IsAuthenticated = true;
            response.Id = user.ID;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.UserName = user.USERNAME;

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
    }
}
