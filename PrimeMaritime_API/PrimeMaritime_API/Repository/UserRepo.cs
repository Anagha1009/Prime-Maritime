using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.IRepository;
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
    public class UserRepo : IUserRepo
    {
        public USER GetUserByUsername(string connstring, string username)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@USERNAME", SqlDbType.VarChar, 100) { Value = username },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_USER_BY_USERNAME" }
            };

            return SqlHelper.ExtecuteProcedureReturnData<USER>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsUser1(), parameters);
        }

        public USER ValidateUser(string connstring, string username, string password)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@USERNAME", SqlDbType.VarChar, 100) { Value = username },
              new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100) { Value = password },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "VALIDATE_USER" }
            };

            return SqlHelper.ExtecuteProcedureReturnData<USER>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsUser1(), parameters);
        }
    }
}
