using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Utility;
using System.Collections.Generic;

namespace PrimeMaritime_API.Services
{
    public class SRRService : ISRRService
    {
        private readonly IConfiguration _config;
        public SRRService(IConfiguration config)
        {
            _config = config;
        }
        public Response<List<SRR>> GetSRRList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SRR>> response = new Response<List<SRR>>();
            var data = DbClientFactory<SRRRepo>.Instance.GetSRRList(dbConn);

            if (data != null)
            {
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }
    }
}
