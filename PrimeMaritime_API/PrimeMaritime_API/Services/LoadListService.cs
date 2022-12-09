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
    public class LoadlistService : ILoadtlistService
    {
        private readonly IConfiguration _config;

        public LoadlistService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<LOAD_LIST>> GetLoadList(string VESSEL_NAME,string VOYAGE_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<LOAD_LIST>> response = new Response<List<LOAD_LIST>>();
            var data = DbClientFactory<LoadlistRepo>.Instance.GetLoadList(dbConn ,VESSEL_NAME,VOYAGE_NO);

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
