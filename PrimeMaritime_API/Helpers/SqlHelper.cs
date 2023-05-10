using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Helpers
{
    public static class SqlHelper
    {
        public static string ExecuteProcedureReturnString(string connString, string procName,
            params SqlParameter[] paramters)
        {
            string result = "";
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    var ret = command.ExecuteScalar();
                    if (ret != null)
                        result = Convert.ToString(ret);
                }
            }
            return result;
        }

        public static void ExecuteProcedureBulkInsert(string connString, DataTable dataTable, string tblName, string[] columns)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                objbulk.DestinationTableName = tblName;
                foreach(var i in columns)
                {
                    objbulk.ColumnMappings.Add(i, i);
                }
                sqlConnection.Open();
                objbulk.WriteToServer(dataTable);
            }
        }

        public static void UpdateContainerDataForBL<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_CONTAINER");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(BL_NO varchar(100),CONTAINER_NO varchar(20),CONTAINER_TYPE varchar(50),SEAL_NO varchar(50),AGENT_SEAL_NO varchar(50),MARKS_NOS varchar(max),DESC_OF_GOODS varchar(max),PKG_COUNT int,PKG_DESC varchar(max),GROSS_WEIGHT numeric(18,2),NET_WEIGHT numeric(18,2),MEASUREMENT varchar(50))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET BL_NO = Temp.BL_NO,CONTAINER_NO= Temp.CONTAINER_NO,CONTAINER_TYPE= Temp.CONTAINER_TYPE,SEAL_NO= Temp.SEAL_NO,AGENT_SEAL_NO= Temp.AGENT_SEAL_NO,MARKS_NOS= Temp.MARKS_NOS,DESC_OF_GOODS= Temp.DESC_OF_GOODS,PKG_COUNT= Temp.PKG_COUNT,PKG_DESC= Temp.PKG_DESC,GROSS_WEIGHT= Temp.GROSS_WEIGHT,NET_WEIGHT= Temp.NET_WEIGHT,MEASUREMENT= Temp.MEASUREMENT FROM " +
                             TableName + " T INNER JOIN #TmpTable Temp ON T.CONTAINER_NO = Temp.CONTAINER_NO and T.BL_NO = Temp.BL_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static void UpdateBL<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_BL");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();
                        
                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(BL_NO varchar(50),SHIPPER varchar(50),SHIPPER_ADDRESS varchar(255),CONSIGNEE varchar(50),CONSIGNEE_ADDRESS varchar(255),NOTIFY_PARTY varchar(50),NOTIFY_PARTY_ADDRESS varchar(255),PRE_CARRIAGE_BY varchar(50),PLACE_OF_RECEIPT varchar(255),VESSEL_NAME varchar(255),VOYAGE_NO varchar(50)," +
                            "PORT_OF_LOADING varchar(255),PORT_OF_DISCHARGE varchar(255),PLACE_OF_DELIVERY varchar(255),FINAL_DESTINATION varchar(255),PREPAID_AT varchar(255),PAYABLE_AT varchar(255),BL_ISSUE_PLACE varchar(100),BL_ISSUE_DATE datetime,TOTAL_PREPAID decimal,NO_OF_ORIGINAL_BL int,BL_STATUS varchar(20))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET BL_NO = Temp.BL_NO,SHIPPER = Temp.SHIPPER,SHIPPER_ADDRESS= Temp.SHIPPER_ADDRESS,CONSIGNEE= Temp.CONSIGNEE,CONSIGNEE_ADDRESS= Temp.CONSIGNEE_ADDRESS,NOTIFY_PARTY= Temp.NOTIFY_PARTY,NOTIFY_PARTY_ADDRESS= Temp.NOTIFY_PARTY_ADDRESS,PRE_CARRIAGE_BY= Temp.PRE_CARRIAGE_BY,PLACE_OF_RECEIPT= Temp.PLACE_OF_RECEIPT,VESSEL_NAME= Temp.VESSEL_NAME," +
                            "VOYAGE_NO= Temp.VOYAGE_NO,PORT_OF_LOADING= Temp.PORT_OF_LOADING,PORT_OF_DISCHARGE= Temp.PORT_OF_DISCHARGE,PLACE_OF_DELIVERY= Temp.PLACE_OF_DELIVERY,FINAL_DESTINATION= Temp.FINAL_DESTINATION,PREPAID_AT=Temp.PREPAID_AT,PAYABLE_AT=Temp.PAYABLE_AT,BL_ISSUE_PLACE=Temp.BL_ISSUE_PLACE,BL_ISSUE_DATE=Temp.BL_ISSUE_DATE,TOTAL_PREPAID=Temp.TOTAL_PREPAID,NO_OF_ORIGINAL_BL=Temp.NO_OF_ORIGINAL_BL,BL_STATUS=Temp.BL_STATUS FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.BL_NO = Temp.BL_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateData<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_CONTAINER");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(BL_NO varchar(100),BOOKING_NO varchar(100),CRO_NO varchar(100),DO_NO varchar(100),CONTAINER_NO varchar(20),CONTAINER_TYPE varchar(50),CONTAINER_SIZE varchar(50),SEAL_NO varchar(50),MARKS_NOS varchar(max),DESC_OF_GOODS varchar(max),PKG_COUNT int,PKG_DESC varchar(max),GROSS_WEIGHT numeric(18,2),NET_WEIGHT numeric(18,2),MEASUREMENT varchar(50)," +
                            "AGENT_CODE varchar(20),AGENT_NAME varchar(255),CREATED_BY varchar(255))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET BL_NO = Temp.BL_NO,BOOKING_NO = Temp.BOOKING_NO,CRO_NO = Temp.CRO_NO,DO_NO = Temp.DO_NO,CONTAINER_NO= Temp.CONTAINER_NO,CONTAINER_TYPE= Temp.CONTAINER_TYPE,CONTAINER_SIZE= Temp.CONTAINER_SIZE,SEAL_NO= Temp.SEAL_NO,MARKS_NOS= Temp.MARKS_NOS,DESC_OF_GOODS= Temp.DESC_OF_GOODS,PKG_COUNT= Temp.PKG_COUNT,PKG_DESC= Temp.PKG_DESC,GROSS_WEIGHT= Temp.GROSS_WEIGHT,NET_WEIGHT= Temp.NET_WEIGHT,MEASUREMENT= Temp.MEASUREMENT," +
                            "AGENT_CODE= Temp.AGENT_CODE,AGENT_NAME= Temp.AGENT_NAME,CREATED_BY= Temp.CREATED_BY FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.CONTAINER_NO = Temp.CONTAINER_NO and T.BOOKING_NO = Temp.BOOKING_NO and T.CRO_NO = Temp.CRO_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateDataDO<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_CONTAINER");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(BL_NO varchar(100),DO_NO varchar(100),CONTAINER_NO varchar(20))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET DO_NO = Temp.DO_NO" +
                            " FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.CONTAINER_NO = Temp.CONTAINER_NO and T.BL_NO = Temp.BL_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateCMData<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_CONTAINER_MOVEMENT");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(BOOKING_NO varchar(100),CRO_NO varchar(100),CONTAINER_NO varchar(100),ACTIVITY varchar(50),PREV_ACTIVITY varchar(50),ACTIVITY_DATE datetime,LOCATION varchar(100),CURRENT_LOCATION varchar(100),STATUS varchar(50),AGENT_CODE varchar(20),DEPO_CODE varchar(20)," +
                            "CREATED_BY varchar(255))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET BOOKING_NO = Temp.BOOKING_NO,CRO_NO = Temp.CRO_NO,CONTAINER_NO= Temp.CONTAINER_NO,ACTIVITY= Temp.ACTIVITY,PREV_ACTIVITY= Temp.PREV_ACTIVITY,ACTIVITY_DATE= Temp.ACTIVITY_DATE,LOCATION= Temp.LOCATION,CURRENT_LOCATION= Temp.CURRENT_LOCATION,STATUS= Temp.STATUS,AGENT_CODE= Temp.AGENT_CODE,DEPO_CODE= Temp.DEPO_CODE," +
                            "CREATED_BY= Temp.CREATED_BY FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.CONTAINER_NO = Temp.CONTAINER_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateContainerMovement<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_CONTAINER_MOVEMENT");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(BOOKING_NO varchar(100),CRO_NO varchar(100),CONTAINER_NO varchar(100),CURR_ACT_CODE varchar(50),ACTIVITY_DATE datetime,LOCATION varchar(100),CURRENT_LOCATION varchar(100),STATUS varchar(50))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET BOOKING_NO = ISNULL(Temp.BOOKING_NO, T.BOOKING_NO),CRO_NO = ISNULL(Temp.CRO_NO, T.CRO_NO),CONTAINER_NO= Temp.CONTAINER_NO,ACTIVITY= Temp.CURR_ACT_CODE,PREV_ACTIVITY= T.ACTIVITY,ACTIVITY_DATE= Temp.ACTIVITY_DATE,LOCATION= Temp.LOCATION,STATUS= Temp.STATUS" +
                            " FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.CONTAINER_NO = Temp.CONTAINER_NO AND (T.BOOKING_NO = Temp.BOOKING_NO OR T.CRO_NO = Temp.CRO_NO); DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public static void UpdateSRR<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_SRR");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(SRR_NO varchar(50), STATUS varchar(50))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET STATUS = Temp.STATUS FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.SRR_NO = Temp.SRR_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateSRRRates<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_SRR_RATES");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(SRR_NO varchar(50), APPROVED_RATE decimal, STATUS varchar(50), REMARKS varchar(255),AGENT_REMARKS varchar(255), CREATED_BY varchar(255))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET APPROVED_RATE = Temp.APPROVED_RATE, STATUS = Temp.STATUS, REMARKS = Temp.REMARKS,AGENT_REMARKS = Temp.AGENT_REMARKS, CREATED_BY = Temp.CREATED_BY FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.SRR_NO = Temp.SRR_NO; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateSRRData<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_SRR_RATES");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(SRR_NO varchar(50), CONTAINER_TYPE varchar(100), CHARGE_CODE varchar(100), APPROVED_RATE decimal, STATUS varchar(50), REMARKS varchar(255),AGENT_REMARKS varchar(255), CREATED_BY varchar(255), RATE_TYPE varchar(20))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET APPROVED_RATE = Temp.APPROVED_RATE, STATUS = Temp.STATUS, REMARKS = Temp.REMARKS,AGENT_REMARKS = Temp.AGENT_REMARKS, CREATED_BY = Temp.CREATED_BY FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.SRR_NO = Temp.SRR_NO AND T.CHARGE_CODE = Temp.CHARGE_CODE AND T.CONTAINER_TYPE = Temp.CONTAINER_TYPE AND T.RATE_TYPE = Temp.RATE_TYPE; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateSRRContainer<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_SRR_CONTAINERS");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(SRR_NO varchar(50), CONTAINER_TYPE varchar(100),IMM_VOLUME_EXPECTED int)";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET IMM_VOLUME_EXPECTED += Temp.IMM_VOLUME_EXPECTED FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.SRR_NO = Temp.SRR_NO AND T.CONTAINER_TYPE = Temp.CONTAINER_TYPE; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static void UpdateSRRCounterData<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_SRR_RATES");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(SRR_NO varchar(50), CONTAINER_TYPE varchar(100), CHARGE_CODE varchar(100), RATE_REQUESTED decimal,STATUS varchar(50), REMARKS varchar(255),AGENT_REMARKS varchar(255), CREATED_BY varchar(255), RATE_TYPE varchar(20))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET RATE_REQUESTED = Temp.RATE_REQUESTED,STATUS = Temp.STATUS, REMARKS = Temp.REMARKS, AGENT_REMARKS = Temp.AGENT_REMARKS, CREATED_BY = Temp.CREATED_BY FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.SRR_NO = Temp.SRR_NO AND T.CHARGE_CODE = Temp.CHARGE_CODE AND T.CONTAINER_TYPE = Temp.CONTAINER_TYPE AND T.RATE_TYPE = Temp.RATE_TYPE; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public static TData ExtecuteProcedureReturnData<TData>(string connString, string procName,
            Func<SqlDataReader, TData> translator,
            params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult()) { }
                        }
                        return elements;
                    }
                }
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ExtecuteProcedureReturnDataTable(string connString, string procName,
            params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }

                    sqlConnection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            dataAdapter.Fill(dt);
                            return dt;
                        }
                    }
                    
                }
            }
        }

        public static DataSet ExtecuteProcedureReturnDataSet(string connString, string procName,            
            params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }

                    sqlConnection.Open();

                    DataSet ds = new DataSet();
                    var adapter = new SqlDataAdapter(sqlCommand);

                    adapter.Fill(ds);
                    return ds;
                }
            }
        }

        public static List<T> CreateListFromTable<T>(DataTable tbl) where T : new()
        {
            // define return list
            List<T> lst = new List<T>();

            // go through each row
            foreach (DataRow r in tbl.Rows)
            {
                // add to the list
                lst.Add(CreateItemFromRow<T>(r));
            }

            // return the list
            return lst;
        }

        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            // create a new object
            T item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }

        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {
                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);

                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, row[c], null);
                }
            }
        }

        public static void UpdateMRData<T>(List<T> list, string TableName, string connString, string[] columns)
        {
            DataTable dt = new DataTable("TB_MR_REQUEST");
            dt = ConvertToDataTable(list);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand("", conn))
                {
                    try
                    {
                        conn.Open();

                        //Creating temp table on database
                        command.CommandText = "CREATE TABLE #TmpTable(MR_NO VARCHAR(100), LOCATION VARCHAR(100), TAX decimal(18,2), FINAL_TOTAL decimal(18,2), REMARKS VARCHAR(MAX), STATUS VARCHAR(50))";
                        command.ExecuteNonQuery();

                        //Bulk insert into temp table
                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 660;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            foreach (var i in columns)
                            {
                                bulkcopy.ColumnMappings.Add(i, i);
                            }
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }

                        // Updating destination table, and dropping temp table
                        command.CommandTimeout = 300;
                        command.CommandText = "UPDATE T SET TAX = Temp.TAX, FINAL_TOTAL = Temp.FINAL_TOTAL, REMARKS = Temp.REMARKS, STATUS = Temp.STATUS FROM " + TableName + " T INNER JOIN #TmpTable Temp ON T.MR_NO = Temp.MR_NO AND T.LOCATION = Temp.LOCATION; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception )
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }


        ///Methods to get values of
        ///individual columns from sql data reader
        #region Get Values from Sql Data Reader
        public static string GetNullableString(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }

        public static int GetNullableInt32(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        public static bool GetBoolean(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(bool) : Convert.ToBoolean(reader[colName]);
        }

        public static DateTime GetDateTime(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(DateTime) : Convert.ToDateTime(reader[colName]);
        }

        //this method is to check wheater column exists or not in data reader
        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
        {
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
