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
    public class ContainerMovementService:IContainerMovementService
    {
        private readonly IConfiguration _config;
        public ContainerMovementService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<CMList>> GetContainerMovementList(string BOOKING_NO, string CRO_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CMList>> response = new Response<List<CMList>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetContainerMovementList(dbConn, BOOKING_NO, CRO_NO);

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

        public Response<List<CM>> GetAvailableContainerListForDepo(string DEPO_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CM>> response = new Response<List<CM>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetAvailableContainerListForDepo(dbConn, DEPO_CODE);

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

        public Response<List<CM>> GetAllContainerListForDepo(string DEPO_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CM>> response = new Response<List<CM>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetAllContainerListForDepo(dbConn, DEPO_CODE);

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
        public Response<List<CM>> GetAllContainerListForAdmin(string LOCATION)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CM>> response = new Response<List<CM>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetAllContainerListForAdmin(dbConn, LOCATION);

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

        public Response<CommonResponse> InsertContainerMovement(CONTAINER_MOVEMENT request, bool fromXL)
        {

            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<ContainerMovementRepo>.Instance.InsertContainerMovement(dbConn, request,fromXL);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
        public Response<CommonResponse> ValidContainer(string ContainerNo)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            var data = DbClientFactory<ContainerMovementRepo>.Instance.ValidContainer(dbConn, ContainerNo);

            if(data != "")
            {
                Response<CommonResponse> response = new Response<CommonResponse>();
                response.Succeeded = true;
                response.ResponseMessage = "Container No is Valid";
                response.ResponseCode = 200;

                return response;
            }
            else
            {
                Response<CommonResponse> response = new Response<CommonResponse>();
                response.Succeeded = true;
                response.ResponseMessage = "Container No is not Valid";
                response.ResponseCode = 500;

                return response;
            }
        }
        public Response<string> ValidCROForContainer(string ContainerNo)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            var data = DbClientFactory<ContainerMovementRepo>.Instance.ValidCROForContainer(dbConn, ContainerNo);

            if (data != "")
            {
                Response<string> response = new Response<string>();
                response.Succeeded = true;
                response.ResponseMessage = "CRO No is Valid";
                response.ResponseCode = 200;
                response.Data = data;

                return response;
            }
            else
            {
                Response<string> response = new Response<string>();
                response.Succeeded = true;
                response.ResponseMessage = "CRO No is not Valid";
                response.ResponseCode = 500;

                return response;
            }
        }

        public Response<CM> GetSingleContainerMovement(string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CM> response = new Response<CM>();

            if ((CONTAINER_NO == "") || (CONTAINER_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Container No";
                return response;
            }


            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetSingleContainerMovement(dbConn, CONTAINER_NO);

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

        public Response<List<CM>> GetContainerMovementBooking(string BOOKING_NO, string CRO_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CM>> response = new Response<List<CM>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetContainerMovementBooking(dbConn,BOOKING_NO, CRO_NO);

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

        public Response<List<CM>> GetCMAvailable(string STATUS, string CURRENT_LOCATION)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<CM>> response = new Response<List<CM>>();
            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetCMAvailable(dbConn, STATUS, CURRENT_LOCATION);

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

        public Response<CONTAINERMOVEMENT> GetContainerMovement(string BOOKING_NO, string CRO_NO, string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CONTAINERMOVEMENT> response = new Response<CONTAINERMOVEMENT>();

            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetContainerMovement(dbConn, BOOKING_NO, CRO_NO, CONTAINER_NO);

            if ((data != null) && (data.Tables.Count > 0))
            {
                if(data.Tables[0].Rows.Count > 0)
                {
                    response.Succeeded = true;
                    response.ResponseCode = 200;
                    response.ResponseMessage = "Success";
                    CONTAINERMOVEMENT cm = new CONTAINERMOVEMENT();

                    cm = ContainerMovementRepo.GetSingleDataFromDataSet<CONTAINERMOVEMENT>(data.Tables[0]);

                    if (data.Tables.Contains("Table1"))
                    {
                        cm.NEXT_ACTIVITY_LIST = ContainerMovementRepo.GetListFromDataSet<NEXT_ACTIVITY>(data.Tables[1]);
                    }

                    response.Data = cm;
                }
                else
                {
                    response.Succeeded = false;
                    response.ResponseCode = 500;
                    response.ResponseMessage = "No Data";
                }
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> UpdateContainerMovement(CONTAINERMOVEMENT cm)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();
            DbClientFactory<ContainerMovementRepo>.Instance.UpdateContainerMovement(dbConn, cm);

            response.Succeeded = true;
            response.ResponseCode = 200;
            response.ResponseMessage = "Success";
            response.Data = "Updated Successfully !";

            return response;
        }

        public Response<string> UploadContainerMovement(List<CONTAINERMOVEMENT> cm)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();
            DbClientFactory<ContainerMovementRepo>.Instance.UploadContainerMovement(dbConn, cm);

            response.Succeeded = true;
            response.ResponseCode = 200;
            response.ResponseMessage = "Success";
            response.Data = "Uploaded Successfully !";

            return response;
        }

        public Response<List<NEXT_ACTIVITY>> GetNextActivityList(string CONTAINER_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<NEXT_ACTIVITY>> response = new Response<List<NEXT_ACTIVITY>>();

            if ((CONTAINER_NO == "") || (CONTAINER_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Container No";
                return response;
            }

            var data = DbClientFactory<ContainerMovementRepo>.Instance.GetNextActivityList(dbConn, CONTAINER_NO);

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
    }
}
