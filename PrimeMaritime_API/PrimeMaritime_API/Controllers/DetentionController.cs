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
    public class DetentionController : Controller
    {
        private IDetentionService _detentionService;
        public DetentionController(IDetentionService detentionService)
        {
            _detentionService = detentionService;
        }


        [HttpGet("GetDetentionListByDO")]
        public ActionResult<Response<List<DETENTION_WAIVER_REQUEST>>> GetDetentionListByDO(string DO_NO)
        {
            return Ok(JsonConvert.SerializeObject(_detentionService.GetDetentionListByDO(DO_NO)));
        }

        [HttpPost("InsertDetention")]
        public ActionResult<Response<ACTIVITY_MAPPING>> InsertDetention(DETENTION request)
        {
            return Ok(_detentionService.InsertDetention(request));
        }

    }
}
