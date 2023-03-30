using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class TDRTranslator
    {
        public static TDR TranslateTDR(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new TDR();
            
            if (reader.IsColumnExists("TDR_NO"))
                item.TDR_NO = SqlHelper.GetNullableString(reader, "TDR_NO");

            if (reader.IsColumnExists("VESSEL_NAME"))
                item.VESSEL_NAME = SqlHelper.GetNullableString(reader, "VESSEL_NAME");

            if (reader.IsColumnExists("VOYAGE_NO"))
                item.VOYAGE_NO = SqlHelper.GetNullableString(reader, "VOYAGE_NO"); 

            if (reader.IsColumnExists("POL"))
                item.POL = SqlHelper.GetNullableString(reader, "POL");

            if (reader.IsColumnExists("TERMINAL"))
                item.TERMINAL = SqlHelper.GetNullableString(reader, "TERMINAL");

            if (reader.IsColumnExists("ETA"))
                item.ETA = SqlHelper.GetDateTime(reader, "ETA");

            if (reader.IsColumnExists("ETD"))
                item.ETD = SqlHelper.GetDateTime(reader, "ETD");

            if (reader.IsColumnExists("POB_BERTHING"))
                item.POB_BERTHING = SqlHelper.GetDateTime(reader, "POB_BERTHING");

            if (reader.IsColumnExists("BERTHED"))
                item.BERTHED = SqlHelper.GetDateTime(reader, "BERTHED");

            if (reader.IsColumnExists("OPERATION_COMMMENCED"))
                item.OPERATION_COMMMENCED = SqlHelper.GetDateTime(reader, "OPERATION_COMMMENCED");

            if (reader.IsColumnExists("POB_SAILING"))
                item.POB_SAILING = SqlHelper.GetDateTime(reader, "POB_SAILING");

            if (reader.IsColumnExists("SAILED"))
                item.SAILED = SqlHelper.GetDateTime(reader, "SAILED");

            if (reader.IsColumnExists("ETA_NEXTPORT"))
                item.ETA_NEXTPORT = SqlHelper.GetDateTime(reader, "ETA_NEXTPORT");

            if (reader.IsColumnExists("CREATED_DATE"))
                item.CREATED_DATE = SqlHelper.GetDateTime(reader, "CREATED_DATE");

            return item;
        }
    }
}
