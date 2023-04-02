using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class MNRTranslator
    {
        public static MNR_TARIFF TranslateMNR(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new MNR_TARIFF();
            if (reader.IsColumnExists("MAN_HOUR"))
                item.MAN_HOUR = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "MAN_HOUR"));

            if (reader.IsColumnExists("LABOUR_CHARGE"))
                item.LABOUR_CHARGE = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "LABOUR_CHARGE"));

            if (reader.IsColumnExists("MATERIAL_COST"))
                item.MATERIAL_COST = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "MATERIAL_COST"));

            if (reader.IsColumnExists("TOTAL"))
                item.TOTAL = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "TOTAL"));

            return item;
        }
    }
}
