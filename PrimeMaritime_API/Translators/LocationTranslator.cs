using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class LocationTranslator
    {
        public static LOCATION_MASTER TranslateAsLocation(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new LOCATION_MASTER();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("LOC_NAME"))
                item.LOC_NAME = SqlHelper.GetNullableString(reader, "LOC_NAME");

            if (reader.IsColumnExists("LOC_CODE"))
                item.LOC_CODE = SqlHelper.GetNullableString(reader, "LOC_CODE");

            if (reader.IsColumnExists("IS_DEPO"))
                item.IS_DEPO = SqlHelper.GetBoolean(reader, "IS_DEPO");

            if (reader.IsColumnExists("IS_CFS"))
                item.IS_CFS = SqlHelper.GetBoolean(reader, "IS_CFS");

            if (reader.IsColumnExists("IS_TERMINAL"))
                item.IS_TERMINAL = SqlHelper.GetBoolean(reader, "IS_TERMINAL");

            if (reader.IsColumnExists("IS_YARD"))
                item.IS_YARD = SqlHelper.GetBoolean(reader, "IS_YARD");

            if (reader.IsColumnExists("IS_ICD"))
                item.IS_ICD = SqlHelper.GetBoolean(reader, "IS_ICD");

            if (reader.IsColumnExists("ADDRESS"))
                item.ADDRESS = SqlHelper.GetNullableString(reader, "ADDRESS");

            if (reader.IsColumnExists("COUNTRY_CODE"))
                item.COUNTRY_CODE = SqlHelper.GetNullableString(reader, "COUNTRY_CODE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            return item;
        }
    }
}
