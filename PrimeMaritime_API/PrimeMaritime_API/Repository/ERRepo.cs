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
    public class ERRepo
    {
        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }

        public void InsertER(string connstring, EMPTY_REPO request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "CREATE_EMPTY_REPO" },
                  new SqlParameter("@REPO_NO", SqlDbType.VarChar,100) { Value = request.REPO_NO },
                  new SqlParameter("@LOAD_DEPOT", SqlDbType.VarChar,100) { Value = request.LOAD_DEPOT },
                  new SqlParameter("@DISCHARGE_DEPOT", SqlDbType.VarChar,100) { Value = request.DISCHARGE_DEPOT },
                  new SqlParameter("@MOVEMENT_DATE", SqlDbType.DateTime) { Value = request.MOVEMENT_DATE },
                  new SqlParameter("@LIFT_ON_CHARGE", SqlDbType.DateTime) { Value = request.LIFT_ON_CHARGE },
                  new SqlParameter("@LIFT_OFF_CHARGE", SqlDbType.DateTime) { Value = request.LIFT_OFF_CHARGE },
                  new SqlParameter("@CURRENCY", SqlDbType.VarChar, 50) { Value = request.CURRENCY },
                  new SqlParameter("@NO_OF_CONTAINER", SqlDbType.VarChar, 50) { Value = request.NO_OF_CONTAINER },
                  new SqlParameter("@REASON", SqlDbType.DateTime) { Value = request.REASON },
                  new SqlParameter("@REMARKS", SqlDbType.VarChar,100) { Value = request.REMARKS },
                  new SqlParameter("@STATUS", SqlDbType.VarChar, 100) { Value = request.STATUS },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY }

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_EMPTY_REPO", parameters);

                var DONO = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_EMPTY_REPO", parameters);

                foreach (var i in request.CONTAINER_LIST)
                {
                    i.REPO_NO = request.REPO_NO;
                }

                string[] columns = new string[12];
                columns[0] = "BL_NO";
                columns[1] = "DO_NO";
                columns[2] = "REPO_NO";
                columns[3] = "CONTAINER_NO";
                columns[4] = "CONTAINER_TYPE";
                columns[5] = "CONTAINER_SIZE";
                columns[6] = "SEAL_NO";
                columns[7] = "MARKS_NOS";
                columns[8] = "DESC_OF_GOODS";
                columns[9] = "GROSS_WEIGHT";
                columns[10] = "MEASUREMENT";
                columns[11] = "AGENT_CODE";
                columns[12] = "AGENT_NAME";
                columns[13] = "CREATED_BY";

                SqlHelper.UpdateData<CONTAINERS>(request.CONTAINER_LIST, "TB_CONTAINER", connstring, columns);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EMPTY_REPO> GetERList(string connstring, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_EMPTY_REPO_LIST" },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_EMPTY_REPO", parameters);
                List<EMPTY_REPO> emptyRepoList = SqlHelper.CreateListFromTable<EMPTY_REPO>(dataTable);

                return emptyRepoList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EMPTY_REPO GetERDetails(string connstring, string REPO_NO, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_EMPTY_REPO_DETAILS" },
                new SqlParameter("@REPO_NO", SqlDbType.VarChar, 100) { Value = REPO_NO },
                new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
            };

                return SqlHelper.ExtecuteProcedureReturnData<EMPTY_REPO>(connstring, "SP_CRUD_EMPTY_REPO", r => r.TranslateER(), parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
