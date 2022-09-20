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
        public Response<SRR> GetSRRBySRRNo(string SRR_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<SRR> response = new Response<SRR>();
            var data = DbClientFactory<SRRRepo>.Instance.GetSRRData(dbConn, SRR_NO);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                SRR srr = new SRR();
                
                srr = SRRRepo.GetSingleDataFromDataSet<SRR>(data.Tables[0]);
                srr.SRR_CONTAINERS = SRRRepo.GetListFromDataSet<SRR_CONTAINERS>(data.Tables[1]);

                response.Data = srr;
            }
            else
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<SRR>> GetSRRList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SRR>> response = new Response<List<SRR>>();
            var data = DbClientFactory<SRRRepo>.Instance.GetSRRList(dbConn);

            if(data != null)
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
