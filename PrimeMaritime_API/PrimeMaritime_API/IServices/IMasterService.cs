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

        Response<CONTAINER_MASTER> GetContainerMasterDetails(int ID, string CONTAINER_NO);

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

        #region "VESSEL MASTER"
        Response<CommonResponse> InsertVesselMaster(VESSEL_MASTER request);
        Response<List<VESSEL_MASTER>> GetVesselMasterList();

        Response<VESSEL_MASTER> GetVesselMasterDetails(int ID);

        Response<CommonResponse> UpdateVesselMasterList(VESSEL_MASTER request);

        Response<CommonResponse> DeleteVesselMasterList(int ID);
        #endregion


        #region "SERVICE MASTER"
        Response<CommonResponse> InsertServiceMaster(SERVICE_MASTER request);
        Response<List<SERVICE_MASTER>> GetServiceMasterList();
        Response<SERVICE_MASTER> GetServiceMasterDetails(int ID);

        Response<CommonResponse> UpdateServiceMasterList(SERVICE_MASTER request);

        Response<CommonResponse> DeleteServiceMasterList(int ID);


        #endregion

        #region "CONTAINER TYPE MASTER"

        Response<CommonResponse> InsertContainerTypeMaster(CONTAINER_TYPE request);

        Response<List<CONTAINER_TYPE>> GetContainerTypeMasterList();

        Response<CONTAINER_TYPE> GetContainerTypeMasterDetails(int ID);

        Response<CommonResponse> UpdateConatinerTypeMaster(CONTAINER_TYPE request);

        Response<CommonResponse> DeleteContainerTypeMaster(int ID);


        #endregion


        #region "ICD MASTER"

        Response<List<ICD_MASTER>> GetICDMasterList();


        #endregion

        #region "DEPO MASTER"

        Response<List<DEPO_MASTER>> GetDEPOMasterList();


        #endregion

        #region "TERMINAL MASTER"

        Response<List<TERMINAL_MASTER>> GetTerminalMasterList();


        #endregion

    }
}
