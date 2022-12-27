using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IERService
    {
        Response<string> InsertER(EMPTY_REPO doRequest, bool isVessel);

        Response<List<EMPTY_REPO>> GetERList(string AGENT_CODE, string DEPO_CODE);

        Response<EMPTY_REPO> GetERDetails(string REPO_NO, string AGENT_CODE ,string DEPO_CODE);

        Response<List<ER_CONTAINER>> GetERContainerDetails(string REPO_NO, string AGENT_CODE, string DEPO_CODE);

        Response<List<ER_RATES>> GetERRateDetails(string REPO_NO);
    }
}
