using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Utility;
using System;
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

        public Response<CommonResponse> ApproveRate(List<SRR_RATES> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<SRRRepo>.Instance.ApproveRate(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Rate Approved Successfully.";
            response.ResponseCode = 200;

            return response;

        }

        public Response<CommonResponse> CounterRate(List<SRR_RATES> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<SRRRepo>.Instance.CounterRate(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Counter Rate inserted Successfully.";
            response.ResponseCode = 200;

            return response;

        }

        public Response<RATES> GetCalRates(string POL, string POD, string CONTAINER_TYPE, string SRR_NO, int NO_OF_CONTAINERS)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<RATES> response = new Response<RATES>();

            var data = DbClientFactory<SRRRepo>.Instance.GetCalRates(dbConn, POL, POD, CONTAINER_TYPE, SRR_NO, NO_OF_CONTAINERS);

            if ((data != null) && (data.Tables.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                RATES rates = new RATES();

                rates.FREIGHTLIST = SRRRepo.GetListFromDataSet<FREIGHT>(data.Tables[0]);

                if (data.Tables.Contains("Table1"))
                {
                    rates.IMP_COSTLIST = SRRRepo.GetListFromDataSet<CHARGE>(data.Tables[1]);
                }

                if (data.Tables.Contains("Table2"))
                {
                    rates.EXP_COSTLIST = SRRRepo.GetListFromDataSet<CHARGE>(data.Tables[2]);
                }

                if (data.Tables.Contains("Table3"))
                {
                    rates.LADEN_BACK_COST = Convert.ToDecimal(data.Tables[3].Rows[0].ItemArray[0]);
                }

                response.Data = rates;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> GetRate(string POL, string POD, string CHARGE, string CONT_TYPE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();

            var data = DbClientFactory<SRRRepo>.Instance.GetRates(dbConn, POL, POD, CHARGE, CONT_TYPE);

            if (data != null || data != "")
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

        public Response<SRR> GetSRRBySRRNo(string SRR_NO, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<SRR> response = new Response<SRR>();

            if ((SRR_NO == "") || (SRR_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide SRR No";
                return response;
            }

            var data = DbClientFactory<SRRRepo>.Instance.GetSRRData(dbConn, SRR_NO, AGENT_CODE);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
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
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<SRRList>> GetSRRList(string OPERATION, string SRR_NO, string CUSTOMER_NAME, string STATUS, string FROMDATE, string TODATE, string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SRRList>> response = new Response<List<SRRList>>();
            var data = DbClientFactory<SRRRepo>.Instance.GetSRRList(dbConn,OPERATION,SRR_NO,CUSTOMER_NAME,STATUS,FROMDATE,TODATE, AGENT_CODE);

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

        public Response<string> InsertContainer(List<SRR_CONTAINERS> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<SRRRepo>.Instance.InsertContainer(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> InsertSRR(SRRRequest sRRRequest)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            string SRRID = DbClientFactory<SRRRepo>.Instance.InsertSRR(dbConn, sRRRequest);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;
            response.Data = SRRID;

            return response;
        }

        public Response<string> UpdateSRR(List<SRRRequest> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<SRRRepo>.Instance.UpdateSRR(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Updated Successfully.";
            response.ResponseCode = 200;
            response.Data = "1";

            return response;
        }
    }
}
