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
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet("GetActivityList")]
        public ActionResult<Response<List<ACTIVITY>>> GetActivityList()
        {
            return Ok(JsonConvert.SerializeObject(_activityService.GetActivityList()));
        }

        [HttpGet("GetActivityDetailsByCode")]
        public ActionResult<Response<ACTIVITY>> GetActivityDetailsByCode(string ACT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_activityService.GetActivityDetailsByCode(ACT_CODE)));
        }

        [HttpGet("GetActivityMappingDetailsByID")]
        public ActionResult<Response<ACTIVITY>> GetActivityMappingDetailsByID(int ACT_ID)
        {
            return Ok(JsonConvert.SerializeObject(_activityService.GetActivityMappingDetailsByID(ACT_ID)));
        }
    }
}
