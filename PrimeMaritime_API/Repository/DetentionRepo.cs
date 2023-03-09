using IdentityModel.Client;
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
    public class DetentionRepo
    {


        public List<DETENTION_WAIVER_REQUEST> GetDetentionList(string dbConn, string DO_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_DETENTION_WAIVER_BY_DO_NO" },
                   new SqlParameter("@DO_NO", SqlDbType.VarChar,100) { Value = DO_NO},
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_DETENTION", parameters);
                List<DETENTION_WAIVER_REQUEST> detention_Request = SqlHelper.CreateListFromTable<DETENTION_WAIVER_REQUEST>(dataTable);

                return detention_Request;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void InsertDetention(string connstr, DETENTION request)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("DO_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("LOCATION", typeof(string)));
                tbl.Columns.Add(new DataColumn("IMPORTER", typeof(string)));
                tbl.Columns.Add(new DataColumn("CLEARING_PARTY", typeof(string)));
                tbl.Columns.Add(new DataColumn("DETENTION_DAYS", typeof(int)));
                tbl.Columns.Add(new DataColumn("DETENTION_RATE", typeof(decimal)));
                tbl.Columns.Add(new DataColumn("CURRENCY", typeof(string)));
                tbl.Columns.Add(new DataColumn("REMARKS", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.DETENTION_LIST)
                {
                    DataRow dr = tbl.NewRow();

                    dr["DO_NO"] = request.DO_NO;
                    dr["CONTAINER_NO"] = i.CONTAINER_NO;
                    dr["LOCATION"] = i.PORT_OF_DISCHARGE;
                    dr["IMPORTER"] = i.CONSIGNEE;
                    dr["CLEARING_PARTY"] = i.CLEARING_PARTY;
                    dr["DETENTION_DAYS"] = i.DETENTION_DAYS;
                    dr["DETENTION_RATE"] = i.DETENTION_RATE;
                    dr["CURRENCY"] = i.CURRENCY;
                    dr["REMARKS"] = i.REMARK;
                    dr["CREATED_BY"] = i.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[10];
                columns[0] = "DO_NO";
                columns[1] = "CONTAINER_NO";
                columns[2] = "LOCATION";
                columns[3] = "IMPORTER";
                columns[4] = "CLEARING_PARTY";
                columns[5] = "DETENTION_DAYS";
                columns[6] = "DETENTION_RATE";
                columns[7] = "CURRENCY";
                columns[8] = "REMARKS";
                columns[9] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstr, tbl, "TB_DETENTION", columns);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetTotalDetentionCost(string connstring, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "DETENTION_CALCULATION" },
                new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 100) { Value = CONTAINER_NO },
            };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_DETENTION", parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<CONTAINER_DETENTION> GetContainerDetentionList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CONTAINER_DETENTION_CALCULATION" },
                   
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_DETENTION", parameters);
                List<CONTAINER_DETENTION> detention_Request = SqlHelper.CreateListFromTable<CONTAINER_DETENTION>(dataTable);

                return detention_Request;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}

