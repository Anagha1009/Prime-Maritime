using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IBLService
    {
        Response<CommonResponse> InsertBL(BL request);

        Response<List<CONTAINERS>> GetContainerList(string AgentID, string BOOKING_NO, string CRO_NO,string BL_NO,string DO_NO);
    }
}
