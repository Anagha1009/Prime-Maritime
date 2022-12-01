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
    public class ContainerTrackingService:IContainerTrackingService
    {
        private readonly IConfiguration _config;
        public ContainerTrackingService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<CT>> GetContainerTrackingAsPerBooking(string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CT>> response = new Response<List<CT>>();
            var data = DbClientFactory<ContainerTrackingRepo>.Instance.GetContainerTrackingAsPerBooking(dbConn, BOOKING_NO, CRO_NO,CONTAINER_NO);

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

        public Response<List<CT>> GetContainerTrackingList(string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CT>> response = new Response<List<CT>>();
            var data = DbClientFactory<ContainerTrackingRepo>.Instance.GetContainerTrackingList(dbConn, CONTAINER_NO);

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


        public Response<CommonResponse> InsertContainerTracking(CONTAINER_TRACKING request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<ContainerTrackingRepo>.Instance.InsertContainerTracking(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
