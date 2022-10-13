using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //[HttpPost("InsertSlots")]
        //public ActionResult<Response<CommonResponse>> InsertSlots(SLOT_DETAILS request)
        //{
        //    return Ok(_bookingService.InsertSlots(request));
        //}

        [HttpPost("InsertBooking")]
        public ActionResult<Response<CommonResponse>> InsertBooking(BOOKING request)
        {
            return Ok(_bookingService.InsertBooking(request));
        }

        [HttpGet("GetSlotList")]
        public ActionResult<Response<List<SLOT_DETAILS>>> GetSlotList(string AGENT_CODE, string SRR_NO)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.GetSlotList(AGENT_CODE,SRR_NO)));
        }
    }
}
