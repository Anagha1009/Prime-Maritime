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
                  new SqlParameter("@BL_NO", SqlDbType.VarChar,100) { Value = request.BL_NO },
                  new SqlParameter("@DO_NO", SqlDbType.VarChar,100) { Value = request.DO_NO },
                  new SqlParameter("@ARRIVAL_DATE", SqlDbType.DateTime) { Value = request.ARRIVAL_DATE },
                  new SqlParameter("@IGM_NO", SqlDbType.VarChar, 50) { Value = request.IGM_NO },
                  new SqlParameter("@IGM_ITEM_NO", SqlDbType.VarChar, 50) { Value = request.IGM_ITEM_NO },
                  new SqlParameter("@CLEARING_PARTY", SqlDbType.VarChar,100) { Value = request.CLEARING_PARTY },
                  new SqlParameter("@ACCEPTANCE_LOCATION", SqlDbType.VarChar, 100) { Value = request.ACCEPTANCE_LOCATION },
                  new SqlParameter("@LETTER_VALIDITY",SqlDbType.DateTime) { Value = request.LETTER_VALIDITY },
                  new SqlParameter("@SHIPPING_TERMS", SqlDbType.VarChar, 50) { Value = request.SHIPPING_TERMS },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY },
                  new SqlParameter("@IGM_DATE", SqlDbType.DateTime) { Value = request.IGM_DATE }
                };

                var DONO = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_DO", parameters);

                if (!String.IsNullOrEmpty(DONO))
                {
                    foreach (var i in request.CONTAINER_LIST)
                    {
                        i.DO_NO = request.DO_NO;
                    }

                    string[] columns = new string[3];
                    columns[0] = "BL_NO";
                    columns[1] = "DO_NO";
                    columns[2] = "CONTAINER_NO";

                    SqlHelper.UpdateDataDO<CONTAINERS>(request.CONTAINER_LIST, "TB_CONTAINER", connstring, columns);
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DO> GetDOList(string connstring, string DO_NO, string FROM_DATE, string TO_DATE, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DOLIST" },
                  new SqlParameter("@DO_NO", SqlDbType.VarChar, 100) { Value = DO_NO },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },
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
        public List<DO> GetDOListPM(string connstring, string DO_NO, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DOLIST_PM" },
                  new SqlParameter("@DO_NO", SqlDbType.VarChar, 100) { Value = DO_NO },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },
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
