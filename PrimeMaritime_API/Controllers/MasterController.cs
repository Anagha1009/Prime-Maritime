using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        #region "PARTY MASTER"
        [HttpPost("InsertPartyMaster")]
        public ActionResult<Response<CommonResponse>> InsertPartyMaster(PARTY_MASTER request)
        {
            return Ok(_masterService.InsertPartyMaster(request));
        }

        [HttpGet("GetPartyMasterList")]
        public ActionResult<Response<List<PARTY_MASTER>>> GetPartyMasterList(string AGENT_CODE, string CUST_NAME, string CUST_TYPE, bool STATUS, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetPartyMasterList(AGENT_CODE, CUST_NAME, CUST_TYPE, STATUS, FROM_DATE, TO_DATE)));
        }

        [HttpGet("GetPartyMasterDetails")]
        public ActionResult<Response<PARTY_MASTER>> GetPartyMasterDetails(string AGENT_CODE, int CUSTOMER_ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetPartyMasterDetails(AGENT_CODE, CUSTOMER_ID)));
        }

        [HttpDelete("DeletePartyMasterDetails")]
        public ActionResult<Response<CommonResponse>> DeletePartyMasterDetails(int CUSTOMER_ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeletePartyMasterDetails(CUSTOMER_ID)));
        }

        [HttpPost("UpdatePartyMasterDetails")]
        public ActionResult<Response<CommonResponse>> UpdatePartyMasterDetails(PARTY_MASTER request)
        {
            return Ok(_masterService.UpdatePartyMasterDetails(request));
        }
        #endregion

        #region "CONTAINER MASTER"
        [HttpPost("InsertContainerMaster")]
        public ActionResult<Response<CommonResponse>> InsertContainerMaster(CONTAINER_MASTER request)
        {
            return Ok(_masterService.InsertContainerMaster(request));
        }

        [HttpGet("GetContainerMasterList")]
        public ActionResult<Response<List<CONTAINER_MASTER>>> GET_CONTAINERLIST(string CONTAINER_NO, string CONTAINER_TYPE, string CONTAINER_SIZE, bool STATUS, string ONHIRE_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerMasterList(CONTAINER_NO, CONTAINER_TYPE, CONTAINER_SIZE, STATUS, ONHIRE_DATE)));
        }

        [HttpGet("GetContainerMasterDetails")]
        public ActionResult<Response<CONTAINER_MASTER>> GetContainerMasterDetails(int ID, string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerMasterDetails(ID, CONTAINER_NO)));
        }


        [HttpPost("UpdateContainerMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateContainerMasterList(CONTAINER_MASTER request)
        {
            return Ok(_masterService.UpdateContainerMasterList(request));
        }

        [HttpDelete("DeleteContainerMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteContainerMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteContainerMasterList(ID)));
        }
        #endregion

        #region "COMMON MASTER"
        [HttpPost("InsertMaster")]
        public ActionResult<Response<CommonResponse>> InsertMaster(MASTER request)
        {
            return Ok(_masterService.InsertMaster(request));
        }

        [HttpGet("GetMasterList")]
        public ActionResult<Response<List<MASTER>>> GetMasterList(string key, string FROM_DATE, string TO_DATE, string STATUS)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetMasterList(key,FROM_DATE,TO_DATE,STATUS)));
        }

        [HttpGet("GetMasterDetails")]
        public ActionResult<Response<MASTER>> GetMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetMasterDetails(ID)));
        }

        [HttpPost("UpdateMaster")]
        public ActionResult<Response<CommonResponse>> UpdateMaster(MASTER request)
        {
            return Ok(_masterService.UpdateMaster(request));
        }

        [HttpDelete("DeleteMaster")]
        public ActionResult<Response<CommonResponse>> DeleteMaster(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteMaster(ID)));
        }
        #endregion

        #region "VESSEL MASTER"
        [HttpPost("InsertVesselMaster")]
        public ActionResult<Response<CommonResponse>> InsertVesselMaster(VESSEL_MASTER request)
        {
            return Ok(_masterService.InsertVesselMaster(request));
        }

        [HttpGet("GetVesselMasterList")]
        public ActionResult<Response<List<VESSEL_MASTER>>> GetVesselMasterList(string VESSEL_NAME, string IMO_NO, string STATUS, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetVesselMasterList(VESSEL_NAME,IMO_NO,STATUS,FROM_DATE,TO_DATE)));
        }

        [HttpGet("GetVesselMasterDetails")]
        public ActionResult<Response<VESSEL_MASTER>> GetVesselMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetVesselMasterDetails(ID)));
        }

        [HttpPost("UpdateVesselMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateVesselMasterList(VESSEL_MASTER request)
        {
            return Ok(_masterService.UpdateVesselMasterList(request));
        }

        [HttpDelete("DeleteVesselMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteVesselMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteVesselMasterList(ID)));
        }
        #endregion

        #region "SERVICE MASTER"
        [HttpPost("InsertServiceMaster")]
        public ActionResult<Response<CommonResponse>> InsertServiceMaster(SERVICE_MASTER request)
        {
            return Ok(_masterService.InsertServiceMaster(request));
        }

        [HttpGet("GetServiceMasterList")]
        public ActionResult<Response<List<SERVICE_MASTER>>> GetServiceMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceMasterList()));
        }

        [HttpGet("GetServiceMasterDetails")]
        public ActionResult<Response<SERVICE_MASTER>> GetServiceMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceMasterDetails(ID)));
        }

        [HttpPost("UpdateServiceMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateServiceMasterList(SERVICE_MASTER request)
        {
            return Ok(_masterService.UpdateServiceMasterList(request));
        }

        [HttpDelete("DeleteServiceMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteServiceMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteServiceMasterList(ID)));
        }
        #endregion

        #region "CONTAINER TYPE MASTER"
        [HttpPost("InsertContainerTypeMaster")]
        public ActionResult<Response<CommonResponse>> InsertContainerTypeMaster(CONTAINER_TYPE request)
        {
            return Ok(_masterService.InsertContainerTypeMaster(request));
        }

        [HttpGet("GetContainerTypeMasterList")]
        public ActionResult<Response<List<CONTAINER_TYPE>>> GetContainerTypeMasterList(string CONT_TYPE_CODE, string CONTAINER_TYPE, string CONTAINER_SIZE, bool STATUS, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerTypeMasterList(CONT_TYPE_CODE, CONTAINER_TYPE, CONTAINER_SIZE, STATUS, FROM_DATE, TO_DATE)));
        }

        [HttpGet("GetContainerTypeMasterDetails")]
        public ActionResult<Response<CONTAINER_TYPE>> GetContainerTypeMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerTypeMasterDetails(ID)));
        }

        [HttpPost("UpdateConatinerTypeMaster")]
        public ActionResult<Response<CommonResponse>> UpdateConatinerTypeMaster(CONTAINER_TYPE request)
        {
            return Ok(_masterService.UpdateConatinerTypeMaster(request));
        }

        [HttpDelete("DeleteContainerTypeMaster")]
        public ActionResult<Response<CommonResponse>> DeleteContainerTypeMaster(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteContainerTypeMaster(ID)));
        }

        #endregion

        #region ICD MASTER"

        [HttpGet("GetMstICD")]
        public ActionResult<Response<List<ICD_MASTER>>> GetMstICD()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetICDMasterList()));
        }


        #endregion

        #region DEPO MASTER"

        [HttpGet("GetMstDEPO")]
        public ActionResult<Response<List<DEPO_MASTER>>> GetMstDEPO()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetDEPOMasterList()));
        }


        #endregion

        #region TERMINAL MASTER"

        [HttpGet("GetMstTerminal")]
        public ActionResult<Response<List<DEPO_MASTER>>> GetMstTerminal()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetTerminalMasterList()));
        }


        #endregion

        #region CLEARING_PARTY"

        [HttpGet("GetClearingPartyList")]
        public ActionResult<Response<List<CLEARING_PARTY>>> GetClearingPartyList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetClearingPartyList()));
        }

        [HttpPost("InsertCP")]
        public ActionResult<Response<CommonResponse>> InsertCP(CLEARING_PARTY request)
        {
            return Ok(_masterService.InsertCP(request));
        }

        #endregion

        #region "LINER"
        [HttpPost("InsertLiner")]
        public ActionResult<Response<CommonResponse>> InsertLiner(LINER request)
        {
            return Ok(_masterService.InsertLiner(request));
        }

        [HttpGet("GetLinerList")]

        public ActionResult<Response<List<CommonResponse>>> GetLinerList(string NAME, string CODE, string DESCRIPTION, bool STATUS, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetLinerList(NAME, CODE, DESCRIPTION, STATUS, FROM_DATE, TO_DATE)));
        }

        [HttpPost("UpdateLinerList")]
        public ActionResult<Response<CommonResponse>>UpdateLinerList(LINER request)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UpdateLinerList(request)));
        }

        [HttpDelete("DeleteLinerList")]
        public ActionResult<Response<CommonResponse>>DeleteLinerList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteLinerList(ID)));
        }

        [HttpGet("GetLinerDetails")]
        public ActionResult<Response<LINER>> GetLinerDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetLinerDetails( ID)));
        }

        #endregion

        #region "LinerService"
        [HttpPost("InsertService")]
        public ActionResult<Response<CommonResponse>> InsertService(SERVICE request)
        {
            return Ok(_masterService.InsertService(request));
        }

        [HttpGet("GetServiceList")]
        public ActionResult<Response<List<CommonResponse>>> GetServiceList(bool STATUS,string FROM_DATE,string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceList(STATUS,FROM_DATE,TO_DATE)));
        }

        [HttpGet("GetServiceDetails")]

        public ActionResult<Response<LINER>> GetServiceDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceDetails(ID)));
        }

        [HttpPost("UpdateService")]
        public ActionResult<Response<CommonResponse>> UpdateService(SERVICE request)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UpdateService(request)));
        }

        [HttpDelete("DeleteService")]
        public ActionResult<Response<CommonResponse>> DeleteService(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteService(ID)));
        }

        #endregion

        #region "VESSELSCHEDULE"
        [HttpPost("InsertSchedule")]
        public ActionResult<Response<CommonResponse>> InsertSchedule(SCHEDULE request)
        {
            return Ok(_masterService.InsertSchedule(request));
        }

        [HttpGet("GetScheduleList")]

        public ActionResult<Response<List<CommonResponse>>> GetScheduleList(string VESSEL_NAME, string PORT_CODE,bool STATUS,string ETA,string ETD)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetScheduleList(VESSEL_NAME,PORT_CODE,STATUS,ETA,ETD)));
        }

        [HttpGet("GetScheduleDetails")]
        public ActionResult<Response<SCHEDULE>> GetScheduleDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetScheduleDetails(ID)));
        }

        [HttpPost("UpdateSchedule")]
        public ActionResult<Response<CommonResponse>> UpdateSchedule(SCHEDULE request)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UpdateSchedule(request)));
        }

        [HttpDelete("DeleteSchedule")]
        public ActionResult<Response<CommonResponse>> DeleteSchedule(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteSchedule(ID)));
        }

        #endregion

        #region "VESSEL VOYAGE"
        [HttpGet("GetVoyageList")]

        public ActionResult<Response<List<CommonResponse>>> GetVoyageList(bool STATUS, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetVoyageList(STATUS, FROM_DATE, TO_DATE)));
        }

        [HttpGet("GetVoyageDetails")]
        public ActionResult<Response<VOYAGE>> GetVoyageDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetVoyageDetails(ID)));
        }

        [HttpPost("UpdateVoyage")]
        public ActionResult<Response<CommonResponse>> UpdateVoyage(VOYAGE request)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UpdateVoyage(request)));
        }

        [HttpDelete("DeleteVoyage")]
        public ActionResult<Response<CommonResponse>> DeleteVoyage(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteVoyage(ID)));
        }

        #endregion

        #region "LOCATION MASTER"
        [HttpPost("InsertLocationMaster")]
        public ActionResult<Response<CommonResponse>> InsertLocationMaster(LOCATION_MASTER request)
        {
            return Ok(_masterService.InsertLocationMaster(request));
        }

        [HttpGet("GetLocationMasterList")]
        public ActionResult<Response<List<LOCATION_MASTER>>> GetLocationMasterList(string LOC_NAME, string LOC_TYPE, bool STATUS, string FROM_DATE, string TO_DATE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetLocationMasterList(LOC_NAME, LOC_TYPE, STATUS, FROM_DATE,TO_DATE)));
        }

        [HttpGet("GetLocationMasterDetails")]
        public ActionResult<Response<LOCATION_MASTER>> GetLocationMasterDetails(string LOC_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetLocationMasterDetails(LOC_CODE)));
        }

        [HttpPost("UpdateLocationMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateLocationMasterList(LOCATION_MASTER request)
        {
            return Ok(_masterService.UpdateLocationMasterList(request));
        }

        [HttpPost("DeleteLocationMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteLocationMasterList(string LOC_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteLocationMasterList(LOC_CODE)));
        }
        #endregion

        #region "FREIGHT MASTER"
        [HttpPost("InsertFreightMaster")]
        public ActionResult<Response<CommonResponse>> InsertFreightMaster(FREIGHT_MASTER request)
        {
            return Ok(_masterService.InsertFreightMaster(request));
        }

        [HttpGet("GetFreightMasterList")]
        public ActionResult<Response<List<FREIGHT_MASTER>>> GetFreightMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetFreightMasterList()));
        }

        [HttpGet("GetFreightMasterDetails")]
        public ActionResult<Response<FREIGHT_MASTER>> GetFreightMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetFreightMasterDetails(ID)));
        }

        [HttpPost("UpdateFreightMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateFreightMasterList(FREIGHT_MASTER request)
        {
            return Ok(_masterService.UpdateFreightMasterList(request));
        }

        [HttpDelete("DeleteFreightMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteFreightMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteFreightMasterList(ID)));
        }
        #endregion

        #region "CHARGE MASTER"       
        [HttpGet("GetChargeMasterList")]
        public ActionResult<Response<List<CHARGE_MASTER>>> GetChargeMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetChargeMasterList()));
        }

        [HttpGet("GetChargeMasterDetails")]
        public ActionResult<Response<CHARGE_MASTER>> GetChargeMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetChargeMasterDetails(ID)));
        }

        [HttpPost("UpdateChargeMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateChargeMasterList(CHARGE_MASTER request)
        {
            return Ok(_masterService.UpdateChargeMasterList(request));
        }

        [HttpDelete("DeleteChargeMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteChargeMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteChargeMasterList(ID)));
        }
        #endregion

        #region "STEVEDORING MASTER"       
        [HttpGet("GetStevedoringMasterList")]
        public ActionResult<Response<List<STEV_MASTER>>> GetStevedoringMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetStevedoringMasterList()));
        }

        [HttpGet("GetStevedoringMasterDetails")]
        public ActionResult<Response<STEV_MASTER>> GetStevedoringMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetStevedoringMasterDetails(ID)));
        }

        [HttpPost("UpdateStevedoringMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateStevedoringMasterList(STEV_MASTER request)
        {
            return Ok(_masterService.UpdateStevedoringMasterList(request));
        }

        [HttpDelete("DeleteStevedoringMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteStevedoringMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteStevedoringMasterList(ID)));
        }
        #endregion

        #region "DETENTION MASTER"       
        [HttpGet("GetDetentionMasterList")]
        public ActionResult<Response<List<DETENTION_MASTER>>> GetDetentionMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetDetentionMasterList()));
        }

        [HttpGet("GetDetentionMasterDetails")]
        public ActionResult<Response<DETENTION_MASTER>> GetDetentionMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetDetentionMasterDetails(ID)));
        }

        [HttpPost("UpdateDetentionMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateDetentionMasterList(DETENTION_MASTER request)
        {
            return Ok(_masterService.UpdateDetentionMasterList(request));
        }

        [HttpDelete("DeleteDetentionMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteDetentionMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteDetentionMasterList(ID)));
        }
        #endregion

        #region "MANDATORY MASTER"       
        [HttpGet("GetMandatoryMasterList")]
        public ActionResult<Response<List<MANDATORY_MASTER>>> GetMandatoryMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetMandatoryMasterList()));
        }

        [HttpGet("GetMandatoryMasterDetails")]
        public ActionResult<Response<MANDATORY_MASTER>> GetMandatoryMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetMandatoryMasterDetails(ID)));
        }

        [HttpPost("UpdateMandatoryMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateMandatoryMasterList(MANDATORY_MASTER request)
        {
            return Ok(_masterService.UpdateMandatoryMasterList(request));
        }

        [HttpDelete("DeleteMandatoryMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteMandatoryMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteMandatoryMasterList(ID)));
        }
        #endregion

        #region "UPLOAD TARIFF"
        [HttpPost("UploadFreightTariff")] //ANAGHA
        public ActionResult<Response<string>> UploadFreightTariff(List<FREIGHT_MASTER> master)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UploadFreightTariff(master)));
        }

        [HttpPost("UploadChargeTariff")] //ANAGHA
        public ActionResult<Response<string>> UploadChargeTariff(List<CHARGE_MASTER> master)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UploadChargeTariff(master)));
        }

        [HttpPost("UploadStevTariff")] //ANAGHA
        public ActionResult<Response<string>> UploadStevTariff(List<STEV_MASTER> master)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UploadStevTariff(master)));
        }

        [HttpPost("UploadDetentionTariff")] //ANAGHA
        public ActionResult<Response<string>> UploadDetentionTariff(List<DETENTION_MASTER> master)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UploadDetentionTariff(master)));
        }

        [HttpPost("UploadMandatoryTariff")] //ANAGHA
        public ActionResult<Response<string>> UploadMandatoryTariff(List<MANDATORY_MASTER> master)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.UploadMandatoryTariff(master)));
        }
        #endregion

        #region "ORGANISATION MASTER"
        [HttpPost("InsertOrgMaster")]
        public ActionResult<Response<CommonResponse>> InsertOrgMaster(ORG_MASTER request)
        {
            return Ok(_masterService.InsertOrgMaster(request));
        }

        [HttpPost("ValidateOrgCode")]
        public ActionResult<Response<CommonResponse>> ValidateOrgCode(string ORG_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.ValidateOrgCode(ORG_CODE)));
        }

        [HttpGet("GetOrgMasterList")]
        public ActionResult<Response<List<ORG_MASTER>>> GetOrgMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetOrgMasterList()));
        }

        [HttpGet("GetOrgMasterDetails")]
        public ActionResult<Response<ORG_MASTER>> GetOrgMasterDetails(string ORG_CODE, string ORG_LOC_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetOrgMasterDetails(ORG_CODE, ORG_LOC_CODE)));
        }

        [HttpPost("UpdateOrgMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateOrgMasterList(ORG_MASTER request)
        {
            return Ok(_masterService.UpdateOrgMasterList(request));
        }

        [HttpPost("DeleteOrgMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteOrgMasterList(string ORG_CODE, string ORG_LOC_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteOrgMasterList(ORG_CODE, ORG_LOC_CODE)));
        }
        #endregion

        #region "SLOT MASTER"
        [HttpPost("InsertSlotMaster")]
        public ActionResult<Response<CommonResponse>> InsertSlotMaster(SLOT_MASTER request)
        {
            return Ok(_masterService.InsertSlotMaster(request));
        }

        [HttpGet("GetSlotMasterList")]
        public ActionResult<Response<List<SLOT_MASTER>>> GetSlotMasterList(string SERVICE, string PORT)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetSlotMasterList(SERVICE, PORT)));
        }

        [HttpGet("GetSlotMasterDetails")]
        public ActionResult<Response<SLOT_MASTER>> GetSlotMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetSlotMasterDetails(ID)));
        }

        [HttpPost("UpdateSlotMasterList")]
        public ActionResult<Response<CommonResponse>> UpdateSlotMasterList(SLOT_MASTER request)
        {
            return Ok(_masterService.UpdateSlotMasterList(request));
        }

        [HttpPost("DeleteSlotMasterList")]
        public ActionResult<Response<CommonResponse>> DeleteSlotMasterList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteSlotMasterList(ID)));
        }
        #endregion
    }
}
