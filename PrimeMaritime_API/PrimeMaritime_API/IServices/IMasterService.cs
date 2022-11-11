using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IMasterService
    {
        Response<CommonResponse> InsertMaster(MASTER request);
        Response<List<MASTER>> GetMasterList(string Agent_code);
    }
}
