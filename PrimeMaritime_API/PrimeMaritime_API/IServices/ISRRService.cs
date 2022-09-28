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
    public interface ISRRService
    {
        Response<SRR> GetSRRBySRRNo(string SRR_NO);

        Response<List<SRRList>> GetSRRList(string SRR_NO, string CUSTOMER_NAME, string STATUS);

        Response<SRR> InsertSRR(SRRRequest sRRRequest);
    }
}
