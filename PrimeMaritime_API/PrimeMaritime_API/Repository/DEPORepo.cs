using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Response;
using System.IO;

namespace PrimeMaritime_API.Repository
{
    public class DEPORepo
    {
        public void InsertContainer(string connstring, DEPO_CONTAINER request)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("BOOKING_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("CRO_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));

            foreach (var i in request.CONTAINER_LIST)
            {
                DataRow dr = tbl.NewRow();

                dr["BOOKING_NO"] = request.BOOKING_NO;
                dr["CRO_NO"] = request.CRO_NO;
                dr["CONTAINER_NO"] = i.CONTAINER_NO;
                dr["CREATED_BY"] = request.CREATED_BY;

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[4];
            columns[0] = "BOOKING_NO";
            columns[1] = "CRO_NO";
            columns[2] = "CONTAINER_NO";
            columns[3] = "CREATED_BY";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_CONTAINER", columns);
        }

        public void InsertMRRequest(string connstring, List<MR_LIST> request)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "INSERT_MNR" },
                new SqlParameter("@MR_NO", SqlDbType.VarChar, 100) { Value = request[0].MR_NO },
                new SqlParameter("@DEPO_CODE", SqlDbType.VarChar, 50) { Value = request[0].DEPO_CODE },
                new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = "Requested" },
                new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 255) { Value = request[0].CREATED_BY },
            };

            SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_MNR", parameters);

            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("MR_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
            tbl.Columns.Add(new DataColumn("LOCATION", typeof(string)));
            tbl.Columns.Add(new DataColumn("COMPONENT", typeof(string)));
            tbl.Columns.Add(new DataColumn("DAMAGE", typeof(string)));
            tbl.Columns.Add(new DataColumn("REPAIR", typeof(string)));
            tbl.Columns.Add(new DataColumn("DESC", typeof(string)));
            tbl.Columns.Add(new DataColumn("LENGTH", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("WIDTH", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("HEIGHT", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("UNIT", typeof(string)));
            tbl.Columns.Add(new DataColumn("RESPONSIBILITY", typeof(string)));
            tbl.Columns.Add(new DataColumn("MAN_HOUR", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("LABOUR", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("MATERIAL", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("TOTAL", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("TAX", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("FINAL_TOTAL", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("STATUS", typeof(string)));

            foreach (var i in request)
            {
                DataRow dr = tbl.NewRow();

                dr["MR_NO"] = request[0].MR_NO;
                dr["CONTAINER_NO"] = i.CONTAINER_NO;
                dr["LOCATION"] = i.LOCATION;
                dr["COMPONENT"] = i.COMPONENT;
                dr["DAMAGE"] = i.DAMAGE;
                dr["REPAIR"] = i.REPAIR;
                dr["DESC"] = null;
                dr["LENGTH"] = i.LENGTH;
                dr["WIDTH"] = i.WIDTH;
                dr["HEIGHT"] = i.HEIGHT;
                dr["UNIT"] = i.UNIT;
                dr["RESPONSIBILITY"] = i.RESPONSIBILITY;
                dr["MAN_HOUR"] = i.MAN_HOUR;
                dr["LABOUR"] = i.LABOUR;
                dr["MATERIAL"] = i.MATERIAL;
                dr["TOTAL"] = i.LABOUR + i.MATERIAL;
                dr["TAX"] = i.TAX;
                dr["FINAL_TOTAL"] = i.FINAL_TOTAL;
                dr["STATUS"] = "Requested";

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[19];
            columns[0] = "LOCATION";
            columns[1] = "COMPONENT";
            columns[2] = "DAMAGE";
            columns[3] = "REPAIR";
            columns[4] = "DESC";
            columns[5] = "LENGTH";
            columns[6] = "WIDTH";
            columns[7] = "HEIGHT";
            columns[8] = "UNIT";
            columns[9] = "RESPONSIBILITY";
            columns[10] = "MAN_HOUR";
            columns[11] = "LABOUR";
            columns[12] = "MATERIAL";
            columns[13] = "TOTAL";
            columns[14] = "CONTAINER_NO";
            columns[15] = "TAX";
            columns[16] = "FINAL_TOTAL";
            columns[17] = "STATUS";
            columns[18] = "MR_NO";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_MR_REQUEST", columns);
        }

        public string GetMNRDescription(string connstring, string Ist_char, string IInd_char, string IIIrd_char, string IVth_char, string component_code, string damage_code, string repair_code)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@FIRST_CHAR", SqlDbType.Char,1) { Value = Ist_char },
              new SqlParameter("@SECOND_CHAR", SqlDbType.Char,1) { Value = IInd_char },
              new SqlParameter("@THIRD_CHAR", SqlDbType.Char,10) { Value = IIIrd_char },
              new SqlParameter("@FOURTH_CHAR", SqlDbType.Char,10) { Value = IVth_char },
              new SqlParameter("@COMPONENT_CODE", SqlDbType.VarChar,255) { Value = component_code },
              new SqlParameter("@DAMAGE_CODE", SqlDbType.VarChar,255) { Value = damage_code },
              new SqlParameter("@REPAIR_CODE", SqlDbType.VarChar,255) { Value = repair_code },
              //new SqlParameter("@RES", SqlDbType.VarChar,255)
            };

            //parameters[7].Direction = ParameterDirection.Output;

            string MNR_Desc = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MNR", parameters);


            return MNR_Desc;
        }

        public List<MNR_LIST> GetMNRList(string connstring, string OPERATION, string DEPO_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = OPERATION },
                  new SqlParameter("@DEPO_CODE", SqlDbType.VarChar, 50) { Value = DEPO_CODE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_MNR", parameters);
                List<MNR_LIST> Responses = SqlHelper.CreateListFromTable<MNR_LIST>(dataTable);

                return Responses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MR_LIST> GetMRREQDetails(string connstring, string MR_NO)
        {

            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_MR_REQ_DETAILS" },
                  new SqlParameter("@MR_NO", SqlDbType.VarChar, 50) { Value = MR_NO },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_MNR", parameters);
                List<MR_LIST> Responses = SqlHelper.CreateListFromTable<MR_LIST>(dataTable);

                return Responses;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ApproveRate(string connstring, List<MR_LIST> request)
        {
            try
            {
                string[] columns = new string[3];
                columns[0] = "MR_NO";
                columns[1] = "LOCATION";
                columns[2] = "APPROVED_RATE";

                SqlHelper.UpdateMRData<MR_LIST>(request, "TB_MR_REQUEST", connstring, columns);

                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "APPROVE_RATE" },
                  new SqlParameter("@MR_NO", SqlDbType.VarChar, 100) { Value = request[0].MR_NO },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_MNR", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }

        

    }
}
