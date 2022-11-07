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
    public class DOService:IDOService
    {
        private readonly IConfiguration _config;
        public DOService(IConfiguration config)
        {
            _config = config;
        }


        
        public Response<string> InsertDO(DO doRequest)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DORepo>.Instance.InsertDO(dbConn, doRequest);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<DO>> GetDOList(string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<DO>> response = new Response<List<DO>>();
            var data = DbClientFactory<DORepo>.Instance.GetDOList(dbConn, AGENT_CODE);

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

        public Response<DO> GetDODetails(string DO_NO, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<DO> response = new Response<DO>();

            if ((DO_NO == "") || (DO_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide BL No";
                return response;
            }

            
            var data = DbClientFactory<DORepo>.Instance.GetDODetails(dbConn, DO_NO, AGENT_CODE);

            if ((data != null))
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
