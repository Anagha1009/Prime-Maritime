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
    public class CountRepo
    {
        public COUNT GETCOUNT(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_COUNT" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<COUNT>(dbConn, "SP_COUNT", r => r.TranslateAsCountTranslator(), parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
