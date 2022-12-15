using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
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
    public class TdrService : ITdrService
    {
        private readonly IConfiguration _config;

        public TdrService(IConfiguration config)
        {
            _config = config;
        }
        public Response<CommonResponse> InsertTdr(TDR request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<TdrRepo>.Instance.InsertTdr(dbConn, request);


            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<TDR>> GetTdrList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<TDR>> response = new Response<List<TDR>>();
            var data = DbClientFactory<TdrRepo>.Instance.GetTdrList(dbConn);

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
