using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class SRRTranslator
    {
        public static SRR TranslateAsSRR(this SqlDataReader reader, bool isList = false)
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

            if (reader.IsColumnExists("POL"))
                item.POL = SqlHelper.GetNullableString(reader, "POL");

            if (reader.IsColumnExists("POD"))
                item.POD = SqlHelper.GetNullableString(reader, "POD");

            if (reader.IsColumnExists("ORIGIN_ICD"))
                item.ORIGIN_ICD = SqlHelper.GetNullableString(reader, "ORIGIN_ICD");

            if (reader.IsColumnExists("DESTINATION_ICD"))
                item.DESTINATION_ICD = SqlHelper.GetNullableString(reader, "DESTINATION_ICD");

            if (reader.IsColumnExists("SERVICE_NAME"))
                item.SERVICE_NAME = SqlHelper.GetNullableString(reader, "SERVICE_NAME");

            if (reader.IsColumnExists("EFFECT_FROM"))
                item.EFFECT_FROM = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "EFFECT_FROM"));

            if (reader.IsColumnExists("EFFECT_TO"))
                item.EFFECT_TO = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "EFFECT_TO"));

            if (reader.IsColumnExists("MTY_REPO"))
                item.MTY_REPO = SqlHelper.GetBoolean(reader, "MTY_REPO");

            if (reader.IsColumnExists("POD"))
                item.POD = SqlHelper.GetNullableString(reader, "POD");

            if (reader.IsColumnExists("CUSTOMER_NAME"))
                item.CUSTOMER_NAME = SqlHelper.GetNullableString(reader, "CUSTOMER_NAME");

            if (reader.IsColumnExists("ADDRESS"))
                item.ADDRESS = SqlHelper.GetNullableString(reader, "ADDRESS");

            if (reader.IsColumnExists("EMAIL"))
                item.EMAIL = SqlHelper.GetNullableString(reader, "EMAIL");

            if (reader.IsColumnExists("CONTACT"))
                item.CONTACT = SqlHelper.GetNullableString(reader, "CONTACT");

            if (reader.IsColumnExists("SHIPPER"))
                item.SHIPPER = SqlHelper.GetNullableString(reader, "SHIPPER");

            if (reader.IsColumnExists("CONSIGNEE"))
                item.CONSIGNEE = SqlHelper.GetNullableString(reader, "CONSIGNEE");

            if (reader.IsColumnExists("NOTIFY_PARTY"))
                item.NOTIFY_PARTY = SqlHelper.GetNullableString(reader, "NOTIFY_PARTY");

            if (reader.IsColumnExists("BROKERAGE_PARTY"))
                item.BROKERAGE_PARTY = SqlHelper.GetNullableString(reader, "BROKERAGE_PARTY");

            if (reader.IsColumnExists("FORWARDER"))
                item.FORWARDER = SqlHelper.GetNullableString(reader, "FORWARDER");

            if (reader.IsColumnExists("PLACE_OF_RECEIPT"))
                item.PLACE_OF_RECEIPT = SqlHelper.GetNullableString(reader, "PLACE_OF_RECEIPT");

            if (reader.IsColumnExists("PLACE_OF_DELIVERY"))
                item.PLACE_OF_DELIVERY = SqlHelper.GetNullableString(reader, "PLACE_OF_DELIVERY");

            if (reader.IsColumnExists("TSP_1"))
                item.TSP_1 = SqlHelper.GetNullableString(reader, "TSP_1");

            if (reader.IsColumnExists("TSP_2"))
                item.TSP_2 = SqlHelper.GetNullableString(reader, "TSP_2");

            if (reader.IsColumnExists("CONTAINER_TYPE"))
                item.CONTAINER_TYPE = SqlHelper.GetNullableString(reader, "CONTAINER_TYPE");

            if (reader.IsColumnExists("SERVICE_MODE"))
                item.SERVICE_MODE = SqlHelper.GetNullableString(reader, "SERVICE_MODE");

            if (reader.IsColumnExists("POD_FREE_DAYS"))
                item.POD_FREE_DAYS = SqlHelper.GetNullableInt32(reader, "POD_FREE_DAYS");

            if (reader.IsColumnExists("POL_FREE_DAYS"))
                item.POL_FREE_DAYS = SqlHelper.GetNullableInt32(reader, "POL_FREE_DAYS");

            if (reader.IsColumnExists("IMM_VOLUME_EXPECTED"))
                item.IMM_VOLUME_EXPECTED = SqlHelper.GetNullableInt32(reader, "IMM_VOLUME_EXPECTED");

            if (reader.IsColumnExists("TOTAL_VOLUME_EXPECTED"))
                item.TOTAL_VOLUME_EXPECTED = SqlHelper.GetNullableInt32(reader, "TOTAL_VOLUME_EXPECTED");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetNullableString(reader, "STATUS");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("CREATED_DATE"))
                item.CREATED_DATE = Convert.ToDateTime(SqlHelper.GetNullableString(reader, "CREATED_DATE"));

            item.SRR_CONTAINERS = TranslateAsSRRContainerList(reader);

            return item;
        }

        public static List<SRR> TranslateAsSRRList(this SqlDataReader reader)
        {
            var list = new List<SRR>();
            while (reader.Read())
            {
                list.Add(TranslateAsSRR(reader, true));
            }
            return list;
        }

        public static SRR_CONTAINERS TranslateAsSRRContainer(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SRR_CONTAINERS();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("SRR_NO"))
                item.SRR_NO = SqlHelper.GetNullableString(reader, "SRR_NO");

            if (reader.IsColumnExists("CONTAINER_TYPE"))
                item.CONTAINER_TYPE = SqlHelper.GetNullableString(reader, "CONTAINER_TYPE");

            if (reader.IsColumnExists("CONTAINER_SIZE"))
                item.CONTAINER_SIZE = SqlHelper.GetNullableInt32(reader, "CONTAINER_SIZE");

            if (reader.IsColumnExists("POL_FREE_DAYS"))
                item.POL_FREE_DAYS = SqlHelper.GetNullableInt32(reader, "POL_FREE_DAYS");

            if (reader.IsColumnExists("POD_FREE_DAYS"))
                item.POD_FREE_DAYS = SqlHelper.GetNullableInt32(reader, "POD_FREE_DAYS");

            if (reader.IsColumnExists("IMM_VOLUME_EXPECTED"))
                item.IMM_VOLUME_EXPECTED = SqlHelper.GetNullableInt32(reader, "IMM_VOLUME_EXPECTED");

            if (reader.IsColumnExists("TOTAL_VOLUME_EXPECTED"))
                item.TOTAL_VOLUME_EXPECTED = SqlHelper.GetNullableInt32(reader, "TOTAL_VOLUME_EXPECTED");

            return item;
        }

        public static List<SRR_CONTAINERS> TranslateAsSRRContainerList(this SqlDataReader reader)
        {
            var list = new List<SRR_CONTAINERS>();
            while (reader.Read())
            {
                list.Add(TranslateAsSRRContainer(reader, true));
            }
            return list;
        }
    }
}
