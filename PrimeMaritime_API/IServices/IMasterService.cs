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
        Response<List<PARTY_MASTER>> GetPartyMasterList(string Agent_code, string CustName, string CustType, bool Status, string FROM_DATE, string TO_DATE);

        Response<PARTY_MASTER> GetPartyMasterDetails(string Agent_code, int CUSTOMER_ID);

        Response<CommonResponse> DeletePartyMasterDetails(int CUSTOMER_ID);

        Response<CommonResponse> UpdatePartyMasterDetails(PARTY_MASTER request);
        #endregion

        #region "CONTAINER MASTER"
        Response<CommonResponse> InsertContainerMaster(CONTAINER_MASTER request);

        Response<List<CONTAINER_MASTER>> GetContainerMasterList(string ContainerNo, string ContType, string ContSize, bool Status, string ONHIRE_DATE);

        Response<CONTAINER_MASTER> GetContainerMasterDetails(int ID, string CONTAINER_NO);

        Response<CommonResponse> UpdateContainerMasterList(CONTAINER_MASTER request);

        Response<CommonResponse> DeleteContainerMasterList(int ID);
        #endregion

        #region "COMMON MASTER"
        Response<CommonResponse> InsertMaster(MASTER request);

        Response<List<MASTER>> GetMasterList(string key, string FROM_DATE, string TO_DATE, string STATUS);

        Response<MASTER> GetMasterDetails(int ID);

        Response<CommonResponse> UpdateMaster(MASTER request);

        Response<CommonResponse> DeleteMaster(int ID);
        #endregion

        #region "VESSEL MASTER"
        Response<CommonResponse> InsertVesselMaster(VESSEL_MASTER request);
        Response<List<VESSEL_MASTER>> GetVesselMasterList(string VESSEL_NAME, string IMO_NO, string STATUS, string FROM_DATE, string TO_DATE);
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

        Response<List<CONTAINER_TYPE>> GetContainerTypeMasterList( string ContTypeCode,string ContType, string ContSize, bool Status, string FROM_DATE, string TO_DATE);

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

        #region "CLEARING PARTY"

        Response<List<CLEARING_PARTY>> GetClearingPartyList();
        Response<string> InsertCP(CLEARING_PARTY request);

        #endregion

        #region "LINER"

        Response<CommonResponse> InsertLiner(LINER request);

        Response<List<LINER>> GetLinerList(string Name,string Code,string Description,bool Status,string FROM_DATE,string TO_DATE);

        Response<LINER> GetLinerDetails( int ID);
        Response<CommonResponse> UpdateLinerList(LINER request);

        Response<CommonResponse> DeleteLinerList(int ID);

        #endregion

        #region "LinerService"
        Response<CommonResponse> InsertService(SERVICE request);

        Response<List<SERVICE>> GetServiceList(bool Status,string FROM_DATE,string TO_CODE);

        Response<SERVICE> GetServiceDetails(int ID);

        Response<CommonResponse> UpdateService(SERVICE request);

        Response<CommonResponse> DeleteService(int ID);
        #endregion

        #region "VESSELSCHEDULE"
        Response<CommonResponse> InsertSchedule(SCHEDULE request);

        Response<List<SCHEDULE>> GetScheduleList(string VESSEL_NAME, string PORT_CODE, bool STATUS, string ETA, string ETD);

        Response<SCHEDULE> GetScheduleDetails(int ID);

        Response<CommonResponse> UpdateSchedule(SCHEDULE request);

        Response<CommonResponse> DeleteSchedule(int ID);

        #endregion

        #region "VESSEL VOYAGE"
        Response<List<VOYAGE>> GetVoyageList(bool STATUS, string FROM_DATE, string TO_DATE);

        Response<VOYAGE> GetVoyageDetails(int ID);

        Response<CommonResponse> UpdateVoyage(VOYAGE request);

        Response<CommonResponse> DeleteVoyage(int ID);

        #endregion

        #region "LOCATION MASTER"
        Response<CommonResponse> InsertLocationMaster(LOCATION_MASTER request);

        Response<List<LOCATION_MASTER>> GetLocationMasterList(string LOC_NAME, string LOC_TYPE, bool STATUS, string FROM_DATE, string TO_DATE);

        Response<LOCATION_MASTER> GetLocationMasterDetails(string LOC_CODE);

        Response<CommonResponse> UpdateLocationMasterList(LOCATION_MASTER request);

        Response<CommonResponse> DeleteLocationMasterList(string LOC_CODE);
        #endregion

        #region "FREIGHT MASTER"
        Response<CommonResponse> InsertFreightMaster(FREIGHT_MASTER request);
        Response<List<FREIGHT_MASTER>> GetFreightMasterList();
        Response<FREIGHT_MASTER> GetFreightMasterDetails(int ID);
        Response<CommonResponse> UpdateFreightMasterList(FREIGHT_MASTER request);
        Response<CommonResponse> DeleteFreightMasterList(int ID);
        #endregion

        #region "CHARGE MASTER"
        Response<List<CHARGE_MASTER>> GetChargeMasterList();
        Response<CHARGE_MASTER> GetChargeMasterDetails(int ID);
        Response<CommonResponse> UpdateChargeMasterList(CHARGE_MASTER request);
        Response<CommonResponse> DeleteChargeMasterList(int ID);
        #endregion

        #region "STEVEDORING MASTER"
        Response<List<STEV_MASTER>> GetStevedoringMasterList();
        Response<STEV_MASTER> GetStevedoringMasterDetails(int ID);
        Response<CommonResponse> UpdateStevedoringMasterList(STEV_MASTER request);
        Response<CommonResponse> DeleteStevedoringMasterList(int ID);
        #endregion

        #region "DETENTION MASTER"
        Response<List<DETENTION_MASTER>> GetDetentionMasterList();
        Response<DETENTION_MASTER> GetDetentionMasterDetails(int ID);
        Response<CommonResponse> UpdateDetentionMasterList(DETENTION_MASTER request);
        Response<CommonResponse> DeleteDetentionMasterList(int ID);
        #endregion

        #region "MANDATORY MASTER"
        Response<List<MANDATORY_MASTER>> GetMandatoryMasterList();
        Response<MANDATORY_MASTER> GetMandatoryMasterDetails(int ID);
        Response<CommonResponse> UpdateMandatoryMasterList(MANDATORY_MASTER request);
        Response<CommonResponse> DeleteMandatoryMasterList(int ID);
        #endregion

        #region "UPLOAD TARIFF"
        Response<string> UploadFreightTariff(List<FREIGHT_MASTER> request);
        Response<string> UploadChargeTariff(List<CHARGE_MASTER> request);
        Response<string> UploadStevTariff(List<STEV_MASTER> request);
        Response<string> UploadDetentionTariff(List<DETENTION_MASTER> request);
        Response<string> UploadMandatoryTariff(List<MANDATORY_MASTER> request);
        #endregion

        #region "ORGANISATION MASTER"
        Response<CommonResponse> InsertOrgMaster(ORG_MASTER request);
        Response<CommonResponse> ValidateOrgCode(string ORG_CODE);
        Response<List<ORG_MASTER>> GetOrgMasterList();
        Response<ORG_MASTER> GetOrgMasterDetails(string ORG_CODE, string ORG_LOC_CODE);
        Response<CommonResponse> UpdateOrgMasterList(ORG_MASTER request);
        Response<CommonResponse> DeleteOrgMasterList(string ORG_CODE,string ORG_LOC_CODE);
        #endregion

        #region "SLOT MASTER"
        Response<CommonResponse> InsertSlotMaster(SLOT_MASTER request);
        Response<List<SLOT_MASTER>> GetSlotMasterList(string SERVICE, string PORT);
        Response<SLOT_MASTER> GetSlotMasterDetails(int ID);
        Response<CommonResponse> UpdateSlotMasterList(SLOT_MASTER request);
        Response<CommonResponse> DeleteSlotMasterList(int ID);
        #endregion
    }
}
