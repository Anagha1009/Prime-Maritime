using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRRController : ControllerBase
    {

        private IConfiguration _config;
        public SRRController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public Response<List<SRR>> GetSRRList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SRR>> response = new Response<List<SRR>>();
            var data = DbClientFactory<UserDBClient>.Instance.GetSRRList(dbConn);

            if(data != null)
            {
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }
            
            return response;
        }
    }
}
