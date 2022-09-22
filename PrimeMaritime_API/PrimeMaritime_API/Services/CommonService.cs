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
    public class CommonService : ICommonService
    {
        private readonly IConfiguration _config;
        public CommonService(IConfiguration config)
        {
            _config = config;
        }
        public Response<List<DROPDOWN>> GetDropdownData(string key)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<DROPDOWN>> response = new Response<List<DROPDOWN>>();

            var data = DbClientFactory<CommonRepo>.Instance.GetDropdownData(dbConn, key);

            if(data != null)
            {
                response.Succeeded = true;
                response.ResponseMessage = "Success";
                response.ResponseCode = 200;
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Records";
            }

            return response;
        }
    }
}
