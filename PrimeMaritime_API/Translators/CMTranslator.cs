using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class CMTranslator
    {
        public static CM TranslateCM(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new CM();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("BOOKING_NO"))
                item.BOOKING_NO = SqlHelper.GetNullableString(reader, "BOOKING_NO");

            if (reader.IsColumnExists("CRO_NO"))
                item.CRO_NO = SqlHelper.GetNullableString(reader, "CRO_NO");

            if (reader.IsColumnExists("CONTAINER_NO"))
                item.CONTAINER_NO = SqlHelper.GetNullableString(reader, "CONTAINER_NO");

            if (reader.IsColumnExists("ACTIVITY"))
                item.ACTIVITY = SqlHelper.GetNullableString(reader, "ACTIVITY");

            if (reader.IsColumnExists("PREV_ACTIVITY"))
                item.PREV_ACTIVITY = SqlHelper.GetNullableString(reader, "PREV_ACTIVITY");

            if (reader.IsColumnExists("ACTIVITY_DATE"))
                item.ACTIVITY_DATE = SqlHelper.GetDateTime(reader, "ACTIVITY_DATE");

            if (reader.IsColumnExists("LOCATION"))
                item.LOCATION = SqlHelper.GetNullableString(reader, "LOCATION");

            if (reader.IsColumnExists("CURRENT_LOCATION"))
                item.CURRENT_LOCATION = SqlHelper.GetNullableString(reader, "CURRENT_LOCATION");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetNullableString(reader, "STATUS");

            if (reader.IsColumnExists("AGENT_CODE"))
                item.AGENT_CODE = SqlHelper.GetNullableString(reader, "AGENT_CODE");

            if (reader.IsColumnExists("DEPO_CODE"))
                item.DEPO_CODE = SqlHelper.GetNullableString(reader, "DEPO_CODE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            return item;
        }
    }
}
