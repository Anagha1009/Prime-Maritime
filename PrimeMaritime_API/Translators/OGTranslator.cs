using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class OGTranslator
    {
        public static Organisation TranslateOrganisation(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new Organisation();

            if (reader.IsColumnExists("ORG_NAME"))
                item.ORG_NAME = SqlHelper.GetNullableString(reader, "ORG_NAME");

            if (reader.IsColumnExists("ORG_ADDRESS1"))
                item.ORG_ADDRESS1 = SqlHelper.GetNullableString(reader, "ORG_ADDRESS1");

            if (reader.IsColumnExists("ORG_ADDRESS2"))
                item.ORG_ADDRESS2 = SqlHelper.GetNullableString(reader, "ORG_ADDRESS2");

            if (reader.IsColumnExists("CONTACT"))
                item.CONTACT = SqlHelper.GetNullableString(reader, "CONTACT");

            if (reader.IsColumnExists("EMAIL"))
                item.EMAIL = SqlHelper.GetNullableString(reader, "EMAIL");

            if (reader.IsColumnExists("FAX"))
                item.FAX = SqlHelper.GetNullableString(reader, "FAX");

            return item;
        }
    }
}
