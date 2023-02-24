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
    //[Authorize]
    [ApiController]
    public class ERController : ControllerBase
    {
        private IERService _erService;
        public ERController(IERService erService)
        {
            _erService = erService;
        }

        [HttpGet("GetERList")]
        public ActionResult<Response<List<EMPTY_REPO>>> GetERList(string AGENT_CODE,string DEPO_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_erService.GetERList(AGENT_CODE, DEPO_CODE)));
        }

        [HttpPost("InsertER")]
        public ActionResult<Response<EMPTY_REPO>> InsertER(EMPTY_REPO request, bool isVessel)
        {
            return Ok(_erService.InsertER(request,isVessel));
        }

        [HttpGet("GetERDetails")]
        public ActionResult<Response<EMPTY_REPO>> GetERDetails(string REPO_NO, string AGENT_CODE, string DEPO_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_erService.GetERDetails(REPO_NO, AGENT_CODE, DEPO_CODE)));
        }

        [HttpGet("GetERContainerDetails")]
        public ActionResult<Response<ER_CONTAINER>> GetERContainerDetails(string REPO_NO, string AGENT_CODE, string DEPO_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_erService.GetERContainerDetails(REPO_NO, AGENT_CODE, DEPO_CODE)));
        }

        [HttpGet("GetERRateDetails")]
        public ActionResult<Response<ER_RATES>> GetERRateDetails(string REPO_NO)
        {
            return Ok(JsonConvert.SerializeObject(_erService.GetERRateDetails(REPO_NO)));
        }
    }
}
