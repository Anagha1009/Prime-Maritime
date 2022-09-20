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
    public class SRRRepo
    {
        public DataSet GetSRRData(string connstring, string SRR_NO)
        {
            SqlParameter parameters = new SqlParameter();
            parameters.Value = SRR_NO;
            parameters.ParameterName = "@SRR_NO";

            return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_GET_SRR", parameters);
        }

        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }

        public List<SRR> GetSRRList(string connstring)
        {
            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_GET_SRR");
            List<SRR> srrList = SqlHelper.CreateListFromTable<SRR>(dataTable);

            return srrList;
        }
    }
}
