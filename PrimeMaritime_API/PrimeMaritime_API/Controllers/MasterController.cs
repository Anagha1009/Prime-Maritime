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
        public ActionResult<Response<List<PARTY_MASTER>>> GetPartyMasterList(string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetPartyMasterList(AGENT_CODE)));
        }

        [HttpGet("GetPartyMasterDetails")]
        public ActionResult<Response<PARTY_MASTER>> GetPartyMasterDetails(string AGENT_CODE, int CUSTOMER_ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetPartyMasterDetails(AGENT_CODE, CUSTOMER_ID)));
        }

        [HttpDelete("DeletePartyMasterDetails")]
        public ActionResult<Response<PARTY_MASTER>> DeletePartyMasterDetails(string AGENT_CODE, int CUSTOMER_ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeletePartyMasterDetails(AGENT_CODE, CUSTOMER_ID)));
        }

        [HttpPost("UpdatePartyMasterDetails")]
        public ActionResult<Response<PARTY_MASTER>> UpdatePartyMasterDetails(PARTY_MASTER request)
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
        public ActionResult<Response<CONTAINER_MASTER>> GetContainerMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerMasterDetails(ID)));
        }


        [HttpPost("UpdateContainerMasterList")]
        public ActionResult<Response<CONTAINER_MASTER>> UpdateContainerMasterList(CONTAINER_MASTER request)
        {
            return Ok(_masterService.UpdateContainerMasterList(request));
        }

        [HttpDelete("DeleteContainerMasterList")]
        public ActionResult<Response<CONTAINER_MASTER>> DeleteContainerMasterList( int ID)
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
        public ActionResult<Response<MASTER>> UpdateMaster(MASTER request)
        {
            return Ok(_masterService.UpdateMaster(request));
        }

        [HttpDelete("DeleteMaster")]
        public ActionResult<Response<MASTER>> DeleteMaster(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteMaster(ID)));
        }
        #endregion
    }
}
