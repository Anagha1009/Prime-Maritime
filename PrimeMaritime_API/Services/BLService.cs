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

        public Response<string> InsertBL(BL request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BLRepo>.Instance.InsertBL(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "BL Created Successfully.";
            response.ResponseCode = 200;

            return response;
        }
        public void InsertSurrender(string BL_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BLRepo>.Instance.InsertSurrender(dbConn, BL_NO);
        }
        public void InsertUploadedSurrender(string BL_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BLRepo>.Instance.InsertUploadedSurrender(dbConn, BL_NO);
        }

        public Response<Organisation> GetOrgDetails(string ORG_CODE, string ORG_LOC_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<Organisation> response = new Response<Organisation>();

            //if ((ORG_CODE == "") || (ORG_CODE == null) || (ORG_LOC_CODE == "") || (ORG_LOC_CODE == null))
            //{
            //    response.ResponseCode = 500;
            //    response.ResponseMessage = "Please provide Sufficient details";
            //    return response;
            //}


            var data = DbClientFactory<BLRepo>.Instance.GetOrgDetails(dbConn, ORG_CODE, ORG_LOC_CODE);

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

        //public Response<string> UpdateBL(List<BL> request)
        //{
        //    string dbConn = _config.GetConnectionString("ConnectionString");

        //    DbClientFactory<BLRepo>.Instance.UpdateBL(dbConn, request);

        //    Response<string> response = new Response<string>();
        //    response.Succeeded = true;
        //    response.ResponseMessage = "Updated Successfully.";
        //    response.ResponseCode = 200;
        //    response.Data = "1";

        //    return response;
        //}
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
            var data = DbClientFactory<BLRepo>.Instance.GetContainerList(dbConn, AGENT_CODE, DEPO_CODE, BOOKING_NO, CRO_NO, BL_NO, DO_NO, fromDO);

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

        public Response<CargoManifest> GetCargoManifestList(string AgentCode, string VESSEL_NAME, string VOYAGE_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CargoManifest> response = new Response<CargoManifest>();

            if ((VESSEL_NAME == "") || (VESSEL_NAME == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Vessel Name";
                return response;
            }

            if ((VOYAGE_NO == "") || (VOYAGE_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Voyage No";
                return response;
            }

            var data = DbClientFactory<BLRepo>.Instance.CargoManifestData(dbConn, AgentCode, VESSEL_NAME, VOYAGE_NO);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                CargoManifest cargoManifest = new CargoManifest();

                if (data.Tables.Contains("Table"))
                {
                    cargoManifest.CUSTOMER_LIST = BLRepo.GetListFromDataSet<BL_CUSTOMERLIST>(data.Tables[0]);
                }

                if (data.Tables.Contains("Table1"))
                {
                    cargoManifest.CONTAINER_LIST = BLRepo.GetListFromDataSet<BL_CONTAINERS>(data.Tables[1]);
                }
                if (data.Tables.Contains("Table2"))
                {
                    cargoManifest.FREIGHT_DETAILS = BLRepo.GetListFromDataSet<FREIGHT_DETAILS>(data.Tables[2]);
                }
                response.Data = cargoManifest;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<BL>> GetBLHistory(string AGENT_CODE, string ORG_CODE, string PORT)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<BL>> response = new Response<List<BL>>();
            var data = DbClientFactory<BLRepo>.Instance.GetBLHistory(dbConn, AGENT_CODE,ORG_CODE,PORT);

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

        public Response<List<BL>> GetBLSurrenderedList(string POD, string ORG_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<BL>> response = new Response<List<BL>>();
            var data = DbClientFactory<BLRepo>.Instance.GetBLSurrenderedList(dbConn, POD, ORG_CODE);

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

        public Response<List<BL>> GetBLListPM()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<BL>> response = new Response<List<BL>>();
            var data = DbClientFactory<BLRepo>.Instance.GetBLListPM(dbConn);

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

        public Response<string> UpdateBL(BL request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BLRepo>.Instance.UpdateBL(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "BL Created Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<BL>> GetBLFORMERGE(string PORT_OF_LOADING, string PORT_OF_DISCHARGE, string SHIPPER, string CONSIGNEE, string VESSEL_NAME, string VOYAGE_NO, string NOTIFY_PARTY)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<BL>> response = new Response<List<BL>>();
            var data = DbClientFactory<BLRepo>.Instance.GetBLFORMERGE(dbConn, PORT_OF_LOADING, PORT_OF_DISCHARGE, SHIPPER, CONSIGNEE, VESSEL_NAME, VOYAGE_NO, NOTIFY_PARTY);

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
