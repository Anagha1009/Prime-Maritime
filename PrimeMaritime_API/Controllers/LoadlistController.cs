using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class LoadlistController : ControllerBase
    {
        private ILoadtlistService _loadListService;
        public LoadlistController(ILoadtlistService loadListService)
        {
            _loadListService = loadListService;
        }

        [HttpGet("GetLoadList")]
        public ActionResult<Response<List<LOAD_LIST>>> GetLoadList(string VESSEL_NAME,string VOYAGE_NO)
        {
            return Ok(JsonConvert.SerializeObject(_loadListService.GetLoadList(VESSEL_NAME, VOYAGE_NO)));
        }
    }
}
