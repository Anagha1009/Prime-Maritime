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
    public class DOController : ControllerBase
    {
        private IDOService _doService;
        public DOController(IDOService doService)
        {
            _doService = doService;
        }

        [HttpGet("GetDOList")]
        public ActionResult<Response<List<DO>>> GetDOList(string OPERATION, string DO_NO, string DO_DATE, string DO_VALIDITY, string AGENT_CODE)
        {
                return Ok(JsonConvert.SerializeObject(_doService.GetDOList(OPERATION, DO_NO, DO_DATE, DO_VALIDITY,AGENT_CODE)));
        }

        [HttpPost("InsertDO")]
        public ActionResult<Response<DO>> InsertDO(DO request)
        {
            return Ok(_doService.InsertDO(request));
        }

        [HttpGet("GetDODetails")]
        public ActionResult<Response<DO>> GetDODetails(string DO_NO, string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_doService.GetDODetails(DO_NO, AGENT_CODE)));
        }
    }
}
