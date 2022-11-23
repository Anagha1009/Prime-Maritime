using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IContainerMovementService
    {
        Response<CommonResponse> InsertContainerMovement(CONTAINER_MOVEMENT request,bool fromXL);
        Response<CM> GetSingleContainerMovement(string CONTAINER_NO);

        Response<List<CONTAINER_MOVEMENT>> GetContainerMovementList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO, string CONTAINER_NO);
      
    }
}
