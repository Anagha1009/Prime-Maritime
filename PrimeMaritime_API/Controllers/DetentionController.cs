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
    public class DetentionController : Controller
    {
        private IDetentionService _detentionService;
        public DetentionController(IDetentionService detentionService)
        {
            _detentionService = detentionService;
        }

        [HttpGet("GetDetentionListByDO")]
        public ActionResult<Response<List<DETENTION_WAIVER_REQUEST>>> GetDetentionListByDO(string DO_NO)
        {
            return Ok(JsonConvert.SerializeObject(_detentionService.GetDetentionListByDO(DO_NO)));
        }

        [HttpPost("InsertDetention")]
        public ActionResult<Response<DETENTION_WAIVER_REQUEST>> InsertDetention(DETENTION request)
        {
            return Ok(_detentionService.InsertDetention(request));
        }

        [HttpGet("GetTotalDetentionCost")]
        public ActionResult<Response<decimal>> GetTotalDetentionCost(string CONTAINER_NO)
        {
            return Ok(JsonConvert.SerializeObject(_detentionService.GetTotalDetentionCost(CONTAINER_NO)));
        }

        [HttpGet("GetContainerDetentionList")]
        public ActionResult<Response<List<CONTAINER_DETENTION>>> GetContainerDetentionList()
        {
            return Ok(JsonConvert.SerializeObject(_detentionService.GetContainerDetentionList()));
        }


    }
}
