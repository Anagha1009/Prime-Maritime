using Microsoft.AspNetCore.Http;
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
    public class ContainerMovementController : ControllerBase
    {
        private IContainerMovementService _cmService;
        private IContainerTrackingService _ctService;
        public ContainerMovementController(IContainerMovementService cmService,IContainerTrackingService ctService)
        {
            _cmService = cmService;
            _ctService = ctService;
        }

        [HttpPost("InsertContainerMovement")]
        public ActionResult<Response<CommonResponse>> InsertContainerMovement(CONTAINER_MOVEMENT request,bool fromXL)
        {
            return Ok(_cmService.InsertContainerMovement(request,fromXL));
        }

        [HttpGet("GetContainerMovementList")]
        public ActionResult<Response<List<CMList>>> GetContainerMovementList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetContainerMovementList(AGENT_CODE, DEPO_CODE, BOOKING_NO, CRO_NO, CONTAINER_NO)));
        }

        [HttpGet("GetSingleContainerMovement")]
        public ActionResult<Response<CM>> GetSingleContainerMovement(string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetSingleContainerMovement(CONTAINER_NO)));
        }


        //ContainerTracking
        [HttpPost("InsertContainerTracking")]
        public ActionResult<Response<CommonResponse>> InsertContainerTracking(CONTAINER_TRACKING request)
        {
            return Ok(_ctService.InsertContainerTracking(request));
        }

        [HttpGet("GetContainerTrackingList")]
        public ActionResult<Response<List<CMList>>> GetContainerTrackingList(string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_ctService.GetContainerTrackingList(CONTAINER_NO)));
        }


    }
}
