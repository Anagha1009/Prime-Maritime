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
    public class SRRReportService : ISRRReportService
    {
        private readonly IConfiguration _config;
        public SRRReportService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<SRR_REPORT>> GetSRRCountList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SRR_REPORT>> response = new Response<List<SRR_REPORT>>();
            var data = DbClientFactory<SRRReportRepo>.Instance.GetSRRCountList(dbConn);

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
