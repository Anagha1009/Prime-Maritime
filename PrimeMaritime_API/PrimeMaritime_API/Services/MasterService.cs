using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Services
{
    public class MasterService: IMasterService
    {
        private readonly IConfiguration _config;

        public MasterService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<MASTER>> GetMasterList(string Agent_code)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<MASTER>> response = new Response<List<MASTER>>();
            var data = DbClientFactory<MasterRepo>.Instance.GetMasterList(dbConn,Agent_code);

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
        public Response<CommonResponse> InsertMaster(MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<MasterRepo>.Instance.InsertMaster(dbConn, request);


            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
