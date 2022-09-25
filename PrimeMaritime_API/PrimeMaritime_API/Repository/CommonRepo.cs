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
    public class CommonRepo
    {
        public List<DROPDOWN> GetDropdownData(string connstring, string key)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.Value = key;
            sqlParameter.ParameterName = "@KEY";

            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_GET_MASTER_DATA", sqlParameter);
            List<DROPDOWN> dropdownList = SqlHelper.CreateListFromTable<DROPDOWN>(dataTable);

            return dropdownList;
        }
    }
}
