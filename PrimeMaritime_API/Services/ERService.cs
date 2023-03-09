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
    public class ERService : IERService
    {
        private readonly IConfiguration _config;
        public ERService(IConfiguration config)
        {
            _config = config;
        }



        public Response<string> InsertER(EMPTY_REPO erRequest, bool isVessel)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<ERRepo>.Instance.InsertER(dbConn, erRequest,isVessel);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<EMPTY_REPO>> GetERList(string AGENT_CODE, string DEPO_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<EMPTY_REPO>> response = new Response<List<EMPTY_REPO>>();
            var data = DbClientFactory<ERRepo>.Instance.GetERList(dbConn, AGENT_CODE, DEPO_CODE);

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

        public Response<EMPTY_REPO> GetERDetails(string REPO_NO, string AGENT_CODE, string DEPO_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<EMPTY_REPO> response = new Response<EMPTY_REPO>();

            if ((REPO_NO == "") || (REPO_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide BL No";
                return response;
            }


            var data = DbClientFactory<ERRepo>.Instance.GetERDetails(dbConn, REPO_NO, AGENT_CODE, DEPO_CODE);

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

        public Response<List<ER_CONTAINER>> GetERContainerDetails(string REPO_NO, string AGENT_CODE, string DEPO_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<ER_CONTAINER>> response = new Response<List<ER_CONTAINER>>();
            var data = DbClientFactory<ERRepo>.Instance.GetERContainerDetails(dbConn, REPO_NO,AGENT_CODE, DEPO_CODE);

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

        public Response<List<ER_RATES>> GetERRateDetails(string REPO_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<ER_RATES>> response = new Response<List<ER_RATES>>();
            var data = DbClientFactory<ERRepo>.Instance.GetERRateDetails(dbConn, REPO_NO);

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
