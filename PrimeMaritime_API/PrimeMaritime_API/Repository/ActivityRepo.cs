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
    public class ActivityRepo
    {
        public List<ACTIVITY> GetActivityList(string connstring)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_ACTIVITY_LIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_ACTIVITY", parameters);
                List<ACTIVITY> activityList = SqlHelper.CreateListFromTable<ACTIVITY>(dataTable);

                return activityList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
