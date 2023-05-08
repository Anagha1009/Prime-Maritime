using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("InsertBooking")]
        public ActionResult<Response<CommonResponse>> InsertBooking(BOOKING request)
        {
            return Ok(_bookingService.InsertBooking(request));
        }

        [HttpGet("GetBookingList")]
        public ActionResult<Response<List<BookingList>>> GetBookingList(string AGENT_CODE, string BOOKING_NO, string FROM_DATE, string TO_DATE, string ORG_CODE, string PORT)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.GetBookingList(AGENT_CODE, BOOKING_NO, FROM_DATE, TO_DATE, ORG_CODE, PORT)));
        }

        [HttpGet("GetBookingListPM")]
        public ActionResult<Response<List<BookingList>>> GetBookingListPM(string BOOKING_NO, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.GetBookingListPM(BOOKING_NO, FROM_DATE, TO_DATE)));
        }

        [HttpGet("GetBookingDetails")]
        public ActionResult<Response<BookingDetails>> GetBookingDetails(string AGENT_CODE, string BOOKING_NO)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.GetBookingDetails(AGENT_CODE, BOOKING_NO)));
        }

        [HttpGet("ValidateSlots")]
        public ActionResult<Response<string>> ValidateSlots(string SRR_NO,int NO_OF_SLOTS, string BOOKING_NO, string SLOT_OPERATOR)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.ValidateSlots(SRR_NO, NO_OF_SLOTS, BOOKING_NO, SLOT_OPERATOR)));
        }

        [HttpPost("InsertVoyage")]
        public ActionResult<Response<CommonResponse>> InsertVoyage(VOYAGE request)
        {
            return Ok(_bookingService.InsertVoyage(request));
        }

        [HttpGet("GetTrackingDetail")]
        public ActionResult<Response<int>> GetTrackingDetail(string BOOKING_NO)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.GetTrackingDetails(BOOKING_NO)));
        }

        [HttpGet("GetRolloverList")]
        public ActionResult<Response<List<ROLLOVER>>> GetRolloverList(string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_bookingService.GetRolloverList(AGENT_CODE)));

        }

        
    }
}
