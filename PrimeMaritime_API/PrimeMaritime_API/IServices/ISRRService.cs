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
        Response<SRR> GetSRRBySRRNo(string SRR_NO, string AGENT_CODE);
        Response<string> GetRate(string POL, string POD, string CHARGE, string CONT_TYPE);
        Response<List<SRRList>> GetSRRList(string OPERATION, string SRR_NO, string CUSTOMER_NAME, string STATUS,string FROMDATE,string TODATE, string AGENT_CODE);
        Response<string> InsertSRR(SRRRequest sRRRequest);
        Response<string> InsertContainer(List<SRR_CONTAINERS> request);
        Response<CommonResponse> ApproveRate(List<SRR_RATES> request);
        Response<CommonResponse> CounterRate(List<SRR_RATES> request);
    }
}
