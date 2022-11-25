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
    public class DetentionService : IDetentionService
    {
        private readonly IConfiguration _config;

        public DetentionService(IConfiguration config)
        {
            _config = config;
        }
        public Response<List<DETENTION_REQUEST>> GetDetentionList(string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<DETENTION_REQUEST>> response = new Response<List<DETENTION_REQUEST>>();
            var data = DbClientFactory<DetentionRepo>.Instance.GetDetentionList(dbConn, AGENT_CODE);

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

        public Response<CommonResponse> InsertDetention(DETENTION_REQUEST request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DetentionRepo>.Instance.InsertDetention(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Detention saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

    }
}
