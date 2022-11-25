using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class SRRRepo
    {
        public DataSet GetSRRData(string connstring, string SRR_NO, string AGENT_CODE)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_SRRDETAILS" },
                new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = SRR_NO },
                new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
            };

            return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_SRR", parameters);
        }

        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }

        public List<SRRList> GetSRRList(string connstring, string OPERATION, string SRR_NO, string CUSTOMER_NAME, string STATUS, string FROMDATE, string TODATE, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = OPERATION },
                  new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = SRR_NO },
                  new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar, 255) { Value = CUSTOMER_NAME },
                  new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = STATUS },
                  new SqlParameter("@FROMDATE", SqlDbType.DateTime) { Value = String.IsNullOrEmpty(FROMDATE) ? null : Convert.ToDateTime(FROMDATE) },
                  new SqlParameter("@TODATE", SqlDbType.DateTime) { Value = String.IsNullOrEmpty(TODATE) ? null : Convert.ToDateTime(TODATE) },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
                };                

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_SRR", parameters);
                List<SRRList> srrList = SqlHelper.CreateListFromTable<SRRList>(dataTable);

                return srrList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertSRR(string connstring, SRRRequest request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "CREATE_SRR" },
                  new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = request.SRR_NO },
                  new SqlParameter("@POL", SqlDbType.VarChar, 255) { Value = request.POL },
                  new SqlParameter("@POD", SqlDbType.VarChar, 255) { Value = request.POD },
                  new SqlParameter("@FINAL_DESTINATION", SqlDbType.VarChar, 255) { Value = request.FINAL_DESTINATION },
                  new SqlParameter("@SERVICE_NAME", SqlDbType.VarChar, 255) { Value = request.SERVICE_NAME },
                  new SqlParameter("@EFFECT_FROM", SqlDbType.DateTime) { Value = request.EFFECT_FROM },
                  new SqlParameter("@EFFECT_TO", SqlDbType.DateTime) { Value = request.EFFECT_TO },
                  new SqlParameter("@MTY_REPO", SqlDbType.Bit) { Value = request.MTY_REPO },
                  new SqlParameter("@CUSTOMER_NAME", SqlDbType.VarChar, 255) { Value = request.CUSTOMER_NAME },
                  new SqlParameter("@ADDRESS", SqlDbType.VarChar, 255) { Value = request.ADDRESS },
                  new SqlParameter("@EMAIL", SqlDbType.VarChar, 255) { Value = request.EMAIL },
                  new SqlParameter("@CONTACT", SqlDbType.VarChar, 20) { Value = request.CONTACT },
                  new SqlParameter("@SHIPPER", SqlDbType.VarChar, 250) { Value = request.SHIPPER },
                  new SqlParameter("@NOTIFY_PARTY", SqlDbType.VarChar, 250) { Value = request.NOTIFY_PARTY },
                  new SqlParameter("@OTHER_PARTY", SqlDbType.VarChar, 20) { Value = request.OTHER_PARTY },
                  new SqlParameter("@OTHER_PARTY_NAME", SqlDbType.VarChar, 255) { Value = request.OTHER_PARTY_NAME },
                  new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = request.STATUS },
                  new SqlParameter("@PLACE_OF_RECEIPT", SqlDbType.VarChar, 100) { Value = request.PLACE_OF_RECEIPT },
                  new SqlParameter("@PLACE_OF_DELIVERY", SqlDbType.VarChar, 100) { Value = request.PLACE_OF_DELIVERY },
                  new SqlParameter("@TSP_1", SqlDbType.VarChar, 100) { Value = request.TSP_1 },
                  new SqlParameter("@TSP_2", SqlDbType.VarChar, 100) { Value = request.TSP_2 },                  
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request.CREATED_BY },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@AGENT_NAME", SqlDbType.VarChar, 255) { Value = request.AGENT_NAME }
                };

                var SRRID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SRR", parameters);

                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("SRR_ID", typeof(int)));
                tbl.Columns.Add(new DataColumn("SRR_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_TYPE", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_SIZE", typeof(string)));
                tbl.Columns.Add(new DataColumn("SERVICE_MODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("POD_FREE_DAYS", typeof(string)));
                tbl.Columns.Add(new DataColumn("POL_FREE_DAYS", typeof(string)));
                tbl.Columns.Add(new DataColumn("IMM_VOLUME_EXPECTED", typeof(string)));
                tbl.Columns.Add(new DataColumn("TOTAL_VOLUME_EXPECTED", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.SRR_CONTAINERS)
                {
                    DataRow dr = tbl.NewRow();

                    dr["SRR_ID"] = Convert.ToInt32(SRRID);
                    dr["SRR_NO"] = request.SRR_NO;
                    dr["CONTAINER_TYPE"] = i.CONTAINER_TYPE;
                    dr["CONTAINER_SIZE"] = i.CONTAINER_SIZE;
                    dr["SERVICE_MODE"] = i.SERVICE_MODE;
                    dr["POD_FREE_DAYS"] = i.POD_FREE_DAYS;
                    dr["POL_FREE_DAYS"] = i.POL_FREE_DAYS;
                    dr["IMM_VOLUME_EXPECTED"] = i.IMM_VOLUME_EXPECTED;
                    dr["TOTAL_VOLUME_EXPECTED"] = i.TOTAL_VOLUME_EXPECTED;
                    dr["CREATED_BY"] = request.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[10];
                columns[0] = "SRR_ID";
                columns[1] = "SRR_NO";
                columns[2] = "CONTAINER_TYPE";
                columns[3] = "CONTAINER_SIZE";
                columns[4] = "SERVICE_MODE";
                columns[5] = "POD_FREE_DAYS";
                columns[6] = "POL_FREE_DAYS";
                columns[7] = "IMM_VOLUME_EXPECTED";
                columns[8] = "TOTAL_VOLUME_EXPECTED";
                columns[9] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_SRR_CONTAINERS", columns);

                DataTable tbl1 = new DataTable();
                tbl1.Columns.Add(new DataColumn("SRR_ID", typeof(int)));
                tbl1.Columns.Add(new DataColumn("SRR_NO", typeof(string)));
                tbl1.Columns.Add(new DataColumn("CONTAINER_TYPE", typeof(string)));
                tbl1.Columns.Add(new DataColumn("CHARGE_CODE", typeof(string)));
                tbl1.Columns.Add(new DataColumn("TRANSPORT_TYPE", typeof(string)));
                tbl1.Columns.Add(new DataColumn("CURRENCY", typeof(string)));
                tbl1.Columns.Add(new DataColumn("PAYMENT_TERM", typeof(string)));
                tbl1.Columns.Add(new DataColumn("STANDARD_RATE", typeof(decimal)));
                tbl1.Columns.Add(new DataColumn("RATE_REQUESTED", typeof(decimal)));
                tbl1.Columns.Add(new DataColumn("REMARKS", typeof(string)));
                tbl1.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.SRR_RATES)
                {
                    DataRow dr = tbl1.NewRow();

                    dr["SRR_ID"] = Convert.ToInt32(SRRID);
                    dr["SRR_NO"] = request.SRR_NO;
                    dr["CONTAINER_TYPE"] = i.CONTAINER_TYPE;
                    dr["CHARGE_CODE"] = i.CHARGE_CODE;
                    dr["TRANSPORT_TYPE"] = i.TRANSPORT_TYPE;
                    dr["CURRENCY"] = i.CURRENCY;
                    dr["PAYMENT_TERM"] = i.PAYMENT_TERM;
                    dr["STANDARD_RATE"] = i.STANDARD_RATE;
                    dr["RATE_REQUESTED"] = i.RATE_REQUESTED;
                    dr["REMARKS"] = i.REMARKS;
                    dr["CREATED_BY"] = request.CREATED_BY;

                    tbl1.Rows.Add(dr);
                }

                string[] columns1 = new string[11];
                columns1[0] = "SRR_ID";
                columns1[1] = "SRR_NO";
                columns1[2] = "CONTAINER_TYPE";
                columns1[3] = "CHARGE_CODE";
                columns1[4] = "TRANSPORT_TYPE";
                columns1[5] = "CURRENCY";
                columns1[6] = "PAYMENT_TERM";
                columns1[7] = "STANDARD_RATE";
                columns1[8] = "RATE_REQUESTED";
                columns1[9] = "REMARKS";
                columns1[10] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl1, "TB_SRR_RATES", columns1);

                DataTable tbl2 = new DataTable();
                tbl2.Columns.Add(new DataColumn("SRR_ID", typeof(int)));
                tbl2.Columns.Add(new DataColumn("SRR_NO", typeof(string)));
                tbl2.Columns.Add(new DataColumn("COMMODITY_NAME", typeof(string)));
                tbl2.Columns.Add(new DataColumn("LENGTH", typeof(decimal)));
                tbl2.Columns.Add(new DataColumn("WIDTH", typeof(decimal)));
                tbl2.Columns.Add(new DataColumn("HEIGHT", typeof(decimal)));
                tbl2.Columns.Add(new DataColumn("WEIGHT", typeof(decimal)));
                tbl2.Columns.Add(new DataColumn("COMMODITY_TYPE", typeof(string)));
                tbl2.Columns.Add(new DataColumn("IMO_CLASS", typeof(string)));
                tbl2.Columns.Add(new DataColumn("UN_NO", typeof(string)));
                tbl2.Columns.Add(new DataColumn("HAZ_APPROVAL_REF", typeof(string)));
                tbl2.Columns.Add(new DataColumn("FLASH_POINT", typeof(string)));
                tbl2.Columns.Add(new DataColumn("CAS_NO", typeof(string)));
                tbl2.Columns.Add(new DataColumn("REMARKS", typeof(string)));
                tbl2.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.SRR_COMMODITIES)
                {
                    DataRow dr = tbl2.NewRow();

                    dr["SRR_ID"] = Convert.ToInt32(SRRID);
                    dr["SRR_NO"] = request.SRR_NO;
                    dr["COMMODITY_NAME"] = i.COMMODITY_NAME;
                    dr["LENGTH"] = i.LENGTH;
                    dr["WIDTH"] = i.WIDTH;
                    dr["HEIGHT"] = i.HEIGHT;
                    dr["WEIGHT"] = i.WEIGHT;
                    dr["COMMODITY_TYPE"] = i.COMMODITY_TYPE;
                    dr["IMO_CLASS"] = i.IMO_CLASS;
                    dr["UN_NO"] = i.UN_NO;
                    dr["HAZ_APPROVAL_REF"] = i.HAZ_APPROVAL_REF;
                    dr["FLASH_POINT"] = i.FLASH_POINT;
                    dr["CAS_NO"] = i.CAS_NO;
                    dr["REMARKS"] = i.REMARKS;
                    dr["CREATED_BY"] = request.CREATED_BY;

                    tbl2.Rows.Add(dr);
                }

                string[] columns2 = new string[15];
                columns2[0] = "SRR_ID";
                columns2[1] = "SRR_NO";
                columns2[2] = "COMMODITY_NAME";
                columns2[3] = "LENGTH";
                columns2[4] = "WIDTH";
                columns2[5] = "HEIGHT";
                columns2[6] = "WEIGHT";
                columns2[7] = "COMMODITY_TYPE";
                columns2[8] = "IMO_CLASS";
                columns2[9] = "UN_NO";
                columns2[10] = "HAZ_APPROVAL_REF";
                columns2[11] = "FLASH_POINT";
                columns2[12] = "CAS_NO";
                columns2[13] = "REMARKS";
                columns2[14] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl2, "TB_SRR_COMMODITIES", columns2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertContainer(string connstring, SRR request)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("SRR_ID", typeof(int)));
                tbl.Columns.Add(new DataColumn("SRR_NO", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_TYPE", typeof(string)));
                tbl.Columns.Add(new DataColumn("CONTAINER_SIZE", typeof(string)));
                tbl.Columns.Add(new DataColumn("SERVICE_MODE", typeof(string)));
                tbl.Columns.Add(new DataColumn("POD_FREE_DAYS", typeof(string)));
                tbl.Columns.Add(new DataColumn("POL_FREE_DAYS", typeof(string)));
                tbl.Columns.Add(new DataColumn("IMM_VOLUME_EXPECTED", typeof(string)));
                tbl.Columns.Add(new DataColumn("TOTAL_VOLUME_EXPECTED", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

                foreach (var i in request.SRR_CONTAINERS)
                {
                    DataRow dr = tbl.NewRow();

                    dr["SRR_ID"] = Convert.ToInt32(i.SRR_ID);
                    dr["SRR_NO"] = i.SRR_NO;
                    dr["CONTAINER_TYPE"] = i.CONTAINER_TYPE;
                    dr["CONTAINER_SIZE"] = i.CONTAINER_SIZE;
                    dr["SERVICE_MODE"] = i.SERVICE_MODE;
                    dr["POD_FREE_DAYS"] = 0;
                    dr["POL_FREE_DAYS"] = 0;
                    dr["IMM_VOLUME_EXPECTED"] = i.IMM_VOLUME_EXPECTED;
                    dr["TOTAL_VOLUME_EXPECTED"] = 0;
                    dr["CREATED_BY"] = request.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[10];
                columns[0] = "SRR_ID";
                columns[1] = "SRR_NO";
                columns[2] = "CONTAINER_TYPE";
                columns[3] = "CONTAINER_SIZE";
                columns[4] = "SERVICE_MODE";
                columns[5] = "POD_FREE_DAYS";
                columns[6] = "POL_FREE_DAYS";
                columns[7] = "IMM_VOLUME_EXPECTED";
                columns[8] = "TOTAL_VOLUME_EXPECTED";
                columns[9] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_SRR_CONTAINERS", columns);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ApproveRate(string connstring, List<SRR_RATES> request)
        {
            try
            {
                string[] columns = new string[4];
                columns[0] = "SRR_NO";
                columns[1] = "CHARGE_CODE";
                columns[2] = "APPROVED_RATE";
                columns[3] = "CONTAINER_TYPE";

                SqlHelper.UpdateSRRData<SRR_RATES>(request, "TB_SRR_RATES", connstring, columns);

                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "APPROVE_SRR" },
                  new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = request[0].SRR_NO },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SRR", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
