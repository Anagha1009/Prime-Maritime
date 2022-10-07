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
        public void InsertSlots(string connstring, BookingRequest request)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CREATE_SLOT" },
              new SqlParameter("@SRR_ID", SqlDbType.Int) { Value = request.SRR_ID },
              new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = request.SRR_NO },
              new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar, 255) { Value = request.VESSEL_NAME },
              new SqlParameter("@VOYAGE_NO", SqlDbType.VarChar, 50) { Value = request.VOYAGE_NO },
              new SqlParameter("@MOTHER_VESSEL_NAME", SqlDbType.VarChar, 255) { Value = request.MOTHER_VESSEL_NAME },
              new SqlParameter("@MOTHER_VOYAGE_NO", SqlDbType.VarChar, 50) { Value = request.MOTHER_VOYAGE_NO },
              new SqlParameter("@SLOT_OPERATOR", SqlDbType.VarChar, 100) { Value = request.SLOT_OPERATOR },
              new SqlParameter("@NO_OF_SLOTS", SqlDbType.Int) { Value = request.NO_OF_SLOTS },
              new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = request.POL },
              new SqlParameter("@POD", SqlDbType.VarChar, 100) { Value = request.POD },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
              new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
              new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY },
            };

            SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SRR", parameters);          
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
