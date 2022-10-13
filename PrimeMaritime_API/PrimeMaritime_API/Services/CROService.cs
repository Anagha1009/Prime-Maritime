using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Services
{
    public class CROService : ICROService
    {
        private readonly IConfiguration _config;
        public CROService(IConfiguration config)
        {
            _config = config;
        }


        public Response<List<CROResponse>> GetCROList(string OPERATION, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CROResponse>> response = new Response<List<CROResponse>>();
            var data = DbClientFactory<CRORepo>.Instance.GetCROList(dbConn, OPERATION, AGENT_CODE);

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

        public Response<string> InsertCRO(CRORequest CRORequest)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<CRORepo>.Instance.InsertCRO(dbConn, CRORequest);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CRO> GetCRODetailsByBookingNo(string BOOKING_NO, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CRO> response = new Response<CRO>();

            if ((BOOKING_NO == "") || (BOOKING_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Booking No";
                return response;
            }

            var data = DbClientFactory<CRORepo>.Instance.GetCRODetailsByBookingNo(dbConn, BOOKING_NO, AGENT_CODE);

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
