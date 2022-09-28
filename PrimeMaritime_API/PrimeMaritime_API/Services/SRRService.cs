﻿using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
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

            if ((SRR_NO == "") || (SRR_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide SRR No";
                return response;
            }

            var data = DbClientFactory<SRRRepo>.Instance.GetSRRData(dbConn, SRR_NO);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                SRR srr = new SRR();

                srr = SRRRepo.GetSingleDataFromDataSet<SRR>(data.Tables[0]);
                if (data.Tables.Contains("Table1"))
                {
                    srr.SRR_CONTAINERS = SRRRepo.GetListFromDataSet<SRR_CONTAINERS>(data.Tables[1]);
                }

                if (data.Tables.Contains("Table2"))
                {
                    srr.SRR_COMMODITIES = SRRRepo.GetListFromDataSet<SRR_COMMODITIES>(data.Tables[2]);
                }

                if (data.Tables.Contains("Table3"))
                {
                    srr.SRR_RATES = SRRRepo.GetListFromDataSet<SRR_RATES>(data.Tables[3]);
                }

                response.Data = srr;
            }
            else
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<SRRList>> GetSRRList(string SRR_NO, string CUSTOMER_NAME, string STATUS)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SRRList>> response = new Response<List<SRRList>>();
            var data = DbClientFactory<SRRRepo>.Instance.GetSRRList(dbConn,SRR_NO,CUSTOMER_NAME,STATUS);

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

        public Response<SRR> InsertSRR(SRRRequest sRRRequest)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<SRRRepo>.Instance.InsertSRR(dbConn, sRRRequest);

            Response<SRR> response = new Response<SRR>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
