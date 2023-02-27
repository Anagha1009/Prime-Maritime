using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IDetentionService
    {
        Response<List<DETENTION_WAIVER_REQUEST>> GetDetentionListByDO(string DO_NO);
        Response<string> InsertDetention(DETENTION Request);
        Response<decimal> GetTotalDetentionCost(string CONTAINER_NO);
        Response<List<CONTAINER_DETENTION>> GetContainerDetentionList();
    }
}
