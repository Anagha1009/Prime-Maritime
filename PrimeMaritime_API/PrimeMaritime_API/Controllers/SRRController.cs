using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using System.Collections.Generic;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    
    [ApiController]
    public class SRRController : ControllerBase
    {

        private ISRRService _srrService;
        public SRRController(ISRRService srrService)
        {
            _srrService = srrService;
        }

        [HttpGet]
        public ActionResult<Response<SRR>> GetSRRBySRRNo(string SRR_NO)
        {
           return Ok(JsonConvert.SerializeObject(_srrService.GetSRRBySRRNo(SRR_NO)));
        }

        [HttpGet("GetSRRList")]
        public ActionResult<Response<List<SRR>>> GetSRRList()
        {
            return Ok(JsonConvert.SerializeObject(_srrService.GetSRRList()));
        }
    }
}
