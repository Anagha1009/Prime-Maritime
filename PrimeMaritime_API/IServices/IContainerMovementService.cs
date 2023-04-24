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
        Response<CommonResponse> ValidContainer(string ContainerNo);
        Response<string> ValidCROForContainer(string ContainerNo);
        Response<List<NEXT_ACTIVITY>> GetNextActivityList(string CONTAINER_NO);
        Response<CM> GetSingleContainerMovement(string CONTAINER_NO);
        //Response<List<CMList>> GetContainerMovementList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO, string CONTAINER_NO);
        Response<CONTAINERMOVEMENT> GetContainerMovement(string BOOKING_NO, string CRO_NO, string CONTAINER_NO);
        Response<List<CMList>> GetContainerMovementList(string BOOKING_NO, string CRO_NO);
        Response<string> UpdateContainerMovement(CONTAINERMOVEMENT cm);
        Response<string> UploadContainerMovement(List<CONTAINERMOVEMENT> cm);
        Response<List<CM>> GetAvailableContainerListForDepo(string DEPO_CODE);
        Response<List<CM>> GetAllContainerListForDepo(string DEPO_CODE);
        Response<List<CM>> GetAllContainerListForAdmin(string LOCATION);
        Response<List<CM>> GetCMAvailable(string STATUS, string CURRENT_LOCATION);
        Response<List<CM>> GetContainerMovementBooking(string BOOKING_NO, string CRO_NO);

    }
}
