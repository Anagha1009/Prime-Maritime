using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class DOTranslator
    {
        public static DO TranslateDO(this SqlDataReader reader,bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new DO();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("BL_ID"))
                item.BL_ID = SqlHelper.GetNullableInt32(reader, "BL_ID");

            if (reader.IsColumnExists("BL_NO"))
                item.BL_NO = SqlHelper.GetNullableString(reader, "BL_NO");

            if (reader.IsColumnExists("DO_NO"))
                item.DO_NO = SqlHelper.GetNullableString(reader, "DO_NO");

            if (reader.IsColumnExists("DO_DATE"))
                item.DO_DATE = SqlHelper.GetDateTime(reader, "DO_DATE");

            if (reader.IsColumnExists("ARRIVAL_DATE"))
                item.ARRIVAL_DATE = SqlHelper.GetDateTime(reader, "ARRIVAL_DATE");

            if (reader.IsColumnExists("DO_VALIDITY"))
                item.DO_VALIDITY = SqlHelper.GetDateTime(reader, "DO_VALIDITY");

            if (reader.IsColumnExists("IGM_NO"))
                item.IGM_NO = SqlHelper.GetNullableString(reader, "IGM_NO");

            if (reader.IsColumnExists("IGM_ITEM_NO"))
                item.IGM_ITEM_NO = SqlHelper.GetNullableString(reader, "IGM_ITEM_NO");

            if (reader.IsColumnExists("IGM_DATE"))
                item.IGM_DATE = SqlHelper.GetDateTime(reader, "IGM_DATE");

            if (reader.IsColumnExists("CLEARING_PARTY"))
                item.CLEARING_PARTY = SqlHelper.GetNullableString(reader, "CLEARING_PARTY");

            if (reader.IsColumnExists("ACCEPTANCE_LOCATION"))
                item.ACCEPTANCE_LOCATION = SqlHelper.GetNullableString(reader, "ACCEPTANCE_LOCATION");

            if (reader.IsColumnExists("LETTER_VALIDITY"))
                item.LETTER_VALIDITY = SqlHelper.GetDateTime(reader, "LETTER_VALIDITY");

            if (reader.IsColumnExists("SHIPPING_TERMS"))
                item.SHIPPING_TERMS = SqlHelper.GetNullableString(reader, "SHIPPING_TERMS");

            if (reader.IsColumnExists("AGENT_CODE"))
                item.AGENT_CODE = SqlHelper.GetNullableString(reader, "AGENT_CODE");

            if (reader.IsColumnExists("AGENT_NAME"))
                item.AGENT_NAME = SqlHelper.GetNullableString(reader, "AGENT_NAME");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            return item;
        }
    }
}
