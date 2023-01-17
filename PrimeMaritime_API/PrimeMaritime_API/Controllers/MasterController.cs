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
        public ActionResult<Response<List<CONTAINER_MASTER>>> GET_CONTAINERLIST()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerMasterList()));
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
        public ActionResult<Response<CommonResponse>> DeleteContainerMasterList( int ID)
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
        public ActionResult<Response<List<MASTER>>> GetMasterList(string key)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetMasterList(key)));
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
        public ActionResult<Response<List<VESSEL_MASTER>>> GetVesselMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetVesselMasterList()));
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
        public ActionResult<Response<List<CONTAINER_TYPE>>> GetContainerTypeMasterList()
        {
           return Ok(JsonConvert.SerializeObject(_masterService.GetContainerTypeMasterList()));
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

        public ActionResult<Response<List<CommonResponse>>> GetLinerList( )
        {
            return Ok (JsonConvert.SerializeObject(_masterService.GetLinerList()));
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
        public ActionResult<Response<List<CommonResponse>>> GetServiceList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceList()));
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

        public ActionResult<Response<List<CommonResponse>>> GetScheduleList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetScheduleList()));
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





    }
}
