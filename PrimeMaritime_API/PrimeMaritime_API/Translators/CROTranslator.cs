using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class CROTranslator
    {
        public static CRO TranslateAsCRO(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new CRO();
            if (reader.IsColumnExists("CRO_ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "CRO_ID");

            if (reader.IsColumnExists("BOOKING_ID"))
                item.BOOKING_ID = SqlHelper.GetNullableInt32(reader, "BOOKING_ID");

            if (reader.IsColumnExists("BOOKING_NO"))
                item.BOOKING_NO = SqlHelper.GetNullableString(reader, "BOOKING_NO");

            if (reader.IsColumnExists("STUFFING_TYPE"))
                item.STUFFING_TYPE = SqlHelper.GetNullableString(reader, "STUFFING_TYPE");

            if (reader.IsColumnExists("EMPTY_CONT_PCKP"))
                item.EMPTY_CONT_PCKP = SqlHelper.GetNullableString(reader, "EMPTY_CONT_PCKP");

            if (reader.IsColumnExists("LADEN_ACPT_LOCATION"))
                item.LADEN_ACPT_LOCATION = SqlHelper.GetNullableString(reader, "LADEN_ACPT_LOCATION");

            if (reader.IsColumnExists("CRO_VALIDITY_DATE"))
                item.CRO_VALIDITY_DATE = SqlHelper.GetDateTime(reader, "CRO_VALIDITY_DATE");

            if (reader.IsColumnExists("REMARKS"))
                item.REMARKS = SqlHelper.GetNullableString(reader, "REMARKS");

            if (reader.IsColumnExists("REQ_QUANTITY"))
                item.REQ_QUANTITY = SqlHelper.GetNullableInt32(reader, "REQ_QUANTITY");

            if (reader.IsColumnExists("GROSS_WT"))
                item.GROSS_WT = SqlHelper.GetNullableInt32(reader, "GROSS_WT");

            if (reader.IsColumnExists("GROSS_WT_UNIT"))
                item.GROSS_WT_UNIT = SqlHelper.GetNullableString(reader, "GROSS_WT_UNIT");

            if (reader.IsColumnExists("PACKAGES"))
                item.PACKAGES = SqlHelper.GetNullableString(reader, "PACKAGES");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetNullableString(reader, "STATUS");

            if (reader.IsColumnExists("NO_OF_PACKAGES"))
                item.NO_OF_PACKAGES = SqlHelper.GetNullableInt32(reader, "NO_OF_PACKAGES");

            return item;
        }

    }
}
