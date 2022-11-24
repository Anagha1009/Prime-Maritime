using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Translators;
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

        public ACTIVITY GetActivityDetailsByCode(string connstring, string ACT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_ACTIVITY_LIST_BY_ACT_CODE" },
                new SqlParameter("@ACT_CODE", SqlDbType.VarChar, 50) { Value = ACT_CODE },
            };

                return SqlHelper.ExtecuteProcedureReturnData<ACTIVITY>(connstring, "SP_CRUD_ACTIVITY", r => r.TranslateActivity(), parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataSet GetActivityMappingDetailsByID(string connstring, int ACT_ID)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_ACTIVITY_MAPPING_LIST_BY_ACT_ID" },
                new SqlParameter("@ACT_ID", SqlDbType.Int) { Value = ACT_ID },
            };

                return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_ACTIVITY", parameters);
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
