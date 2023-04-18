using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

        public USER ValidatePwd(string connstring, string password, int userId)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100) { Value = password },
              new SqlParameter("@USER_ID", SqlDbType.Int) { Value =  userId},
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "VALIDATE_PWD" }
            };

            return SqlHelper.ExtecuteProcedureReturnData<USER>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsUser1(), parameters);
        }

        public void ResetPwd(string connstring, int userId, string password)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@USER_ID", SqlDbType.Int) { Value = userId },
              new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100) { Value = password },
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "RESET_PWD" }
            };

            SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
        }
        public List<USERLIST> GetUserList(string connstring)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_USERLIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_USER_MANAGEMENT", parameters);
                List<USERLIST> userList = SqlHelper.CreateListFromTable<USERLIST>(dataTable);
                return userList;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public string InsertUser(string connstring, USERLIST user)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_USER" },
                  new SqlParameter("@NAME", SqlDbType.VarChar,255) { Value = user.NAME },
                  new SqlParameter("@USERNAME", SqlDbType.VarChar, 100) { Value = user.USERNAME },
                  new SqlParameter("@USERTYPE", SqlDbType.VarChar, 20) { Value = user.USERTYPE },
                  new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100) { Value = user.PASSWORD },
                  new SqlParameter("@USERCODE", SqlDbType.VarChar, 50) { Value = user.USERCODE },
                  new SqlParameter("@PORT", SqlDbType.VarChar, 50) { Value = user.PORT },
                  new SqlParameter("@DEPO", SqlDbType.VarChar, 100) { Value = user.DEPO },
                  new SqlParameter("@EMAIL", SqlDbType.VarChar, 255) { Value = user.EMAIL },
                  new SqlParameter("@LOCATION", SqlDbType.VarChar, 255) { Value = user.LOCATION },
                  new SqlParameter("@COUNTRYCODE", SqlDbType.VarChar, 50) { Value = user.COUNTRYCODE },
                  new SqlParameter("@USERADDRESS", SqlDbType.VarChar, 255) { Value = user.USERADDRESS },
                  new SqlParameter("@ROLE_ID", SqlDbType.Int) { Value = user.ROLE_ID },
                  new SqlParameter("@ORG_CODE", SqlDbType.VarChar,50) { Value = user.ORG_CODE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = user.STATUS },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = user.CREATED_BY },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string ValidateUsercode(string connstring, string usercode)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "VALIDATE_USERCODE" },
                  new SqlParameter("@USERCODE", SqlDbType.VarChar,50) { Value = usercode },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public USERLIST GetUserByUsercode(string connstring, string usercode)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@USERCODE", SqlDbType.VarChar, 50) { Value = usercode },
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_USER_BY_USERCODE" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<USERLIST>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsUser(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UpdateUser(string connstring, USERLIST user)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_USER" },
                  new SqlParameter("@NAME", SqlDbType.VarChar,255) { Value = user.NAME },
                  new SqlParameter("@USERNAME", SqlDbType.VarChar, 100) { Value = user.USERNAME },
                  new SqlParameter("@USERTYPE", SqlDbType.VarChar, 20) { Value = user.USERTYPE },
                  new SqlParameter("@USERCODE", SqlDbType.VarChar, 50) { Value = user.USERCODE },
                  new SqlParameter("@PORT", SqlDbType.VarChar, 50) { Value = user.PORT },
                  new SqlParameter("@DEPO", SqlDbType.VarChar, 100) { Value = user.DEPO },
                  new SqlParameter("@EMAIL", SqlDbType.VarChar, 255) { Value = user.EMAIL },
                  new SqlParameter("@LOCATION", SqlDbType.VarChar, 255) { Value = user.LOCATION },
                  new SqlParameter("@COUNTRYCODE", SqlDbType.VarChar, 50) { Value = user.COUNTRYCODE },
                  new SqlParameter("@USERADDRESS", SqlDbType.VarChar, 255) { Value = user.USERADDRESS },
                  new SqlParameter("@ROLE_ID", SqlDbType.Int) { Value = user.ROLE_ID },
                  new SqlParameter("@ORG_CODE", SqlDbType.VarChar,50) { Value = user.ORG_CODE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = user.STATUS },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string DeleteUser(string connstring, string usercode)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "DELETE_USER" },
                  new SqlParameter("@USERCODE", SqlDbType.VarChar, 50) { Value = usercode },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public USER CheckUserByEmail(string connstring, string email)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@EMAIL", SqlDbType.VarChar, 255) { Value = email },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_USER_BY_EMAIL" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<USER>(connstring, "SP_USER_MANAGEMENT", r => r.TranslateAsUser1(), parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }          

        public string UpdateResetPwd(string connstring, USER user)
        {
            try
            {
                SqlParameter[] parameters1 =
                {
                    new SqlParameter("@USER_ID", SqlDbType.Int) { Value = user.ID },
                    new SqlParameter("@RESET_PASSWORD_TOKEN", SqlDbType.VarChar, 255) { Value = user.RESET_PASSWORD_TOKEN},
                    new SqlParameter("@RESET_PASSWORD_EXPIRY", SqlDbType.DateTime) { Value = user.RESET_PASSWORD_EXPIRY},
                    new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "RESET_PASSWORD_TOKEN" }
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters1);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RenewPwd(string connstring, int userid, string newPwd)
        {
            try
            {
                SqlParameter[] parameters1 =
                {
                  new SqlParameter("@USER_ID", SqlDbType.Int) { Value = userid},
                  new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100) { Value = newPwd },
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "RESET_PWD" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_USER_MANAGEMENT", parameters1);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
