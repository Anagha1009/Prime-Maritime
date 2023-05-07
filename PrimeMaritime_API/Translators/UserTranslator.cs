using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class UserTranslator
    {
        public static USER TranslateAsUser1(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new USER();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("USERNAME"))
                item.USERNAME = SqlHelper.GetNullableString(reader, "USERNAME");

            if (reader.IsColumnExists("USERCODE"))
                item.USERCODE = SqlHelper.GetNullableString(reader, "USERCODE");

            if (reader.IsColumnExists("EMAIL"))
                item.EMAIL = SqlHelper.GetNullableString(reader, "EMAIL");

            if (reader.IsColumnExists("ROLE_ID"))
                item.ROLE_ID = SqlHelper.GetNullableInt32(reader, "ROLE_ID");

            if (reader.IsColumnExists("ROLE_NAME"))
                item.ROLE_NAME = SqlHelper.GetNullableString(reader, "ROLE_NAME");

            if (reader.IsColumnExists("PORT"))
                item.PORT = SqlHelper.GetNullableString(reader, "PORT");

            if (reader.IsColumnExists("DEPO"))
                item.DEPO = SqlHelper.GetNullableString(reader, "DEPO");

            if (reader.IsColumnExists("COUNTRYCODE"))
                item.COUNTRYCODE = SqlHelper.GetNullableString(reader, "COUNTRYCODE");

            if (reader.IsColumnExists("ORG_CODE"))
                item.ORG_CODE = SqlHelper.GetNullableString(reader, "ORG_CODE");

            if (reader.IsColumnExists("RESET_PASSWORD_TOKEN"))
                item.RESET_PASSWORD_TOKEN = SqlHelper.GetNullableString(reader, "RESET_PASSWORD_TOKEN");

            if (reader.IsColumnExists("RESET_PASSWORD_EXPIRY"))
                item.RESET_PASSWORD_EXPIRY = SqlHelper.GetDateTime(reader, "RESET_PASSWORD_EXPIRY");

            return item;
        }

        public static USERLIST TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new USERLIST();
    
            if (reader.IsColumnExists("NAME"))
                item.NAME = SqlHelper.GetNullableString(reader, "NAME");

            if (reader.IsColumnExists("USERNAME"))
                item.USERNAME = SqlHelper.GetNullableString(reader, "USERNAME");

            if (reader.IsColumnExists("USERTYPE"))
                item.USERTYPE = SqlHelper.GetNullableString(reader, "USERTYPE");

            if (reader.IsColumnExists("USERCODE"))
                item.USERCODE = SqlHelper.GetNullableString(reader, "USERCODE");

            if (reader.IsColumnExists("EMAIL"))
                item.EMAIL = SqlHelper.GetNullableString(reader, "EMAIL");

            if (reader.IsColumnExists("ROLE_ID"))
                item.ROLE_ID = SqlHelper.GetNullableInt32(reader, "ROLE_ID");

            if (reader.IsColumnExists("ROLE_NAME"))
                item.ROLE_NAME = SqlHelper.GetNullableString(reader, "ROLE_NAME");

            if (reader.IsColumnExists("PORT"))
                item.PORT = SqlHelper.GetNullableString(reader, "PORT");

            if (reader.IsColumnExists("DEPO"))
                item.DEPO = SqlHelper.GetNullableString(reader, "DEPO");

            if (reader.IsColumnExists("COUNTRYCODE"))
                item.COUNTRYCODE = SqlHelper.GetNullableString(reader, "COUNTRYCODE");

            if (reader.IsColumnExists("LOCATION"))
                item.LOCATION = SqlHelper.GetNullableString(reader, "LOCATION");

            if (reader.IsColumnExists("USERADDRESS"))
                item.USERADDRESS = SqlHelper.GetNullableString(reader, "USERADDRESS");

            if (reader.IsColumnExists("ROLE_ID"))
                item.ROLE_ID = SqlHelper.GetNullableInt32(reader, "ROLE_ID");

            if (reader.IsColumnExists("ORG_CODE"))
                item.ORG_CODE = SqlHelper.GetNullableString(reader, "ORG_CODE");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            return item;
        }

        public static RefreshToken TranslateAsRefreshToken(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new RefreshToken();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("USER_ID"))
                item.USER_ID = SqlHelper.GetNullableInt32(reader, "USER_ID");

            if (reader.IsColumnExists("TOKEN"))
                item.TOKEN = SqlHelper.GetNullableString(reader, "TOKEN");

            if (reader.IsColumnExists("EXPIRES"))
                item.EXPIRES = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "EXPIRES"));

            if (reader.IsColumnExists("CREATED"))
                item.CREATED = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "CREATED"));

            if (reader.IsColumnExists("REVOKED"))
                item.REVOKED = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "REVOKED"));

            if (reader.IsColumnExists("IS_ACTIVE"))
                item.IS_ACTIVE = Convert.ToBoolean(SqlHelper.GetNullableString(reader, "IS_ACTIVE"));

            return item;
        }
    }
}
