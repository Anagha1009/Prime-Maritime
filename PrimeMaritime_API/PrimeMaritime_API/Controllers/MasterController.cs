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
    public class MasterController : ControllerBase
    {
        private IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpPost("InsertPartyMaster")]
        public ActionResult<Response<CommonResponse>> InsertMaster(MASTER master)
        {
            return Ok(_masterService.InsertMaster(master));
        }

        [HttpGet("GetPartyMasterList")]
        public ActionResult<Response<List<MasterList>>> GetMasterList(string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetMasterList(AGENT_CODE)));
        }
    }
}
