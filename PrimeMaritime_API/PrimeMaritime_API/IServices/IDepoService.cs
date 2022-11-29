using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IDepoService
    {
        Response<CommonResponse> InsertContainer(DEPO_CONTAINER request);
        Response<CommonResponse> InsertMRRequest(List<MR_LIST> request);
    }
}
