using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class CountTranslator
    {
        public static COUNT TranslateAsCountTranslator(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new COUNT();
            if (reader.IsColumnExists("SRR_COUNT"))
                item.SRR_COUNT = SqlHelper.GetNullableInt32(reader, "SRR_COUNT");

            if (reader.IsColumnExists("BOOKING_COUNT"))
                item.BOOKING_COUNT = SqlHelper.GetNullableInt32(reader, "BOOKING_COUNT");

            if (reader.IsColumnExists("CRO_COUNT"))
                item.CRO_COUNT = SqlHelper.GetNullableInt32(reader, "CRO_COUNT");

            if (reader.IsColumnExists("BL_COUNT"))
                item.BL_COUNT = SqlHelper.GetNullableInt32(reader, "BL_COUNT");

            if (reader.IsColumnExists("DO_COUNT"))
                item.DO_COUNT = SqlHelper.GetNullableInt32(reader, "DO_COUNT");

            return item;
        }
    }
}
