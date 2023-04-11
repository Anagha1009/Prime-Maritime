using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using System.Collections.Generic;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserList")]
        public ActionResult<Response<List<USERLIST>>> GetUserList()
        {
            return Ok(JsonConvert.SerializeObject(_userService.GetUserList()));
        }

        [HttpPost("InsertUser")]
        public ActionResult<Response<string>> InsertUser(USERLIST User)
        {
            return Ok(_userService.InsertUser(User));
        }

        [HttpPost("ValidateUsercode")]
        public ActionResult<Response<string>> ValidateUsercode(string usercode)
        {
            return Ok(_userService.ValidateUsercode(usercode));
        }

        [HttpGet("GetUser")]
        public ActionResult<Response<USERLIST>> GetUser(string usercode)
        {
            return Ok(JsonConvert.SerializeObject(_userService.GetUser(usercode)));
        }

        [HttpPost("UpdateUser")]
        public ActionResult<Response<string>> UpdateUser(USERLIST User)
        {
            return Ok(_userService.UpdateUser(User));
        }

        [HttpPost("DeleteUser")]
        public ActionResult<Response<string>> DeleteUser(string usercode)
        {
            return Ok(JsonConvert.SerializeObject(_userService.DeleteUser(usercode)));
        }
    }
}
