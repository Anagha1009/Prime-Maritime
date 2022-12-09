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
    public class DepoService : IDepoService
    {
        private readonly IConfiguration _config;
        public DepoService(IConfiguration config)
        {
            _config = config;
        }



        public Response<CommonResponse> InsertContainer(DEPO_CONTAINER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DEPORepo>.Instance.InsertContainer(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Container is alloted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> InsertMRRequest(List<MR_LIST> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DEPORepo>.Instance.InsertMRRequest(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "M&R Request is inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> GetMNRDesc(string Ist_char, string IInd_char, string IIIrd_char, string IVth_char, string component_code, string damage_code, string repair_code)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            string returnString = DbClientFactory<DEPORepo>.Instance.GetMNRDescription(dbConn, Ist_char, IInd_char, IIIrd_char, IVth_char, component_code, damage_code, repair_code);

            Response<string> response = new Response<string>();

            response.Succeeded = true;
            response.ResponseMessage = "Success";
            response.ResponseCode = 200;
            response.Data = returnString;

            return response;
        }

        public Response<List<MR_LIST>> GetMNRDetails(string MR_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<MR_LIST>> response = new Response<List<MR_LIST>>();
            var data = DbClientFactory<DEPORepo>.Instance.GetMRREQDetails(dbConn, MR_NO);

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

        public Response<List<MNR_LIST>> GetMNRList(string OPERATION, string DEPO_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<MNR_LIST>> response = new Response<List<MNR_LIST>>();
            var data = DbClientFactory<DEPORepo>.Instance.GetMNRList(dbConn, OPERATION, DEPO_CODE);

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

        public Response<string> ApproveRate(List<MR_LIST> request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<DEPORepo>.Instance.ApproveRate(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Rate Approved Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
