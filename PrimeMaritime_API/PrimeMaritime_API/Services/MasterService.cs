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
    public class MasterService: IMasterService
    {
        private readonly IConfiguration _config;

        public MasterService(IConfiguration config)
        {
            _config = config;
        }

        #region "PARTY MASTER"
        public Response<CommonResponse> DeletePartyMasterDetails(string AgentID,int CUSTOMER_ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();

            if ((AgentID == "") || (AgentID == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide AgentID ";
                return response;
            }

            DbClientFactory<MasterRepo>.Instance.DeletePartyMasterDetails(dbConn, AgentID, CUSTOMER_ID);
          
            response.Succeeded = true;
            response.ResponseMessage = "Master deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<PARTY_MASTER>> GetPartyMasterList(string Agent_code)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<PARTY_MASTER>> response = new Response<List<PARTY_MASTER>>();
            var data = DbClientFactory<MasterRepo>.Instance.GetPartyMasterList(dbConn,Agent_code);

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

        public Response<PARTY_MASTER> GetPartyMasterDetails(string Agent_code, int CUSTOMER_ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<PARTY_MASTER> response = new Response<PARTY_MASTER>();
            var data = DbClientFactory<MasterRepo>.Instance.GetPartyMasterDetails(dbConn, Agent_code,CUSTOMER_ID);

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

        public Response<CommonResponse> UpdatePartyMasterDetails(PARTY_MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();
            DbClientFactory<MasterRepo>.Instance.UpdatePartyMasterDetails(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = "Master updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> InsertPartyMaster(PARTY_MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<MasterRepo>.Instance.InsertPartyMaster(dbConn, request);


            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        #endregion

        #region "CONTAINER MASTER"
        public Response<CommonResponse> InsertContainerMaster(CONTAINER_MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<MasterRepo>.Instance.InsertContainerMaster(dbConn, request);


            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<CONTAINER_MASTER>> GetContainerMasterList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CONTAINER_MASTER>> response = new Response<List<CONTAINER_MASTER>>();
            var data = DbClientFactory<MasterRepo>.Instance.GetContainerMasterList(dbConn);

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

        public Response<CONTAINER_MASTER> GetContainerMasterDetails(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CONTAINER_MASTER> response = new Response<CONTAINER_MASTER>();
            var data = DbClientFactory<MasterRepo>.Instance.GetContainerMasterDetails(dbConn,ID);

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

        public Response<CommonResponse> UpdateContainerMasterList(CONTAINER_MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();
            DbClientFactory<MasterRepo>.Instance.UpdateContainerMasterList(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = "Master updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> DeleteContainerMasterList(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();

            if ((ID ==0) || (ID == 0))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide ID ";
                return response;
            }

            DbClientFactory<MasterRepo>.Instance.DeleteContainerMaster(dbConn,ID);

            response.Succeeded = true;
            response.ResponseMessage = "Master deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
        #endregion

        #region "COMMON MASTER"
        public Response<CommonResponse> InsertMaster(MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<MasterRepo>.Instance.InsertMaster(dbConn, request);


            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<MASTER>> GetMasterList(string key)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<MASTER>> response = new Response<List<MASTER>>();
            var data = DbClientFactory<MasterRepo>.Instance.GetMasterList(dbConn,key);

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

        public Response<MASTER> GetMasterDetails(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<MASTER> response = new Response<MASTER>();
            var data = DbClientFactory<MasterRepo>.Instance.GetMasterDetails(dbConn, ID);

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

        public Response<CommonResponse> UpdateMaster(MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();
            DbClientFactory<MasterRepo>.Instance.UpdateMaster(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = "Master updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> DeleteMaster(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();

            if (ID == 0)
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide ID ";
                return response;
            }

            DbClientFactory<MasterRepo>.Instance.DeleteMaster(dbConn, ID);

            response.Succeeded = true;
            response.ResponseMessage = "Master deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        #endregion
    }
}
