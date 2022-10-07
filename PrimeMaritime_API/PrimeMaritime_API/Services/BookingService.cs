using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Utility;

namespace PrimeMaritime_API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IConfiguration _config;
        public BookingService(IConfiguration config)
        {
            _config = config;
        }

        public Response<CommonResponse> InsertSlots(BookingRequest request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BookingRepo>.Instance.InsertSlots(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
        public Response<List<SLOT_DETAILS>> GetSlotList(string AGENT_CODE, string SRR_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SLOT_DETAILS>> response = new Response<List<SLOT_DETAILS>>();
            var data = DbClientFactory<BookingRepo>.Instance.GetSlotList(dbConn, AGENT_CODE, SRR_NO);

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
