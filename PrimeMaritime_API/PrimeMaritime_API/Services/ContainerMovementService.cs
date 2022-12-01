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
    public class ContainerMovementService:IContainerMovementService
    {
        private readonly IConfiguration _config;
        public ContainerMovementService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<CMList>> GetContainerMovementList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CMList>> response = new Response<List<CMList>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetContainerMovementList(dbConn, AGENT_CODE, DEPO_CODE, BOOKING_NO, CRO_NO, CONTAINER_NO);

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

        public Response<CommonResponse> InsertContainerMovement(CONTAINER_MOVEMENT request, bool fromXL)
        {

            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<ContainerMovementRepo>.Instance.InsertContainerMovement(dbConn, request,fromXL);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;

        }

        public Response<CM> GetSingleContainerMovement(string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CM> response = new Response<CM>();

            if ((CONTAINER_NO == "") || (CONTAINER_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Container No";
                return response;
            }


            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetSingleContainerMovement(dbConn, CONTAINER_NO);

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

        public Response<List<CM>> GetContainerMovementBooking(string BOOKING_NO, string CRO_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CM>> response = new Response<List<CM>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetContainerMovementBooking(dbConn,BOOKING_NO, CRO_NO);

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
