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
                  new SqlParameter("@LIFT_ON_CHARGE", SqlDbType.Decimal) { Value = request.LIFT_ON_CHARGE },
                  new SqlParameter("@LIFT_OFF_CHARGE", SqlDbType.Decimal) { Value = request.LIFT_OFF_CHARGE },
                  new SqlParameter("@CURRENCY", SqlDbType.VarChar, 50) { Value = request.CURRENCY },
                  new SqlParameter("@NO_OF_CONTAINER", SqlDbType.Int) { Value = request.NO_OF_CONTAINER },
                  new SqlParameter("@MODE_OF_TRANSPORT", SqlDbType.VarChar,50) { Value = request.MODE_OF_TRANSPORT },
                  new SqlParameter("@REASON", SqlDbType.VarChar, 255) { Value = request.REASON },
                  new SqlParameter("@REMARKS", SqlDbType.VarChar, 255) { Value = request.REMARKS },
                  new SqlParameter("@STATUS", SqlDbType.Int) { Value = request.STATUS },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY }

                };

                var repoNO = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_EMPTY_REPO", parameters);

                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("REPO_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_TYPE", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_SIZE", typeof(string)));
                tbl.Columns.Add(new DataColumn("SEAL_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("MARKS_NOS", typeof(string)));
                tbl.Columns.Add(new DataColumn("DESC_OF_GOODS", typeof(string)));
                tbl.Columns.Add(new DataColumn("GROSS_WEIGHT", typeof(decimal)));
                tbl.Columns.Add(new DataColumn("MEASUREMENT", typeof(string)));
                tbl.Columns.Add(new DataColumn("AGENT_CODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("AGENT_NAME", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.CONTAINER_LIST)
                {
                    DataRow dr = tbl.NewRow();

                    dr["REPO_NO"] = request.REPO_NO;
                    dr["CONTAINER_NO"] = i.CONTAINER_NO;
                    dr["CONTAINER_TYPE"] = i.CONTAINER_TYPE;
                    dr["CONTAINER_SIZE"] = i.CONTAINER_SIZE;
                    dr["SEAL_NO"] = i.SEAL_NO;
                    dr["MARKS_NOS"] = i.MARKS_NOS;
                    dr["DESC_OF_GOODS"] = i.DESC_OF_GOODS;
                    dr["GROSS_WEIGHT"] = i.GROSS_WEIGHT;
                    dr["MEASUREMENT"] = i.MEASUREMENT;
                    dr["AGENT_CODE"] = i.AGENT_CODE;
                    dr["AGENT_NAME"] = i.AGENT_NAME;
                    dr["CREATED_BY"] = request.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[12];
                columns[0] = "REPO_NO";
                columns[1] = "CONTAINER_NO";
                columns[2] = "CONTAINER_TYPE";
                columns[3] = "CONTAINER_SIZE";
                columns[4] = "SEAL_NO";
                columns[5] = "MARKS_NOS";
                columns[6] = "DESC_OF_GOODS";
                columns[7] = "GROSS_WEIGHT";
                columns[8] = "MEASUREMENT";
                columns[9] = "AGENT_CODE";
                columns[10] = "AGENT_NAME";
                columns[11] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_ER_CONTAINER", columns);

                //foreach (var i in request.CONTAINER_LIST)
                //{
                //    i.REPO_NO = request.REPO_NO;
                //}

                //string[] columns = new string[12];
                //columns[0] = "REPO_NO";
                //columns[1] = "CONTAINER_NO";
                //columns[2] = "CONTAINER_TYPE";
                //columns[3] = "CONTAINER_SIZE";
                //columns[4] = "SEAL_NO";
                //columns[5] = "MARKS_NOS";
                //columns[6] = "DESC_OF_GOODS";
                //columns[7] = "GROSS_WEIGHT";
                //columns[8] = "MEASUREMENT";
                //columns[9] = "AGENT_CODE";
                //columns[10] = "AGENT_NAME";
                //columns[11] = "CREATED_BY";

                //SqlHelper.UpdateData<ER_CONTAINER>(request.CONTAINER_LIST, "TB_ER_CONTAINER", connstring, columns);
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
