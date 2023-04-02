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
    public class CommonRepo
    {
        public List<DROPDOWN> GetDropdownData(string connstring, string key, string port, string value, int value1, string value2)
        {
            SqlParameter[] parameters =
           {
                new SqlParameter("@KEY", SqlDbType.VarChar, 100) { Value = key },
                new SqlParameter("@PORT_CODE", SqlDbType.VarChar, 100) { Value = port },
                new SqlParameter("@VALUE", SqlDbType.VarChar, 250) { Value = value },
                new SqlParameter("@VALUE1", SqlDbType.Int) { Value = value1 },
                new SqlParameter("@VALUE2", SqlDbType.VarChar, 250) { Value = value2 },
            };

            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_GET_MASTER_DATA", parameters);
            List<DROPDOWN> dropdownList = SqlHelper.CreateListFromTable<DROPDOWN>(dataTable);

            return dropdownList;
        }

        public string CheckRandomNo(string connstring, string RANDOM_NO)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@RANDOM_NO", SqlDbType.VarChar, 100) { Value = RANDOM_NO },
            };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CHECK_RANDOM_NUMBER", parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
