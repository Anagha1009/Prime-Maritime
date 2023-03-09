using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class ActivityTranslator
    {
        public static ACTIVITY TranslateActivity(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new ACTIVITY();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("ACT_NAME"))
                item.ACT_NAME = SqlHelper.GetNullableString(reader, "ACT_NAME");

            if (reader.IsColumnExists("ACT_CODE"))
                item.ACT_CODE = SqlHelper.GetNullableString(reader, "ACT_CODE");

            if (reader.IsColumnExists("ACT_TYPE"))
                item.ACT_TYPE = SqlHelper.GetNullableString(reader, "ACT_TYPE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            return item;
        }
    }
}
