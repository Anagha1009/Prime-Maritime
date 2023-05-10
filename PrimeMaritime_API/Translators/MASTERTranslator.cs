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
        public static CHARGE_MASTER TranslateAsChargeMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new CHARGE_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("POL"))
                item.POL = SqlHelper.GetNullableString(reader, "POL");

            if (reader.IsColumnExists("CHARGE_CODE"))
                item.CHARGE_CODE = SqlHelper.GetNullableString(reader, "CHARGE_CODE");

            if (reader.IsColumnExists("IMPCOST20"))
                item.IMPCOST20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "IMPCOST20"));

            if (reader.IsColumnExists("IMPCOST40"))
                item.IMPCOST40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "IMPCOST40"));

            if (reader.IsColumnExists("IMPINCOME20"))
                item.IMPINCOME20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "IMPINCOME20"));

            if (reader.IsColumnExists("IMPINCOME40"))
                item.IMPINCOME40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "IMPINCOME40"));

            if (reader.IsColumnExists("EXPCOST20"))
                item.EXPCOST20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "EXPCOST20"));

            if (reader.IsColumnExists("EXPCOST40"))
                item.EXPCOST40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "EXPCOST40"));

            if (reader.IsColumnExists("EXPINCOME20"))
                item.EXPINCOME20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "EXPINCOME20"));

            if (reader.IsColumnExists("EXPINCOME40"))
                item.EXPINCOME40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "EXPINCOME40"));

            if (reader.IsColumnExists("CURRENCY"))
                item.CURRENCY = SqlHelper.GetNullableString(reader, "CURRENCY");

            if (reader.IsColumnExists("FROM_VAL"))
                item.FROM_VAL = SqlHelper.GetNullableInt32(reader, "FROM_VAL");

            if (reader.IsColumnExists("TO_VAL"))
                item.TO_VAL = SqlHelper.GetNullableInt32(reader, "TO_VAL");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            return item;
        }
        public static STEV_MASTER TranslateAsStevMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new STEV_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("IE_TYPE"))
                item.IE_TYPE = SqlHelper.GetNullableString(reader, "IE_TYPE");

            if (reader.IsColumnExists("POL"))
                item.POL = SqlHelper.GetNullableString(reader, "POL");

            if (reader.IsColumnExists("CHARGE_CODE"))
                item.CHARGE_CODE = SqlHelper.GetNullableString(reader, "CHARGE_CODE");

            if (reader.IsColumnExists("TERMINAL"))
                item.TERMINAL = SqlHelper.GetNullableString(reader, "TERMINAL");

            if (reader.IsColumnExists("CURRENCY"))
                item.CURRENCY = SqlHelper.GetNullableString(reader, "CURRENCY");

            if (reader.IsColumnExists("LADEN_STATUS"))
                item.LADEN_STATUS = SqlHelper.GetNullableString(reader, "LADEN_STATUS");

            if (reader.IsColumnExists("SERVICE_MODE"))
                item.SERVICE_MODE = SqlHelper.GetNullableString(reader, "SERVICE_MODE");

            if (reader.IsColumnExists("DRY20"))
                item.DRY20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "DRY20"));

            if (reader.IsColumnExists("DRY40"))
                item.DRY40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "DRY40"));

            if (reader.IsColumnExists("DRY40HC"))
                item.DRY40HC = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "DRY40HC"));

            if (reader.IsColumnExists("DRY45"))
                item.DRY45 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "DRY45"));

            if (reader.IsColumnExists("RF20"))
                item.RF20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RF20"));

            if (reader.IsColumnExists("RF40"))
                item.RF40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RF40"));

            if (reader.IsColumnExists("RF40HC"))
                item.RF40HC = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RF40HC"));

            if (reader.IsColumnExists("RF45"))
                item.RF45 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RF45"));

            if (reader.IsColumnExists("HAZ20"))
                item.HAZ20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "HAZ20"));

            if (reader.IsColumnExists("HAZ40"))
                item.HAZ40 = Convert.ToDecimal(SqlHelper.GetNullableInt32(reader, "HAZ40"));

            if (reader.IsColumnExists("HAZ40HC"))
                item.HAZ40HC = Convert.ToDecimal(SqlHelper.GetBoolean(reader, "HAZ40HC"));

            if (reader.IsColumnExists("HAZ45"))
                item.HAZ45 = Convert.ToDecimal(SqlHelper.GetBoolean(reader, "HAZ45"));

            if (reader.IsColumnExists("SEQ20"))
                item.SEQ20 = Convert.ToDecimal(SqlHelper.GetBoolean(reader, "SEQ20"));

            if (reader.IsColumnExists("SEQ40"))
                item.SEQ40 = Convert.ToDecimal(SqlHelper.GetBoolean(reader, "SEQ40"));

            return item;
        }
        public static DETENTION_MASTER TranslateAsDetentionMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new DETENTION_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("CONTAINER_TYPE"))
                item.CONTAINER_TYPE = SqlHelper.GetNullableString(reader, "CONTAINER_TYPE");

            if (reader.IsColumnExists("CURRENCY"))
                item.CURRENCY = SqlHelper.GetNullableString(reader, "CURRENCY");

            if (reader.IsColumnExists("FROM_DAYS"))
                item.FROM_DAYS = SqlHelper.GetNullableInt32(reader, "FROM_DAYS");

            if (reader.IsColumnExists("TO_DAYS"))
                item.TO_DAYS = SqlHelper.GetNullableInt32(reader, "TO_DAYS");

            if (reader.IsColumnExists("20FT_RATE"))
                item.RATE20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "20FT_RATE"));

            if (reader.IsColumnExists("40FT_RATE"))
                item.RATE40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "40FT_RATE"));

            if (reader.IsColumnExists("HC_RATE"))
                item.HC_RATE = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "HC_RATE"));

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("CREATED_DATE"))
                item.CREATED_DATE = SqlHelper.GetDateTime(reader, "CREATED_DATE");

            return item;
        }
        public static MANDATORY_MASTER TranslateAsMandatoryMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new MANDATORY_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("ORG_CODE"))
                item.ORG_CODE = SqlHelper.GetNullableString(reader, "ORG_CODE");

            if (reader.IsColumnExists("CHARGE_CODE"))
                item.CHARGE_CODE = SqlHelper.GetNullableString(reader, "CHARGE_CODE");

            if (reader.IsColumnExists("IE_TYPE"))
                item.IE_TYPE = SqlHelper.GetNullableString(reader, "IE_TYPE");

            if (reader.IsColumnExists("LADEN_STATUS"))
                item.LADEN_STATUS = SqlHelper.GetNullableString(reader, "LADEN_STATUS");

            if (reader.IsColumnExists("CURRENCY"))
                item.CURRENCY = SqlHelper.GetNullableString(reader, "CURRENCY");

            if (reader.IsColumnExists("RATE20"))
                item.RATE20 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RATE20"));

            if (reader.IsColumnExists("RATE40"))
                item.RATE40 = Convert.ToDecimal(SqlHelper.GetNullableString(reader, "RATE40"));

            if (reader.IsColumnExists("IS_PERCENTAGE"))
                item.IS_PERCENTAGE = SqlHelper.GetBoolean(reader, "IS_PERCENTAGE");

            if (reader.IsColumnExists("PERCENTAGE_VALUE"))
                item.PERCENTAGE_VALUE = SqlHelper.GetNullableInt32(reader, "PERCENTAGE_VALUE");

            return item;
        }
        public static ORG_MASTER TranslateAsOrgMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new ORG_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("ORG_NAME"))
                item.ORG_NAME = SqlHelper.GetNullableString(reader, "ORG_NAME");

            if (reader.IsColumnExists("ORG_CODE"))
                item.ORG_CODE = SqlHelper.GetNullableString(reader, "ORG_CODE");

            if (reader.IsColumnExists("ORG_LOCATION"))
                item.ORG_LOCATION = SqlHelper.GetNullableString(reader, "ORG_LOCATION");

            if (reader.IsColumnExists("ORG_LOC_CODE"))
                item.ORG_LOC_CODE = SqlHelper.GetNullableString(reader, "ORG_LOC_CODE");

            if (reader.IsColumnExists("ORG_ADDRESS1"))
                item.ORG_ADDRESS1 = SqlHelper.GetNullableString(reader, "ORG_ADDRESS1");

            if (reader.IsColumnExists("CONTACT"))
                item.CONTACT = SqlHelper.GetNullableString(reader, "CONTACT");

            if (reader.IsColumnExists("FAX"))
                item.FAX = SqlHelper.GetNullableString(reader, "FAX");

            if (reader.IsColumnExists("EMAIL"))
                item.EMAIL = SqlHelper.GetNullableString(reader, "EMAIL");

            if (reader.IsColumnExists("COUNTRY_CODE"))
                item.COUNTRY_CODE = SqlHelper.GetNullableString(reader, "COUNTRY_CODE");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("CREATED_DATE"))
                item.CREATED_DATE = SqlHelper.GetDateTime(reader, "CREATED_DATE");

            return item;
        }
        public static SLOT_MASTER TranslateAsSlotMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SLOT_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("SLOT_OPERATOR"))
                item.SLOT_OPERATOR = SqlHelper.GetNullableString(reader, "SLOT_OPERATOR");

            if (reader.IsColumnExists("SERVICES"))
                item.SERVICES = SqlHelper.GetNullableString(reader, "SERVICES");

            if (reader.IsColumnExists("PORT_CODE"))
                item.PORT_CODE = SqlHelper.GetNullableString(reader, "PORT_CODE");

            if (reader.IsColumnExists("LINER_CODE"))
                item.LINER_CODE = SqlHelper.GetNullableString(reader, "LINER_CODE");

            if (reader.IsColumnExists("TERM"))
                item.TERM = SqlHelper.GetNullableString(reader, "TERM");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("CREATED_DATE"))
                item.CREATED_DATE = SqlHelper.GetDateTime(reader, "CREATED_DATE");

            return item;
        }
    }
}
