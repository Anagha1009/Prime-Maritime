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
    public class SRRReportRepo
    {
        public List<SRR_REPORT> GetSRRCountList(string connstring)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_SRR_COUNT_LIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_SRR_REPORT", parameters);
                List<SRR_REPORT> Responses = SqlHelper.CreateListFromTable<SRR_REPORT>(dataTable);

                return Responses;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
