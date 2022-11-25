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
    public class BLService : IBLService
    {
        private readonly IConfiguration _config;
        public BLService(IConfiguration config)
        {
            _config = config;
        }

        

        public Response<CommonResponse> InsertBL(BL request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BLRepo>.Instance.InsertBL(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "BL Created Successfully.";
            response.ResponseCode = 200;

            return response;
        }
        public Response<BL> GetBLDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<BL> response = new Response<BL>();

            if ((BL_NO == "") || (BL_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide BL No";
                return response;
            }

            var data = DbClientFactory<BLRepo>.Instance.GetBLData(dbConn, BL_NO, BOOKING_NO, AGENT_CODE);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                BL bl = new BL();

                bl = BLRepo.GetSingleDataFromDataSet<BL>(data.Tables[0]);
                if (data.Tables.Contains("Table1"))
                {
                    bl.CONTAINER_LIST = BLRepo.GetListFromDataSet<CONTAINERS>(data.Tables[1]);
                }

                response.Data = bl;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<SRR> GetSRRDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<SRR> response = new Response<SRR>();
            var data = DbClientFactory<BLRepo>.Instance.GetSRRDetails(dbConn, BL_NO, BOOKING_NO, AGENT_CODE);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                SRR srr = new SRR();

                srr = BLRepo.GetSingleDataFromDataSet<SRR>(data.Tables[0]);
                if (data.Tables.Contains("Table1"))
                {
                    srr.SRR_RATES = BLRepo.GetListFromDataSet<SRR_RATES>(data.Tables[1]);
                }

                response.Data = srr;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<CONTAINERS>> GetContainerList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO, string BL_NO, string DO_NO, bool fromDO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CONTAINERS>> response = new Response<List<CONTAINERS>>();
            var data = DbClientFactory<BLRepo>.Instance.GetContainerList(dbConn, AGENT_CODE, BOOKING_NO, CRO_NO, BL_NO, DO_NO, fromDO);

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
