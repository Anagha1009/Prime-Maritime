using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    [ApiController]
    public class CROController : ControllerBase
    {
        private ICROService _cROService;
        public CROController(ICROService cROService)
        {
            _cROService = cROService;
        }

        [HttpGet("GetCROList")]
        public ActionResult<Response<List<CRO>>> GetCROList(string AGENT_CODE, string FROM_DATE, string TO_DATE, string CRO_NO, string ORG_CODE, string PORT)
        {
            return Ok(JsonConvert.SerializeObject(_cROService.GetCROList(AGENT_CODE,FROM_DATE,TO_DATE,CRO_NO,ORG_CODE,PORT)));
        }

        [HttpGet("GetCROListPM")]
        public ActionResult<Response<List<CRO>>> GetCROListPM(string FROM_DATE, string TO_DATE, string CRO_NO)
        {
            return Ok(JsonConvert.SerializeObject(_cROService.GetCROListPM(FROM_DATE, TO_DATE, CRO_NO)));
        }

        [HttpPost("InsertCRO")]
        public ActionResult<Response<CRO>> InsertCRO(CRORequest request)
        {
            return Ok(_cROService.InsertCRO(request));
        }

        [HttpGet("GetCRODetails")]
        public ActionResult<Response<CRODetails>> GetCRODetails(string CRO_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_cROService.GetCRODetails(CRO_NO, AGENT_CODE)));
        }
    }
}
