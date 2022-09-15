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
        public static SRR TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new SRR();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("SRR_NO"))
                item.SRR_NO = SqlHelper.GetNullableString(reader, "SRR_NO");

            if (reader.IsColumnExists("CUSTOMER_NAME"))
                item.CUSTOMER_NAME = SqlHelper.GetNullableString(reader, "CUSTOMER_NAME");

            if (reader.IsColumnExists("VALID_FROM"))
                item.VALID_FROM = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "VALID_FROM"));

            if (reader.IsColumnExists("VALID_TO"))
                item.VALID_TO = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "VALID_TO"));

            if (reader.IsColumnExists("POL_FREE_DAYS"))
                item.POL_FREE_DAYS = SqlHelper.GetNullableInt32(reader, "POL_FREE_DAYS");

            return item;
        }

        public static List<SRR> TranslateAsUsersList(this SqlDataReader reader)
        {
            var list = new List<SRR>();
            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }
    }
}
