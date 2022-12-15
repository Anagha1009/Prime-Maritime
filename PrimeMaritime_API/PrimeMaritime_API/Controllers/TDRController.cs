using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
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
    public class TDRController : Controller
    {
        private ITdrService _tdrService;
        public TDRController(ITdrService tdrService)
        {
            _tdrService = tdrService;
        }

        [HttpPost("InsertTdr")]
        public ActionResult<Response<CommonResponse>> InsertTdr(TDR request)
        {
            return Ok(_tdrService.InsertTdr(request));
        }

        [HttpGet("GetTdrList")]
        public ActionResult<Response<List<TDR>>> GET_CONTAINERLIST()
        {
            return Ok(JsonConvert.SerializeObject(_tdrService.GetTdrList()));
        }

    }
}
