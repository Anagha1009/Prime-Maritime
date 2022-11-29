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
    public class DepoService : IDepoService
    {
        private readonly IConfiguration _config;
        public DepoService(IConfiguration config)
        {
            _config = config;
        }

        public Response<CommonResponse> InsertContainer(DEPO_CONTAINER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DEPORepo>.Instance.InsertContainer(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Container is alloted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> InsertMRRequest(List<MR_LIST> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DEPORepo>.Instance.InsertMRRequest(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "M&R Request is inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
