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
    public class CountController : Controller
    {
        private ICountService _countService;

        public CountController(ICountService CountService)
        {
            _countService = CountService;
        }

        [HttpGet("GETCOUNT")]
        public ActionResult<Response<COUNT>> GET_COUNT()
        {
            return Ok(JsonConvert.SerializeObject(_countService.GETCOUNT()));
        }
    }

}
