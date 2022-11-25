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
        #region "PARTY MASTER"
        Response<CommonResponse> InsertPartyMaster(PARTY_MASTER request);
        Response<List<PARTY_MASTER>> GetPartyMasterList(string Agent_code);

        Response<PARTY_MASTER> GetPartyMasterDetails(string Agent_code, int CUSTOMER_ID);

        Response<CommonResponse> DeletePartyMasterDetails(string Agent_code, int CUSTOMER_ID);

        Response<CommonResponse> UpdatePartyMasterDetails(PARTY_MASTER request);
        #endregion

        #region "CONTAINER MASTER"
        Response<CommonResponse> InsertContainerMaster(CONTAINER_MASTER request);

        Response<List<CONTAINER_MASTER>> GetContainerMasterList();

        Response<CONTAINER_MASTER> GetContainerMasterDetails(int ID);

        Response<CommonResponse> UpdateContainerMasterList(CONTAINER_MASTER request);

        Response<CommonResponse> DeleteContainerMasterList(int ID);
        #endregion

        #region "COMMON MASTER"
        Response<CommonResponse> InsertMaster(MASTER request);

        Response<List<MASTER>> GetMasterList(string key);

        Response<MASTER> GetMasterDetails(int ID);

        Response<CommonResponse> UpdateMaster(MASTER request);

        Response<CommonResponse> DeleteMaster(int ID);
        #endregion
    }
}
