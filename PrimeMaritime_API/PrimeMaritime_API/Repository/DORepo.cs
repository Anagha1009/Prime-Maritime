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
    public class DORepo
    {
        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }

        public void InsertDO(string connstring, DO request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "CREATE_DO" },
                  new SqlParameter("@BL_ID", SqlDbType.Int) { Value = request.BL_ID },
                  new SqlParameter("@BL_NO", SqlDbType.VarChar,100) { Value = request.BL_NO },
                   new SqlParameter("@DO_NO", SqlDbType.VarChar,100) { Value = request.DO_NO },
                  new SqlParameter("@DO_DATE", SqlDbType.DateTime) { Value = request.DO_DATE },
                  new SqlParameter("@ARRIVAL_DATE", SqlDbType.DateTime) { Value = request.ARRIVAL_DATE },
                  new SqlParameter("@DO_VALIDITY", SqlDbType.DateTime) { Value = request.DO_VALIDITY },
                 new SqlParameter("@IGM_NO", SqlDbType.VarChar, 50) { Value = request.IGM_NO },
                  new SqlParameter("@IGM_ITEM_NO", SqlDbType.VarChar, 50) { Value = request.IGM_ITEM_NO },
                  new SqlParameter("@IGM_DATE", SqlDbType.DateTime) { Value = request.IGM_DATE },
                  new SqlParameter("@CLEARING_PARTY", SqlDbType.VarChar,100) { Value = request.CLEARING_PARTY },
                  new SqlParameter("@ACCEPTANCE_LOCATION", SqlDbType.VarChar, 100) { Value = request.ACCEPTANCE_LOCATION },
                  new SqlParameter("@LETTER_VALIDITY",SqlDbType.DateTime) { Value = request.LETTER_VALIDITY },
                  new SqlParameter("@SHIPPING_TERMS", SqlDbType.VarChar, 50) { Value = request.SHIPPING_TERMS },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY }

                };

                //SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_DO", parameters);

                var DONO = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_DO", parameters);

                foreach (var i in request.CONTAINER_LIST2)
                {
                    i.DO_NO = request.DO_NO;
                }

                string[] columns = new string[13];
                columns[0] = "BL_NO";
                columns[1] = "DO_NO";
                columns[2] = "CONTAINER_NO";
                columns[3] = "CONTAINER_TYPE";
                columns[4] = "CONTAINER_SIZE";
                columns[5] = "SEAL_NO";
                columns[6] = "MARKS_NOS";
                columns[7] = "DESC_OF_GOODS";
                columns[8] = "GROSS_WEIGHT";
                columns[9] = "MEASUREMENT";
                columns[10] = "AGENT_CODE";
                columns[11] = "AGENT_NAME";
                columns[12] = "CREATED_BY";

                SqlHelper.UpdateData<CONTAINERS>(request.CONTAINER_LIST2, "TB_CONTAINER", connstring, columns);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DO> GetDOList(string connstring, string OPERATION, string DO_NO, string DO_DATE, string DO_VALIDITY, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DOLIST" },
                  new SqlParameter("@DO_NO", SqlDbType.VarChar, 100) { Value = DO_NO },
                  new SqlParameter("@DO_DATE", SqlDbType.DateTime) { Value = DO_DATE },
                  new SqlParameter("@DO_VALIDITY", SqlDbType.DateTime) { Value = DO_VALIDITY },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_DO", parameters);
                List<DO> doList = SqlHelper.CreateListFromTable<DO>(dataTable);

                return doList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DO GetDODetails(string connstring, string DO_NO, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DO_DETAILS" },
                new SqlParameter("@DO_NO", SqlDbType.VarChar, 100) { Value = DO_NO },
                new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
            };

                return SqlHelper.ExtecuteProcedureReturnData<DO>(connstring, "SP_CRUD_DO", r => r.TranslateDO(), parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
