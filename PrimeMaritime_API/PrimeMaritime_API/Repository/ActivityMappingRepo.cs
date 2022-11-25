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
    public class ActivityMappingRepo
    {
        public void InsertActivityMapping(string connstr, ACTIVITY_MAPPING request)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("ACT_ID", typeof(int)));
                tbl.Columns.Add(new DataColumn("ACT_SEQ_ID", typeof(int)));
                tbl.Columns.Add(new DataColumn("CREATED_BY", typeof(string)));
                tbl.Columns.Add(new DataColumn("CREATED_DATE", typeof(DateTime)));

                foreach (var i in request.ACT_SEQ_ID)
                {
                    DataRow dr = tbl.NewRow();

                    dr["ACT_ID"] = request.ACT_ID;
                    dr["ACT_SEQ_ID"] = i.ID;
                    dr["CREATED_BY"] = request.CREATED_BY;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[3];
                columns[0] = "ACT_ID";
                columns[1] = "ACT_SEQ_ID";
                columns[2] = "CREATED_BY";

                SqlHelper.ExecuteProcedureBulkInsert(connstr, tbl, "TB_CONT_ACT_MAPPING", columns);
            }
            catch(Exception)
            {
                throw;
            }
        }

        
    }
}
