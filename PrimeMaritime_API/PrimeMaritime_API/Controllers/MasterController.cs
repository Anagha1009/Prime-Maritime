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

        #region "CONTAINER"
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

        #region "Container Size"
        [HttpPost("InsertContainerSize")]
        public ActionResult<Response<CommonResponse>> InsertContainerSize(SIZE request)
        {
            return Ok(_masterService.InsertContainerSize(request));
        }

        [HttpGet("GetContainerSizeList")]
        public ActionResult<Response<List<SIZE>>> GetContainerSizeList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerSizeList()));
        }

        [HttpGet("GetContainerSizeDetails")]
        public ActionResult<Response<SIZE>> GetContainerSizeDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetContainerSizeDetails(ID)));
        }

        [HttpPost("UpdateContainerSizeList")]
        public ActionResult<Response<CONTAINER_MASTER>> UpdateContainerSizeList(SIZE request)
        {
            return Ok(_masterService.UpdateContainerSizeList(request));
        }

        [HttpDelete("DeleteContainerSizeList")]
        public ActionResult<Response<SIZE>> DeleteContainerSizeList(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteContainerSizeList(ID)));
        }
        #endregion

        #region "Servie Type"
        [HttpPost("InsertServiceTypeMaster")]
        public ActionResult<Response<CommonResponse>> InsertServiceTypeMaster(MASTER request)
        {
            return Ok(_masterService.InsertServiceTypeMaster(request));
        }

        [HttpGet("GetServiceTypeMasterList")]
        public ActionResult<Response<List<MASTER>>> GetServiceTypeMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceTypeMasterList()));
        }

        [HttpGet("GetServiceTypeMasterDetails")]
        public ActionResult<Response<MASTER>> GetServiceTypeMasterDetails(string CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.GetServiceTypeMasterDetails(CODE)));
        }

        [HttpPost("UpdateServiceTypeMaster")]
        public ActionResult<Response<MASTER>> UpdateServiceTypeMaster(MASTER request)
        {
            return Ok(_masterService.UpdateServiceTypeMaster(request));
        }

        [HttpDelete("DeleteServiceTypeMaster")]
        public ActionResult<Response<MASTER>> DeleteServiceTypeMaster(string CODE)
        {
            return Ok(JsonConvert.SerializeObject(_masterService.DeleteServiceTypeMaster(CODE)));
        }
        #endregion



    }
}
