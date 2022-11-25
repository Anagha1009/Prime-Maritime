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
        Response<CommonResponse> InsertDetention(DETENTION_REQUEST request);

        Response<List<DETENTION_REQUEST>> GetDetentionList(string AGENT_CODE);

        //Response<List<DETENTION_REQUEST>> GET_DETAILS_BY_CONTAINER_NO(string CONTAINER_NO);
    }
}
