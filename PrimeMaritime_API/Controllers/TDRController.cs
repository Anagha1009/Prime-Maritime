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
    public class TDRController : Controller
    {
        private ITDRService _tdrService;
        public TDRController(ITDRService tdrService)
        {
            _tdrService = tdrService;
        }

        [HttpPost("InsertTdr")]
        public ActionResult<Response<CommonResponse>> InsertTdr(TDR request)
        {
            return Ok(_tdrService.InsertTdr(request));
        }

        [HttpGet("GetTdrList")]
        public ActionResult<Response<List<TDR>>> GetTdrList()
        {
            return Ok(JsonConvert.SerializeObject(_tdrService.GetTdrList()));
        }

        [HttpGet("GetTdrDetails")]
        public ActionResult<Response<TDR>> GetTdrDetails(string TDR_NO)
        {
            return Ok(JsonConvert.SerializeObject(_tdrService.GetTdrDetails(TDR_NO)));
        }
    }
}