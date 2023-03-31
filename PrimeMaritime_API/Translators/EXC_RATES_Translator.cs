using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class EXC_RATES_Translator
    {
        public static EXC_RATES TranslateEXCRATES(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new EXC_RATES();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CURRENCY_TYPE"))
                item.CURRENCY_TYPE = SqlHelper.GetNullableString(reader, "CURRENCY_TYPE");

            if (reader.IsColumnExists("CURRENCY_CODE"))
                item.CURRENCY_CODE = SqlHelper.GetNullableString(reader, "CURRENCY_CODE");

            if (reader.IsColumnExists("TT_SELLING"))
                item.TT_SELLING = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "TT_SELLING"));

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("AGENT_CODE"))
                item.AGENT_CODE = SqlHelper.GetNullableString(reader, "AGENT_CODE");

            return item;
        }
    }
}
