using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("GetDropdownData")]
        public ActionResult<Response<List<DROPDOWN>>> GetDropdownData(string key,string port, string value, int value1, string value2)
        {
            return Ok(JsonConvert.SerializeObject(_commonService.GetDropdownData(key,port,value, value1, value2)));
        }

        [HttpPost("SendEmail")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await _commonService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("CheckRandomNuber")]
        public ActionResult<Response<int>> CheckRandomNuber(string RANDOM_NO)
        {
            return Ok(JsonConvert.SerializeObject(_commonService.CheckRandomNo(RANDOM_NO)));
        }
    }
}
