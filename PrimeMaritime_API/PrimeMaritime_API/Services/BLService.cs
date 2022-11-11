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
    public class BLService : IBLService
    {
        private readonly IConfiguration _config;
        public BLService(IConfiguration config)
        {
            _config = config;
        }

        

        public Response<List<CONTAINERS>> GetContainerList(string AgentID, string BOOKING_NO, string CRO_NO, string BL_NO,string DO_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CONTAINERS>> response = new Response<List<CONTAINERS>>();
            var data = DbClientFactory<BLRepo>.Instance.GetContainerList(dbConn, AgentID, BOOKING_NO, CRO_NO,BL_NO,DO_NO);

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

        public Response<CommonResponse> InsertBL(BL request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BLRepo>.Instance.InsertBL(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "BL Created Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
