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
    public class ActivityService : IActivityService
    {
        private readonly IConfiguration _config;
        public ActivityService(IConfiguration config)
        {
            _config = config;
        }

        public Response<ACTIVITY> GetActivityDetailsByCode(string ACT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<ACTIVITY> response = new Response<ACTIVITY>();

            if ((ACT_CODE == "") || (ACT_CODE == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Activity Code";
                return response;
            }

            var data = DbClientFactory<ActivityRepo>.Instance.GetActivityDetailsByCode(dbConn, ACT_CODE);

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

        public Response<List<ACTIVITY>> GetActivityList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<ACTIVITY>> response = new Response<List<ACTIVITY>>();
            var data = DbClientFactory<ActivityRepo>.Instance.GetActivityList(dbConn);

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

        public Response<ActivityMappingResponse> GetActivityMappingDetailsByID(int ACT_ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<ActivityMappingResponse> response = new Response<ActivityMappingResponse>();

            if ((ACT_ID == 0))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Activity ID";
                return response;
            }

            var data = DbClientFactory<ActivityRepo>.Instance.GetActivityMappingDetailsByID(dbConn, ACT_ID);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                ActivityMappingResponse activity = new ActivityMappingResponse();

                activity = ActivityRepo.GetSingleDataFromDataSet<ActivityMappingResponse>(data.Tables[0]);

                activity.ActivityList = ActivityRepo.GetListFromDataSet<ACTIVITY>(data.Tables[0]);

                response.Data = activity;
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
