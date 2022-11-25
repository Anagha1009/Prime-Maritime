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
    public class DetentionController : Controller
    {
        private IDetentionService _detentionService;
        public DetentionController(IDetentionService detentionService)
        {
            _detentionService = detentionService;
        }

        [HttpPost("InsertDetention")]
        public ActionResult<Response<CommonResponse>> InsertDetention(DETENTION_REQUEST request)
        {
            return Ok(_detentionService.InsertDetention(request));
        }

        [HttpGet("GetDetentionList")]
        public ActionResult<Response<List<DETENTION_REQUEST>>> GetDetentionList(string AGENT_CODE)
        {
            return Ok(JsonConvert.SerializeObject(_detentionService.GetDetentionList(AGENT_CODE)));
        }

        //[HttpGet("GET_DETAILS_BY_CONTAINER_NO")]
        //public ActionResult<Response<List<DETENTION_REQUEST>>> GET_DETAILS_BY_CONTAINER_NO(string CONTAINER_NO)
        //{
        //    return Ok(JsonConvert.SerializeObject(_detentionService.GET_DETAILS_BY_CONTAINER_NO(CONTAINER_NO)));
        //}



    }
}
