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

        public Response<List<DETENTION_WAIVER_REQUEST>> GetDetentionListByDO(string DO_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<DETENTION_WAIVER_REQUEST>> response = new Response<List<DETENTION_WAIVER_REQUEST>>();
            var data = DbClientFactory<DetentionRepo>.Instance.GetDetentionList(dbConn, DO_NO);

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

        public Response<string> InsertDetention(DETENTION Request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DetentionRepo>.Instance.InsertDetention(dbConn, Request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
