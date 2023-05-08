using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IServices;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Repository;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Utility;

namespace PrimeMaritime_API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IConfiguration _config;
        public BookingService(IConfiguration config)
        {
            _config = config;
        }

        public Response<BookingDetails> GetBookingDetails(string AgentID, string BOOKING_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<BookingDetails> response = new Response<BookingDetails>();

            if ((BOOKING_NO == "") || (BOOKING_NO == null))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide Booking No";
                return response;
            }

            var data = DbClientFactory<BookingRepo>.Instance.GetBookingData(dbConn, BOOKING_NO, AgentID);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                BookingDetails bookng = new BookingDetails();

                bookng = BookingRepo.GetSingleDataFromDataSet<BookingDetails>(data.Tables[0]);

                if (data.Tables.Contains("Table1"))
                {
                    bookng.CONTAINER_LIST = SRRRepo.GetListFromDataSet<SRR_CONTAINERS>(data.Tables[1]);
                }

                if (data.Tables.Contains("Table2"))
                {
                    bookng.SLOT_LIST = SRRRepo.GetListFromDataSet<SLOT_DETAILS>(data.Tables[2]);
                }

                response.Data = bookng;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<BookingList>> GetBookingList(string AGENT_CODE, string BOOKING_NO, string FROM_DATE, string TO_DATE, string ORG_CODE, string PORT)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<BookingList>> response = new Response<List<BookingList>>();
            var data = DbClientFactory<BookingRepo>.Instance.GetBookingList(dbConn, AGENT_CODE, BOOKING_NO, FROM_DATE, TO_DATE,ORG_CODE,PORT);

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
        public Response<List<BookingList>> GetBookingListPM(string BOOKING_NO, string FROM_DATE, string TO_DATE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<BookingList>> response = new Response<List<BookingList>>();
            var data = DbClientFactory<BookingRepo>.Instance.GetBookingListPM(dbConn, BOOKING_NO, FROM_DATE, TO_DATE);

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
        public Response<int> GetTrackingDetails(string BOOKING_NO)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            int returnNo = Convert.ToInt32(DbClientFactory<BookingRepo>.Instance.GetTrackingDetail(dbConn, BOOKING_NO));

            Response<int> response = new Response<int>();

            response.Succeeded = true;
            response.ResponseCode = 200;
            response.Data = returnNo;

            return response;
        }

        public Response<CommonResponse> InsertBooking(BOOKING request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BookingRepo>.Instance.InsertBooking(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Booked Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> InsertVoyage(VOYAGE request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BookingRepo>.Instance.InsertVoyage(dbConn, request);

            Response<CommonResponse> response = new Response<CommonResponse>();
            response.Succeeded = true;
            response.ResponseMessage = "Voyage Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> ValidateSlots(string SRR_NO, int NO_OF_SLOTS, string BOOKING_NO, string SLOT_OPERATOR)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            string returnString = DbClientFactory<BookingRepo>.Instance.ValidateSlots(dbConn, SRR_NO, NO_OF_SLOTS, BOOKING_NO, SLOT_OPERATOR);

            Response<string> response = new Response<string>();

            if (returnString == "1")
            {
                response.Succeeded = true;
                response.ResponseMessage = "Success";
                response.ResponseCode = 200;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseMessage = "Sorry ! You cannot book more no of slots than no of containers";
                response.ResponseCode = 500;
            }

            return response;

        }

        public Response<List<ROLLOVER>> GetRolloverList( string AGENT_CODE)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<ROLLOVER>> response = new Response<List<ROLLOVER>>();
            var data = DbClientFactory<BookingRepo>.Instance.GetRolloverList(dbConn,  AGENT_CODE);

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

        //public Response<List<RollOverList>> GetRolloverList()
        //{
        //    string dbConn = _config.GetConnectionString("ConnectionString");

        //    Response<List<RollOverList>> response = new Response<List<GetRolloverList>>();
        //    var data = DbClientFactory<BookingRepo>.Instance.GetRolloverList(dbConn);

        //    if (data != null)
        //    {
        //        response.Succeeded = true;
        //        response.ResponseCode = 200;
        //        response.ResponseMessage = "Success";
        //        response.Data = data;
        //    }
        //    else
        //    {
        //        response.Succeeded = false;
        //        response.ResponseCode = 500;
        //        response.ResponseMessage = "No Data";
        //    }

        //    return response;
        //}

    }
}

