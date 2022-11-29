using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PrimeMaritime_API.Helpers;

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
            DataTable tbl = new DataTable();
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
            tbl.Columns.Add(new DataColumn("STATUS", typeof(string)));

            foreach (var i in request)
            {
                DataRow dr = tbl.NewRow();

                dr["CONTAINER_NO"] = i.CONTAINER_NO;
                dr["LOCATION"] = i.LOCATION;
                dr["COMPONENT"] = i.COMPONENT;
                dr["DAMAGE"] = i.DAMAGE;
                dr["REPAIR"] = i.REPAIR;
                dr["DESC"] = i.DESC;
                dr["LENGTH"] = i.LENGTH;
                dr["WIDTH"] = i.WIDTH;
                dr["HEIGHT"] = i.HEIGHT;
                dr["UNIT"] = i.UNIT;
                dr["RESPONSIBILITY"] = i.RESPONSIBILITY;
                dr["MAN_HOUR"] = i.MAN_HOUR;
                dr["LABOUR"] = i.LABOUR;
                dr["MATERIAL"] = i.MATERIAL;
                dr["TOTAL"] = i.TOTAL;
                dr["STATUS"] = "Requested";

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[16];
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
            columns[15] = "STATUS";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "TB_MR_REQUEST", columns);
        }
    }
}
