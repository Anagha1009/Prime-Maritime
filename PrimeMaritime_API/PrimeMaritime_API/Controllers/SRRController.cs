using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Response<List<SRR>>> GetSRRList()
        {
            return Ok(_srrService.GetSRRList());
        }
    }
}
