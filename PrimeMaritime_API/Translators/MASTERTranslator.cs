using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Translators
{
    public static class MASTERTranslator
    {
        public static PARTY_MASTER TranslateAsCustomer(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new PARTY_MASTER();

            if (reader.IsColumnExists("CUST_ID"))
                item.CUST_ID = SqlHelper.GetNullableInt32(reader, "CUST_ID");

            if (reader.IsColumnExists("CUST_NAME"))
                item.CUST_NAME = SqlHelper.GetNullableString(reader, "CUST_NAME");

            if (reader.IsColumnExists("CUST_ADDRESS"))
                item.CUST_ADDRESS = SqlHelper.GetNullableString(reader, "CUST_ADDRESS");

            if (reader.IsColumnExists("CUST_EMAIL"))
                item.CUST_EMAIL = SqlHelper.GetNullableString(reader, "CUST_EMAIL");

            if (reader.IsColumnExists("CUST_CONTACT"))
                item.CUST_CONTACT = SqlHelper.GetNullableString(reader, "CUST_CONTACT");

            if (reader.IsColumnExists("CUST_TYPE"))
                item.CUST_TYPE = SqlHelper.GetNullableString(reader, "CUST_TYPE");

            if (reader.IsColumnExists("GSTIN"))
                item.GSTIN = SqlHelper.GetNullableString(reader, "GSTIN");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            if (reader.IsColumnExists("REMARKS"))
                item.REMARKS = SqlHelper.GetNullableString(reader, "REMARKS");

            if (reader.IsColumnExists("AGENT_CODE"))
                item.AGENT_CODE = SqlHelper.GetNullableString(reader, "AGENT_CODE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            return item;
        }
        public static CONTAINER_MASTER TranslateAsContainer(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new CONTAINER_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CONTAINER_NO"))
                item.CONTAINER_NO = SqlHelper.GetNullableString(reader, "CONTAINER_NO");

            if (reader.IsColumnExists("CONTAINER_TYPE"))
                item.CONTAINER_TYPE = SqlHelper.GetNullableString(reader, "CONTAINER_TYPE");

            if (reader.IsColumnExists("ONHIRE_DATE"))
                item.ONHIRE_DATE = SqlHelper.GetDateTime(reader, "ONHIRE_DATE");

            if (reader.IsColumnExists("ONHIRE_LOCATION"))
                item.ONHIRE_LOCATION = SqlHelper.GetNullableString(reader, "ONHIRE_LOCATION");

            if (reader.IsColumnExists("LEASED_FROM"))
                item.LEASED_FROM = SqlHelper.GetNullableString(reader, "LEASED_FROM");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            return item;
        }
        public static MASTER TranslateAsMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("KEY_NAME"))
                item.KEY_NAME = SqlHelper.GetNullableString(reader, "KEY_NAME");


            if (reader.IsColumnExists("CODE"))
                item.CODE = SqlHelper.GetNullableString(reader, "CODE");

            if (reader.IsColumnExists("CODE_DESC"))
                item.CODE_DESC = SqlHelper.GetNullableString(reader, "CODE_DESC");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            if (reader.IsColumnExists("PARENT_CODE"))
                item.PARENT_CODE = SqlHelper.GetNullableString(reader, "PARENT_CODE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("CREATED_DATE"))
                item.CREATED_DATE = SqlHelper.GetDateTime(reader, "CREATED_DATE");

            if (reader.IsColumnExists("UPDATED_BY"))
                item.UPDATED_BY = SqlHelper.GetNullableString(reader, "UPDATED_BY");

            if (reader.IsColumnExists("UPDATED_DATE"))
                item.UPDATED_DATE = SqlHelper.GetDateTime(reader, "UPDATED_DATE");

            return item;
        }

        public static VESSEL_MASTER TranslateAsVessel(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new VESSEL_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("VESSEL_NAME"))
                item.VESSEL_NAME = SqlHelper.GetNullableString(reader, "VESSEL_NAME");

            if (reader.IsColumnExists("IMO_NO"))
                item.IMO_NO = SqlHelper.GetNullableString(reader, "IMO_NO");

            if (reader.IsColumnExists("COUNTRY_CODE"))
                item.COUNTRY_CODE = SqlHelper.GetNullableString(reader, "COUNTRY_CODE");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            if (reader.IsColumnExists("VESSEL_CODE"))
                item.VESSEL_CODE = SqlHelper.GetNullableString(reader, "VESSEL_CODE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            //if (reader.IsColumnExists("CREATED_ON"))
            //    item.CREATED_ON = SqlHelper.GetDateTime(reader, "CREATED_ON");

            //if (reader.IsColumnExists("UPDATED_BY"))
            //    item.UPDATED_BY = SqlHelper.GetNullableString(reader, "UPDATED_BY");

            //if (reader.IsColumnExists("UPDATED_DATE"))
            //    item.UPDATED_DATE = SqlHelper.GetDateTime(reader, "UPDATED_DATE");

            return item;
        }

        public static SERVICE_MASTER TranslateAsService(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SERVICE_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("LINER_CODE"))
                item.LINER_CODE = SqlHelper.GetNullableString(reader, "LINER_CODE");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("SERVICE_NAME"))
                item.SERVICE_NAME = SqlHelper.GetNullableString(reader, "SERVICE_NAME");



            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

           

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            //if (reader.IsColumnExists("CREATED_ON"))
            //    item.CREATED_ON = SqlHelper.GetDateTime(reader, "CREATED_ON");

            //if (reader.IsColumnExists("UPDATED_BY"))
            //    item.UPDATED_BY = SqlHelper.GetNullableString(reader, "UPDATED_BY");

            //if (reader.IsColumnExists("UPDATED_DATE"))
            //    item.UPDATED_DATE = SqlHelper.GetDateTime(reader, "UPDATED_DATE");

            return item;
        }

        public static CONTAINER_TYPE TranslateAsContainerType(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new CONTAINER_TYPE();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CONT_TYPE_CODE"))
                item.CONT_TYPE_CODE = SqlHelper.GetNullableString(reader, "CONT_TYPE_CODE");

            if (reader.IsColumnExists("CONT_TYPE"))
                item.CONT_TYPE = SqlHelper.GetNullableString(reader, "CONT_TYPE");

            if (reader.IsColumnExists("CONT_SIZE"))
                item.CONT_SIZE = SqlHelper.GetNullableInt32(reader, "CONT_SIZE");

            if (reader.IsColumnExists("ISO_CODE"))
                item.ISO_CODE = SqlHelper.GetNullableString(reader, "ISO_CODE");


            if (reader.IsColumnExists("TEUS"))
                item.TEUS = SqlHelper.GetNullableInt32(reader, "TEUS");

            if (reader.IsColumnExists("OUT_DIM"))
                item.OUT_DIM = SqlHelper.GetNullableString(reader, "OUT_DIM");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");


            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

          
            return item;
        }

        public static LINER TranslateAsLiner(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new LINER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CODE"))
                item.CODE = SqlHelper.GetNullableString(reader, "CODE");

            if (reader.IsColumnExists("NAME"))
                item.NAME = SqlHelper.GetNullableString(reader, "NAME");

            if (reader.IsColumnExists("DESCRIPTION"))
                item.DESCRIPTION = SqlHelper.GetNullableString(reader, "DESCRIPTION");

           
            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");


            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");


            return item;
        }

        public static SERVICE TranslateAsLinerService(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SERVICE();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("LINER_CODE"))
                item.LINER_CODE = SqlHelper.GetNullableString(reader, "LINER_CODE");

            if (reader.IsColumnExists("SERVICE_NAME"))
                item.SERVICE_NAME = SqlHelper.GetNullableString(reader, "SERVICE_NAME");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");


            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");


            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");


            return item;
        }

        public static SCHEDULE TranslateAsSchedule(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SCHEDULE();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("VESSEL_NAME"))
                item.VESSEL_NAME = SqlHelper.GetNullableString(reader, "VESSEL_NAME");

            if (reader.IsColumnExists("SERVICE_NAME"))
                item.SERVICE_NAME = SqlHelper.GetNullableString(reader, "SERVICE_NAME");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("VIA_NO"))
                item.VIA_NO = SqlHelper.GetNullableString(reader, "VIA_NO");

            if (reader.IsColumnExists("ETA"))
                item.ETA = SqlHelper.GetDateTime(reader, "ETA");

            if (reader.IsColumnExists("ETD"))
                item.ETD = SqlHelper.GetDateTime(reader, "ETD");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");


            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");


            return item;
        }

        public static VOYAGE TranslateAsVoyage(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new VOYAGE();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("VESSEL_NAME"))
                item.VESSEL_NAME = SqlHelper.GetNullableString(reader, "VESSEL_NAME");

            if (reader.IsColumnExists("VOYAGE_NO"))
                item.VOYAGE_NO = SqlHelper.GetNullableString(reader, "VOYAGE_NO");

            if (reader.IsColumnExists("ATA"))
                item.ATA = SqlHelper.GetDateTime(reader, "ATA");

            if (reader.IsColumnExists("ATD"))
                item.ATD = SqlHelper.GetDateTime(reader, "ATD");

            if (reader.IsColumnExists("TERMINAL_CODE"))
                item.TERMINAL_CODE = SqlHelper.GetNullableString(reader, "TERMINAL_CODE");

            if (reader.IsColumnExists("SERVICE_NAME"))
                item.SERVICE_NAME = SqlHelper.GetNullableString(reader, "SERVICE_NAME");

            if (reader.IsColumnExists("VIA_NO"))
                item.VIA_NO = SqlHelper.GetNullableString(reader, "VIA_NO");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("ETA"))
                item.ETA = SqlHelper.GetDateTime(reader, "ETA");

            if (reader.IsColumnExists("ETD"))
                item.ETD = SqlHelper.GetDateTime(reader, "ETD");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            return item;
        }

        public static FREIGHT_MASTER TranslateAsFreightMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new FREIGHT_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("POL"))
                item.POL = SqlHelper.GetNullableString(reader, "POL");

            if (reader.IsColumnExists("POD"))
                item.POD = SqlHelper.GetNullableString(reader, "POD");

            if (reader.IsColumnExists("Charge"))
                item.Charge = SqlHelper.GetNullableString(reader, "Charge");

            if (reader.IsColumnExists("Currency"))
                item.Currency = SqlHelper.GetNullableString(reader, "Currency");

            if (reader.IsColumnExists("LadenStatus"))
                item.LadenStatus = SqlHelper.GetNullableString(reader, "LadenStatus");

            if (reader.IsColumnExists("ServiceMode"))
                item.ServiceMode = SqlHelper.GetNullableString(reader, "ServiceMode");

            if (reader.IsColumnExists("DRY20"))
                item.DRY20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "DRY20"));

            return item;
        }
    }
}
