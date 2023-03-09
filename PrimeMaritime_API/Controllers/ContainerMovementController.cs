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
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
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

        //[HttpGet("GetContainerMovementList")]
        //public ActionResult<Response<List<CMList>>> GetContainerMovementList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        //{
        //    return Ok(JsonConvert.SerializeObject(_cmService.GetContainerMovementList(AGENT_CODE, DEPO_CODE, BOOKING_NO, CRO_NO, CONTAINER_NO)));
        //}

        [HttpGet("GetContainerMovement")] //ANAGHA
        public ActionResult<Response<CONTAINERMOVEMENT>> GetContainerMovement(string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetContainerMovement(BOOKING_NO, CRO_NO, CONTAINER_NO)));
        }

        [HttpGet("GetContainerMovementList")] //ANAGHA
        public ActionResult<Response<List<CMList>>> GetContainerMovementList(string BOOKING_NO, string CRO_NO)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetContainerMovementList(BOOKING_NO, CRO_NO)));
        }

        [HttpPost("UpdateContainerMovement")] //ANAGHA
        public ActionResult<Response<string>> UpdateContainerMovement(CONTAINERMOVEMENT cm)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.UpdateContainerMovement(cm)));
        }

        [HttpPost("UploadContainerMovement")] //ANAGHA
        public ActionResult<Response<string>> UploadContainerMovement(List<CONTAINERMOVEMENT> cm)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.UploadContainerMovement(cm)));
        }

        [HttpGet("GetAvailableContainerListForDepo")] //ANAGHA
        public ActionResult<Response<List<CM>>> GetAvailableContainerListForDepo(string DEPO_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetAvailableContainerListForDepo(DEPO_CODE)));
        }

        [HttpGet("GetContainerMovementBooking")]
        public ActionResult<Response<List<CM>>> GetContainerMovementBooking(string BOOKING_NO, string CRO_NO)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetContainerMovementBooking(BOOKING_NO, CRO_NO)));
        }

        [HttpGet("GetCMAvailable")]
        public ActionResult<Response<List<CM>>> GetCMAvailable(string STATUS, string CURRENT_LOCATION)
        {
            return Ok(JsonConvert.SerializeObject(_cmService.GetCMAvailable(STATUS, CURRENT_LOCATION)));
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

        [HttpGet("GetContainerTrackingAsPerBooking")]
        public ActionResult<Response<List<CMList>>> GetContainerTrackingAsPerBooking(string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_ctService.GetContainerTrackingAsPerBooking(BOOKING_NO, CRO_NO,CONTAINER_NO)));
        }


    }
}
