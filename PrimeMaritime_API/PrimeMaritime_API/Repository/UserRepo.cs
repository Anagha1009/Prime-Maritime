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
    public class UserRepo
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

        public string CreateRefreshToken(string connstring, RefreshToken refreshToken)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@USER_ID", SqlDbType.Int) { Value = refreshToken.USER_ID },
              new SqlParameter("@TOKEN", SqlDbType.VarChar, 100) { Value = refreshToken.TOKEN },
              new SqlParameter("@EXPIRES", SqlDbType.DateTime, 100) { Value = refreshToken.EXPIRES },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "CREATE_TOKEN" }
            };

            return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
        }

        public USER GetRefreshToken(string connstring, string token)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@TOKEN", SqlDbType.VarChar, 100) { Value = token },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_TOKEN" }
            };

            return SqlHelper.ExtecuteProcedureReturnData<USER>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsUser1(), parameters);
        }

        public RefreshToken GetRefreshTokenByUserId(string connstring, string token, int userid)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@TOKEN", SqlDbType.VarChar, 100) { Value = token },
              new SqlParameter("@USER_ID", SqlDbType.Int) { Value = userid },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_TOKEN_BY_USER_ID" }
            };

            return SqlHelper.ExtecuteProcedureReturnData<RefreshToken>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsRefreshToken(), parameters);
        }

        public string RevokeRefreshToken(string connstring, RefreshToken refreshToken)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@USER_ID", SqlDbType.Int) { Value = refreshToken.USER_ID },
              new SqlParameter("@TOKEN", SqlDbType.VarChar, 100) { Value = refreshToken.TOKEN },
              new SqlParameter("@REVOKED", SqlDbType.DateTime, 100) { Value = refreshToken.REVOKED },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "REVOKE_TOKEN" }
            };

            return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
        }
    }
}
