using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class AuthenticationResponse
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public int RoleCode { get; set; }
        public string role { get; set; }
        public string Port { get; set; }
        public string Depo { get; set; }
        public string countrycode { get; set; }
        public string orgcode { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
