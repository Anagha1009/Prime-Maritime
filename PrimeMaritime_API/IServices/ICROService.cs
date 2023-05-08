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
        Response<List<CRO>> GetCROList(string AGENT_CODE,string FROM_DATE, string TO_DATE, string CRO_NO, string ORG_CODE, string PORT);
        Response<List<CRO>> GetCROListPM(string FROM_DATE, string TO_DATE, string CRO_NO);
        Response<CRODetails> GetCRODetails(string CRO_NO, string AGENT_CODE);
    }
}
