using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLController : ControllerBase
    {
        private IBLService _blService;
        public BLController(IBLService blService)
        {
            _blService = blService;
        }

        [HttpPost("InsertBL")]
        public ActionResult<Response<CommonResponse>> InsertBL(BL request)
        {
            return Ok(_blService.InsertBL(request));
        }

        [HttpGet("GetContainerList")]
        public ActionResult<Response<List<CONTAINERS>>> GetContainerList(string AGENT_CODE, string BOOKING_NO, string CRO_NO,string BL_NO)
        {
            return Ok(JsonConvert.SerializeObject(_blService.GetContainerList(AGENT_CODE, BOOKING_NO, CRO_NO,BL_NO)));
        }
    }
}
