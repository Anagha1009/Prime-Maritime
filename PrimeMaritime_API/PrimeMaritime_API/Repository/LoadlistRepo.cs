using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class LoadlistRepo
    {
        public List<LOAD_LIST> GetLoadList(string dbConn,string VESSEL_NAME,string VOYAGE_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_LOAD_LIST" },
                   new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar, 255) { Value =VESSEL_NAME},
                   new SqlParameter("@VOYAGE_NO ", SqlDbType.VarChar, 50) { Value =VOYAGE_NO},
                   
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_LOAD_LIST", parameters);
                List<LOAD_LIST> master = SqlHelper.CreateListFromTable<LOAD_LIST>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
