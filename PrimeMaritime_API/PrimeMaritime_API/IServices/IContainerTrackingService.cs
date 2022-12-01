using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IContainerTrackingService
    {
        Response<CommonResponse> InsertContainerTracking(CONTAINER_TRACKING request);
        Response<List<CT>> GetContainerTrackingList(string CONTAINER_NO);

        Response<List<CT>> GetContainerTrackingAsPerBooking(string BOOKING_NO, string CRO_NO, string CONTAINER_NO);

    }
}
