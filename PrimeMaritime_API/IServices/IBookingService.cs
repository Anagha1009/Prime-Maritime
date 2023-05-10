using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IBookingService
    {
        Response<CommonResponse> InsertBooking(BOOKING request);
        Response<List<BookingList>> GetBookingList(string AgentID, string BOOKING_NO, string FROM_DATE, string TO_DATE, string ORG_CODE, string PORT);
        Response<List<BookingList>> GetBookingListPM(string BOOKING_NO, string FROM_DATE, string TO_DATE);
        Response<BookingDetails> GetBookingDetails(string AgentID, string BOOKING_NO);
        Response<string> ValidateSlots(string SRR_NO, int NO_OF_SLOTS, string BOOKING_NO, string SLOT_OPERATOR);
        Response<CommonResponse> InsertVoyage(VOYAGE request);
        Response<int> GetTrackingDetails(string BOOKING_NO);

        Response<List<ROLLOVER>> GetRolloverList( string AGENT_CODE );
        //Response<List<CRO>> GetRolloverList();
    }

}
