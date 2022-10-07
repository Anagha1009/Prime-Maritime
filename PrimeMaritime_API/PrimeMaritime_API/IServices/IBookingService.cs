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
        Response<CommonResponse> InsertSlots(BookingRequest request);

        Response<List<SLOT_DETAILS>> GetSlotList(string AgentID, string SRR_NO);
    }
}
