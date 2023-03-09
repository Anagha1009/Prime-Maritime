using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class ERTranslator
    {
        public static EMPTY_REPO TranslateER(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new EMPTY_REPO();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("REPO_NO"))
                item.REPO_NO = SqlHelper.GetNullableString(reader, "REPO_NO");

            if (reader.IsColumnExists("LOAD_DEPOT"))
                item.LOAD_DEPOT = SqlHelper.GetNullableString(reader, "LOAD_DEPOT");

            if (reader.IsColumnExists("DISCHARGE_DEPOT"))
                item.DISCHARGE_DEPOT = SqlHelper.GetNullableString(reader, "DISCHARGE_DEPOT");

            if (reader.IsColumnExists("LOAD_PORT"))
                item.LOAD_PORT = SqlHelper.GetNullableString(reader, "LOAD_PORT");

            if (reader.IsColumnExists("DISCHARGE_PORT"))
                item.DISCHARGE_PORT = SqlHelper.GetNullableString(reader, "DISCHARGE_PORT");

            if (reader.IsColumnExists("VESSEL_NAME"))
                item.VESSEL_NAME = SqlHelper.GetNullableString(reader, "VESSEL_NAME");

            if (reader.IsColumnExists("VOYAGE_NO"))
                item.VOYAGE_NO = SqlHelper.GetNullableString(reader, "VOYAGE_NO");

            if (reader.IsColumnExists("MODE_OF_TRANSPORT"))
                item.MODE_OF_TRANSPORT = SqlHelper.GetNullableString(reader, "MODE_OF_TRANSPORT");

            if (reader.IsColumnExists("MOVEMENT_DATE"))
                item.MOVEMENT_DATE = SqlHelper.GetDateTime(reader, "MOVEMENT_DATE");

            if (reader.IsColumnExists("LIFT_ON_CHARGE"))
                item.LIFT_ON_CHARGE = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "LIFT_ON_CHARGE"));

            if (reader.IsColumnExists("LIFT_OFF_CHARGE"))
                item.LIFT_OFF_CHARGE = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "LIFT_OFF_CHARGE"));

            if (reader.IsColumnExists("CURRENCY"))
                item.CURRENCY = SqlHelper.GetNullableString(reader, "CURRENCY");

            if (reader.IsColumnExists("NO_OF_CONTAINER"))
                item.NO_OF_CONTAINER = SqlHelper.GetNullableInt32(reader, "NO_OF_CONTAINER");

            if (reader.IsColumnExists("REASON"))
                item.REASON = SqlHelper.GetNullableString(reader, "REASON");

            if (reader.IsColumnExists("REMARKS"))
                item.REMARKS = SqlHelper.GetNullableString(reader, "REMARKS");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetNullableInt32(reader, "STATUS");

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
