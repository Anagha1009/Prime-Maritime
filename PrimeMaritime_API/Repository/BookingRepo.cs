using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class BookingRepo
    {

        public DataSet GetBookingData(string connstring, string BOOKING_NO, string AGENT_CODE)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_BOOKINGDETAILS" },
                new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
                new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
            };

            return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_BOOKING", parameters);
        }

        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }

        public void InsertBooking(string connstring, BOOKING request)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CREATE_BOOKING" },
              new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = request.BOOKING_NO },
              new SqlParameter("@SRR_ID", SqlDbType.Int) { Value = request.SRR_ID },
              new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = request.SRR_NO },
              new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar, 255) { Value = request.VESSEL_NAME },
              new SqlParameter("@VOYAGE_NO", SqlDbType.VarChar, 50) { Value = request.VOYAGE_NO },
              new SqlParameter("@MOTHER_VESSEL_NAME", SqlDbType.VarChar, 255) { Value = request.MOTHER_VESSEL_NAME },
              new SqlParameter("@MOTHER_VOYAGE_NO", SqlDbType.VarChar, 50) { Value = request.MOTHER_VOYAGE_NO },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
              new SqlParameter("@AGENT_NAME", SqlDbType.VarChar,255) { Value = request.AGENT_NAME },
              new SqlParameter("@STATUS", SqlDbType.VarChar,50) { Value = request.STATUS },
              new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = request.CREATED_BY },
              new SqlParameter("@IS_ROLLOVER", SqlDbType.Bit) { Value = request.IS_ROLLOVER },
            };

            var RETURNID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_BOOKING", parameters);

            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("BOOKING_ID", typeof(int)));
            tbl.Columns.Add(new DataColumn("BOOKING_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("ROLLOVER_ID", typeof(int)));
            tbl.Columns.Add(new DataColumn("SLOT_OPERATOR", typeof(string)));
            tbl.Columns.Add(new DataColumn("NO_OF_SLOTS", typeof(string)));
            tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

            foreach (var i in request.SLOT_LIST)
            {
                DataRow dr = tbl.NewRow();

                dr["BOOKING_ID"] = Convert.ToInt32(request.IS_ROLLOVER ? request.ID : RETURNID);
                dr["BOOKING_NO"] = request.BOOKING_NO;
                dr["ROLLOVER_ID"] = Convert.ToInt32(!request.IS_ROLLOVER ? 0 : RETURNID); 
                dr["SLOT_OPERATOR"] = i.SLOT_OPERATOR;
                dr["NO_OF_SLOTS"] = i.NO_OF_SLOTS;
                dr["CREATED_BY"] = request.CREATED_BY;

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[6];
            columns[0] = "BOOKING_ID";
            columns[1] = "BOOKING_NO";
            columns[2] = "ROLLOVER_ID";
            columns[3] = "SLOT_OPERATOR";
            columns[4] = "NO_OF_SLOTS";
            columns[5] = "CREATED_BY";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_SLOT_DETAILS", columns);
        }

        public List<BookingList> GetBookingList(string connstring, string AGENT_CODE, string BOOKING_NO, string FROM_DATE, string TO_DATE, string ORG_CODE, string PORT)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_BOOKINGLIST" },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,50) { Value = AGENT_CODE },
              new SqlParameter("@BOOKING_NO", SqlDbType.VarChar,100) { Value = BOOKING_NO },
              new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
              new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE},
              new SqlParameter("@ORG_CODE", SqlDbType.VarChar,20) { Value = ORG_CODE },
              new SqlParameter("@PORT", SqlDbType.VarChar,100) { Value = PORT },

            };

            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_BOOKING", parameters);
            List<BookingList> bookingList = SqlHelper.CreateListFromTable<BookingList>(dataTable);

            return bookingList;
        }
        public List<BookingList> GetBookingListPM(string connstring,string BOOKING_NO, string FROM_DATE, string TO_DATE)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_BOOKINGLIST_PM" },
              new SqlParameter("@BOOKING_NO", SqlDbType.VarChar,100) { Value = BOOKING_NO },
              new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
              new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE},
            };

            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_BOOKING", parameters);
            List<BookingList> bookingList = SqlHelper.CreateListFromTable<BookingList>(dataTable);

            return bookingList;
        }

        public string ValidateSlots(string connstring, string SRR_NO, int NO_OF_SLOTS, string BOOKING_NO, string SLOT_OPERATOR)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "VALIDATE_SLOTS" },
              new SqlParameter("@SRR_NO", SqlDbType.VarChar,50) { Value = SRR_NO },
              new SqlParameter("@NO_OF_SLOTS", SqlDbType.Int) { Value = NO_OF_SLOTS },
              new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
              new SqlParameter("@SLOT_OPERATOR", SqlDbType.VarChar,100) { Value = SLOT_OPERATOR },
            };

            string validateSlot = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_BOOKING", parameters);
           
            return validateSlot;
        }

        public void InsertVoyage(string connstring, VOYAGE request)

        {
            SqlParameter[] parameters =
           {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_VOYAGE" },
              new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar,255) { Value = request.VESSEL_NAME },
              new SqlParameter("@VOYAGE_NO", SqlDbType.VarChar,50) { Value = request.VOYAGE_NO },
              new SqlParameter("@ATA", SqlDbType.DateTime) { Value = request.ATA },
              new SqlParameter("@ATD", SqlDbType.DateTime) { Value = request.ATD },
              new SqlParameter("@ETA", SqlDbType.DateTime) { Value = request.ETA },
              new SqlParameter("@ETD", SqlDbType.DateTime) { Value = request.ETD },
              new SqlParameter("@TERMINAL_CODE", SqlDbType.VarChar,100) { Value = request.TERMINAL_CODE },
              new SqlParameter("@SERVICE_NAME", SqlDbType.VarChar,255) { Value = request.SERVICE_NAME },
              new SqlParameter("@VIA_NO", SqlDbType.VarChar,100) { Value = request.VIA_NO },
              new SqlParameter("@PORT_CODE", SqlDbType.VarChar,100) { Value = request.PORT_CODE },
              new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = request.CREATED_BY },
            };

            SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_BOOKING", parameters);
        }

        public string GetTrackingDetail(string connstring, string BOOKING_NO)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_TRACKING_DETAILS" },
                new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
            };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_BOOKING", parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<ROLLOVER> GetRolloverList(string connstring, string AGENT_CODE)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,100) { Value = "GET_ROLLOVER_LIST" },
              
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,50) { Value = AGENT_CODE},
             

            };

            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_BOOKING", parameters);
            List<ROLLOVER> rollOverList = SqlHelper.CreateListFromTable<ROLLOVER>(dataTable);

            return rollOverList;
        }

    }
}
