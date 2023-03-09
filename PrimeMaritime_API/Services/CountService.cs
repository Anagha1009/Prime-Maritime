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
    public class CountService: ICountService
    {
        private readonly IConfiguration _config;

        public CountService(IConfiguration config)
        {
            _config = config;
        }

        public Response<COUNT> GETCOUNT()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<COUNT> response = new Response<COUNT>();
            var data = DbClientFactory<CountRepo>.Instance.GETCOUNT(dbConn);

            if (data != null)
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
