using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class CRORepo
    {
        public void InsertCRO(string connstring, CRORequest request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "CREATE_CRO" },
                  new SqlParameter("@CRO_NO", SqlDbType.VarChar,100) { Value = request.CRO_NO },
                  new SqlParameter("@BOOKING_ID", SqlDbType.Int) { Value = request.BOOKING_ID },
                  new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = request.BOOKING_NO },
                  new SqlParameter("@STUFFING_TYPE", SqlDbType.VarChar, 100) { Value = request.STUFFING_TYPE },
                  new SqlParameter("@EMPTY_CONT_PCKP", SqlDbType.VarChar, 255) { Value = request.EMPTY_CONT_PCKP },
                  new SqlParameter("@LADEN_ACPT_LOCATION", SqlDbType.VarChar, 255) { Value = request.LADEN_ACPT_LOCATION },
                  new SqlParameter("@CRO_VALIDITY_DATE", SqlDbType.DateTime) { Value = request.CRO_VALIDITY_DATE },
                  new SqlParameter("@REMARKS", SqlDbType.VarChar, 255) { Value = request.REMARKS },
                  new SqlParameter("@REQ_QUANTITY", SqlDbType.Int) { Value = request.REQ_QUANTITY },
                  new SqlParameter("@GROSS_WT", SqlDbType.Decimal) { Value = request.GROSS_WT },
                  new SqlParameter("@GROSS_WT_UNIT", SqlDbType.VarChar, 20) { Value = request.GROSS_WT_UNIT },
                  new SqlParameter("@PACKAGES", SqlDbType.VarChar, 100) { Value = request.PACKAGES },
                  new SqlParameter("@NO_OF_PACKAGES", SqlDbType.Int) { Value = request.NO_OF_PACKAGES },
                  new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = request.STATUS },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 250) { Value = request.CREATED_BY }

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CRO", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CROResponse> GetCROList(string connstring, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CROLIST" },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_CRO", parameters);
                List<CROResponse> cROResponses = SqlHelper.CreateListFromTable<CROResponse>(dataTable);

                return cROResponses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetCRODetails(string connstring, string CRO_NO, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
 {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CRO_DETAILS" },
                new SqlParameter("@CRO_NO", SqlDbType.VarChar, 100) { Value = CRO_NO },
                new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
            };

               return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_CRO", parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }
    }
}
