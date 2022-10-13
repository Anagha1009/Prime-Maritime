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
    public interface ICROService
    {
        Response<string> InsertCRO(CRORequest CRORequest);

        Response<List<CROResponse>> GetCROList(string OPERATION, string AGENT_CODE);

        Response<CRO> GetCRODetailsByBookingNo(string BOOKING_NO, string AGENT_CODE);
    }
}
