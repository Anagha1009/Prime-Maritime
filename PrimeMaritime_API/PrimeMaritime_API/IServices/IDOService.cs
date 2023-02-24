using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IDOService
    {
        Response<string> InsertDO(DO doRequest);

        Response<List<DO>> GetDOList(string DO_NO, string FROM_DATE, string TO_DATE, string AGENT_CODE);

        Response<DO> GetDODetails(string BL_NO, string AGENT_CODE);
    }
}
