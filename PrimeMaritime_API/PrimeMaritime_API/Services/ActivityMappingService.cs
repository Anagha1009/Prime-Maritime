using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Services
{
    public class ActivityMappingService : IActivityMappingService
    {
        private readonly IConfiguration _config;
        public ActivityMappingService(IConfiguration config)
        {
            _config = config;
        }
        public Response<string> InsertActivityMapping(ACTIVITY_MAPPING Request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<ActivityMappingRepo>.Instance.InsertActivityMapping(dbConn, Request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
