using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DepoController : ControllerBase
    {
        private IDepoService _depoService;
        public DepoController(IDepoService depoService)
        {
            _depoService = depoService;
        }

        [HttpPost("InsertContainer")]
        public ActionResult<Response<CommonResponse>> InsertContainer(DEPO_CONTAINER request)
        {
            return Ok(_depoService.InsertContainer(request));
        }
    }
}
