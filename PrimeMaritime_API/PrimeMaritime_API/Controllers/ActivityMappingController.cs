using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ActivityMappingController : ControllerBase
    {
        private IActivityMappingService _activityMappingService;
        public ActivityMappingController(IActivityMappingService activityMappingService)
        {
            _activityMappingService = activityMappingService;
        }

        [HttpPost("InsertActivityMapping")]
        public ActionResult<Response<ACTIVITY_MAPPING>> InsertActivityMapping(ACTIVITY_MAPPING request)
        {
            return Ok(_activityMappingService.InsertActivityMapping(request));
        }
    }
}
