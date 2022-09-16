using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PrimeMaritime_API.IRepository;
using PrimeMaritime_API.Models;
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

namespace PrimeMaritime_API.Repository
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

            var user = DbClientFactory<UserRepo>.Instance.GetUserByUsername(dbConn, request.Username);
            AuthenticationResponse response = new AuthenticationResponse();

            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"No Accounts Registered with {request.Username}.";
                return response;
            }

            var result = DbClientFactory<UserRepo>.Instance.ValidateUser(dbConn, request.Username, request.Password);

            if (result == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Credentials for '{request.Username} aren't valid";
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
            response.RefreshToken = refreshToken.Token;
            response.RefreshTokenExpiration = refreshToken.Expires;
            user.RefreshTokens.Add(refreshToken);

            response.IsAuthenticated = true;
            response.Id = user.ID;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.UserName = user.USERNAME;

            return response;
        }

        public Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            throw new NotImplementedException();
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
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }
    }
}
