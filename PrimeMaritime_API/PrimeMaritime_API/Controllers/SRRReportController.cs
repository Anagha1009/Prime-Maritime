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
    public class SRRReportController : ControllerBase
    {
        private ISRRReportService _sRRReportService;
        public SRRReportController(ISRRReportService sRRReportService)
        {
            _sRRReportService = sRRReportService;
        }

        [HttpGet("GetSRRCountList")]
        public ActionResult<Response<List<SRR_REPORT>>> GetSRRCountList()
        {
            return Ok(JsonConvert.SerializeObject(_sRRReportService.GetSRRCountList()));
        }

    }
}
