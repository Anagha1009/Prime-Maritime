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
        public static EXC_RATE TranslateEXCRATES(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new EXC_RATE();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CURRENCY_CODE"))
                item.CURRENCY = SqlHelper.GetNullableString(reader, "CURRENCY_CODE");

            if (reader.IsColumnExists("RATE"))
                item.RATE = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RATE"));

            if (reader.IsColumnExists("AGENT_CODE"))
                item.AGENT_CODE = SqlHelper.GetNullableString(reader, "AGENT_CODE");

            return item;
        }
    }
}
