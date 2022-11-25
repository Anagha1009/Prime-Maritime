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

            if (reader.IsColumnExists("CONTAINER_SIZE"))
                item.CONTAINER_SIZE = SqlHelper.GetNullableString(reader, "CONTAINER_SIZE");

            if (reader.IsColumnExists("ON_HIRE_DATE"))
                item.ON_HIRE_DATE = SqlHelper.GetDateTime(reader, "ON_HIRE_DATE");

            if (reader.IsColumnExists("OFF_HIRE_DATE"))
                item.OFF_HIRE_DATE = SqlHelper.GetDateTime(reader, "OFF_HIRE_DATE");

            if (reader.IsColumnExists("MANUFACTURING_DATE"))
                item.MANUFACTURING_DATE = SqlHelper.GetDateTime(reader, "MANUFACTURING_DATE");

            if (reader.IsColumnExists("OWNER_NAME"))
                item.OWNER_NAME = SqlHelper.GetNullableString(reader, "OWNER_NAME");

            if (reader.IsColumnExists("LESSOR_NAME"))
                item.LESSOR_NAME = SqlHelper.GetNullableString(reader, "LESSOR_NAME");

            if (reader.IsColumnExists("PICKUP_LOCATION"))
                item.PICKUP_LOCATION = SqlHelper.GetNullableString(reader, "PICKUP_LOCATION");

            if (reader.IsColumnExists("DROP_LOCATION"))
                item.DROP_LOCATION = SqlHelper.GetNullableString(reader, "DROP_LOCATION");










            return item;
        }

        public static SIZE TranslateAsContainerSize(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SIZE();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CONT_SIZE"))
                item.CONT_SIZE = SqlHelper.GetNullableString(reader, "CONT_SIZE");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            if (reader.IsColumnExists("CREATED_BY"))
                item.CREATED_BY = SqlHelper.GetNullableString(reader, "CREATED_BY");

            if (reader.IsColumnExists("UPDATED_BY"))
                item.UPDATED_BY = SqlHelper.GetNullableString(reader, "UPDATED_BY");

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
    }
}
