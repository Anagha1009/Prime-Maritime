using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("authenticate")]
        public ActionResult<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(_authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("refresh-token")]
        public ActionResult<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            return Ok(_authenticationService.RefreshTokenAsync(request));
        }
    }
}
