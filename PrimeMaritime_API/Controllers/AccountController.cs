using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
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

        [HttpPost("Validate-Pwd")]
        public ActionResult<Response<USER>> ValidatePwd(USER user)
        {
            string password = user.PASSWORD;
            int userId = user.ID;
            return Ok(JsonConvert.SerializeObject(_authenticationService.ValidatePwd(password, userId)));
        }

        [HttpPost("Reset-Pwd")]
        public ActionResult<Response<string>> ResetPwd(USER user)
        {
            string password = user.PASSWORD;
            int userId = user.ID;
            return Ok(_authenticationService.ResetPwd(userId, password));
        }

        [HttpPost("send-reset-email/{email}")]
        public ActionResult<Response<string>> SendEmail(string email)
        {
            return Ok(_authenticationService.SendEmail(email));
        }

        [HttpPost("renew-pwd")]
        public ActionResult<Response<string>> RenewPassword(RESET_PASSWORD resetPassword)
        {
            return Ok(_authenticationService.RenewPassword(resetPassword));
        }
    }
}
