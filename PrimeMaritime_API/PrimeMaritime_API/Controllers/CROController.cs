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
    public class CROController : ControllerBase
    {
        private ICROService _cROService;
        public CROController(ICROService cROService)
        {
            _cROService = cROService;
        }

        [HttpGet("GetCROList")]
        public ActionResult<Response<List<CRO>>> GetCROList(string OPERATION, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_cROService.GetCROList(OPERATION, AGENT_CODE)));
        }

        [HttpPost("InsertCRO")]
        public ActionResult<Response<CRO>> InsertCRO(CRORequest request)
        {
            return Ok(_cROService.InsertCRO(request));
        }

        [HttpGet("GetCROByBookingNo")]
        public ActionResult<Response<CRO>> GetCROByBookingNo(string BOOKING_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_cROService.GetCRODetailsByBookingNo(BOOKING_NO, AGENT_CODE)));
        }
    }
}
