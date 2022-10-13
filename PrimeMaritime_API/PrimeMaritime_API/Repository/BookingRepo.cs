using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
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
        //public void InsertSlots(string connstring, SLOT_DETAILS request)
        //{
        //    SqlParameter[] parameters =
        //    {
        //      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CREATE_SLOT" },
        //      new SqlParameter("@SRR_ID", SqlDbType.Int) { Value = request.SRR_ID },
        //      new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = request.SRR_NO },
        //      new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar, 255) { Value = request.VESSEL_NAME },
        //      new SqlParameter("@VOYAGE_NO", SqlDbType.VarChar, 50) { Value = request.VOYAGE_NO },
        //      new SqlParameter("@MOTHER_VESSEL_NAME", SqlDbType.VarChar, 255) { Value = request.MOTHER_VESSEL_NAME },
        //      new SqlParameter("@MOTHER_VOYAGE_NO", SqlDbType.VarChar, 50) { Value = request.MOTHER_VOYAGE_NO },
        //      new SqlParameter("@SLOT_OPERATOR", SqlDbType.VarChar, 100) { Value = request.SLOT_OPERATOR },
        //      new SqlParameter("@NO_OF_SLOTS", SqlDbType.Int) { Value = request.NO_OF_SLOTS },
        //      new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = request.POL },
        //      new SqlParameter("@POD", SqlDbType.VarChar, 100) { Value = request.POD },
        //      new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
        //      new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
        //      new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY },
        //    };

        //    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SRR", parameters);          
        //}

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
            };

            var BOOKINGID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_BOOKING", parameters);

            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("BOOKING_ID", typeof(int)));
            tbl.Columns.Add(new DataColumn("BOOKING_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("SLOT_OPERATOR", typeof(string)));
            tbl.Columns.Add(new DataColumn("NO_OF_SLOTS", typeof(string)));
            tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

            foreach (var i in request.SLOT_LIST)
            {
                DataRow dr = tbl.NewRow();

                dr["BOOKING_ID"] = Convert.ToInt32(BOOKINGID);
                dr["BOOKING_NO"] = request.BOOKING_NO;
                dr["SLOT_OPERATOR"] = i.SLOT_OPERATOR;
                dr["NO_OF_SLOTS"] = i.NO_OF_SLOTS;
                dr["CREATED_BY"] = request.CREATED_BY;

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[5];
            columns[0] = "BOOKING_ID";
            columns[1] = "BOOKING_NO";
            columns[2] = "SLOT_OPERATOR";
            columns[3] = "NO_OF_SLOTS";
            columns[4] = "CREATED_BY";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_SLOT_DETAILS", columns);
        }

        public List<SLOT_DETAILS> GetSlotList(string connstring, string AGENT_CODE, string SRR_NO)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_SLOTLIST" },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,50) { Value = AGENT_CODE },
              new SqlParameter("@SRR_NO", SqlDbType.VarChar,50) { Value = SRR_NO },
            };

            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_SRR", parameters);
            List<SLOT_DETAILS> bookingList = SqlHelper.CreateListFromTable<SLOT_DETAILS>(dataTable);

            return bookingList;
        }
    }
}
