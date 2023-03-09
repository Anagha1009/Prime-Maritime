using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IActivityService
    {
        Response<List<ACTIVITY>> GetActivityList();
        Response<ACTIVITY> GetActivityDetailsByCode(string ACT_CODE);
        Response<ActivityMappingResponse> GetActivityMappingDetailsByID(int ACT_ID);
    }
}
