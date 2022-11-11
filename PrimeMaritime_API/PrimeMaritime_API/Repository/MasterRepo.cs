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
    public class MasterRepo
    {
       
        public void InsertMaster(string connstring, MASTER master)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_CUSTOMER" },
              new SqlParameter("@CUST_NAME", SqlDbType.VarChar,50) { Value = master.CUST_NAME},
              new SqlParameter("@CUST_ADDRESS", SqlDbType.VarChar, 100) { Value = master.CUST_ADDRESS },
              new SqlParameter("@CUST_EMAIL", SqlDbType.VarChar, 50) { Value = master.CUST_EMAIL },
              new SqlParameter("@CUST_CONTACT", SqlDbType.VarChar, 20) { Value = master.CUST_CONTACT },
              new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,10) { Value = master.CUST_TYPE },
              new SqlParameter("@GSTIN", SqlDbType.VarChar,15) { Value = master.GSTIN },
              new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
              new SqlParameter("@REMARKS", SqlDbType.VarChar, 200) { Value = master.REMARKS },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 100) { Value = master.AGENT_CODE },
              new SqlParameter("@CREATED_BY", SqlDbType.Int) { Value = master.CREATED_BY },
            };

            var ID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_CUSTOMER", parameters);


        }
        public List<MASTER> GetMasterList(string dbConn, string AgentCode)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CUSTOMER" },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AgentCode },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_MST_CUSTOMER", parameters);
                List<MASTER> master = SqlHelper.CreateListFromTable<MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
