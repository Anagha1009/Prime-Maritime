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
    public class ActivityService : IActivityService
    {
        private readonly IConfiguration _config;
        public ActivityService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<ACTIVITY>> GetActivityList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<ACTIVITY>> response = new Response<List<ACTIVITY>>();
            var data = DbClientFactory<ActivityRepo>.Instance.GetActivityList(dbConn);

            if (data.Count > 0)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }
    }
}
