using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Response;

namespace PrimeMaritime_API.Repository
{
    public class BLRepo
    {
        public void InsertBL(string connstring, BL request)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "CREATE_BL" },
              new SqlParameter("@BL_NO", SqlDbType.VarChar, 50) { Value = request.BL_NO },
              new SqlParameter("@SRR_ID", SqlDbType.Int) { Value = request.SRR_ID },
              new SqlParameter("@SRR_NO", SqlDbType.VarChar, 50) { Value = request.SRR_NO },
              new SqlParameter("@SHIPPER", SqlDbType.VarChar, 50) { Value = request.SHIPPER },
              new SqlParameter("@SHIPPER_ADDRESS", SqlDbType.VarChar, 255) { Value = request.SHIPPER_ADDRESS },
              new SqlParameter("@CONSIGNEE", SqlDbType.VarChar, 50) { Value = request.CONSIGNEE },
              new SqlParameter("@CONSIGNEE_ADDRESS", SqlDbType.VarChar, 255) { Value = request.CONSIGNEE_ADDRESS },
              new SqlParameter("@NOTIFY_PARTY", SqlDbType.VarChar, 50) { Value = request.NOTIFY_PARTY },
              new SqlParameter("@NOTIFY_PARTY_ADDRESS", SqlDbType.VarChar,255) { Value = request.NOTIFY_PARTY_ADDRESS },
              new SqlParameter("@PRE_CARRIAGE_BY", SqlDbType.VarChar,50) { Value = request.PRE_CARRIAGE_BY },
              new SqlParameter("@PLACE_OF_RECEIPT", SqlDbType.VarChar,255) { Value = request.PLACE_OF_RECEIPT },
              new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar,255) { Value = request.VESSEL_NAME },
              new SqlParameter("@VOYAGE_NO", SqlDbType.VarChar,50) { Value = request.VOYAGE_NO },
              new SqlParameter("@PORT_OF_LOADING", SqlDbType.VarChar,255) { Value = request.PORT_OF_LOADING },
              new SqlParameter("@PORT_OF_DISCHARGE", SqlDbType.VarChar,255) { Value = request.PORT_OF_DISCHARGE },
              new SqlParameter("@PLACE_OF_DELIVERY", SqlDbType.VarChar,255) { Value = request.PLACE_OF_DELIVERY },
              new SqlParameter("@BL_ISSUE_PLACE", SqlDbType.VarChar,100) { Value = request.BL_ISSUE_PLACE },
              new SqlParameter("@BL_ISSUE_DATE", SqlDbType.DateTime) { Value = request.BL_ISSUE_DATE },
              new SqlParameter("@NO_OF_ORIGINAL_BL", SqlDbType.Int) { Value = request.NO_OF_ORIGINAL_BL },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,20) { Value = request.AGENT_CODE },
              new SqlParameter("@AGENT_NAME", SqlDbType.VarChar,255) { Value = request.AGENT_NAME },
              new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = request.CREATED_BY },
            };

            var BLNO = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_BL", parameters);

            foreach (var i in request.CONTAINER_LIST)
            {
                i.BL_NO = request.BL_NO;
            }

            string[] columns = new string[12];
            columns[0] = "BL_NO";
            columns[1] = "CONTAINER_NO";
            columns[2] = "CONTAINER_TYPE";
            columns[3] = "CONTAINER_SIZE";
            columns[4] = "SEAL_NO";
            columns[5] = "MARKS_NOS";
            columns[6] = "DESC_OF_GOODS";
            columns[7] = "GROSS_WEIGHT";
            columns[8] = "MEASUREMENT";
            columns[9] = "AGENT_CODE";
            columns[10] = "AGENT_NAME";
            columns[11] = "CREATED_BY";

            SqlHelper.UpdateData<CONTAINERS>(request.CONTAINER_LIST, "TB_CONTAINER", connstring, columns);
        }
        public DataSet GetBLData(string connstring, string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_BLDETAILS" },
                new SqlParameter("@BL_NO", SqlDbType.VarChar, 100) { Value = BL_NO },
                new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
                new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
            };

            return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_BL", parameters);
        }
        public DataSet GetSRRDetails(string connstring, string BL_NO, string BOOKING_NO, string AGENT_CODE)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_SRRDETAILS" },
              new SqlParameter("@BL_NO", SqlDbType.VarChar, 100) { Value = BL_NO },
              new SqlParameter("@BOOKING_NO", SqlDbType.VarChar, 100) { Value = BOOKING_NO },
              new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },

            };

            return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_BL", parameters);
        }
        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }

        public List<CONTAINERS> GetContainerList(string connstring, string AGENT_CODE, string BOOKING_NO, string CRO_NO, string BL_NO, string DO_NO, bool fromDO)
        {

            if (fromDO == true)
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CONTAINERLISTFORDO" },
                   new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,50) { Value = AGENT_CODE },
                   new SqlParameter("@BL_NO", SqlDbType.VarChar,50) { Value = BL_NO }
                 };
                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_BL", parameters);
                List<CONTAINERS> containerList = SqlHelper.CreateListFromTable<CONTAINERS>(dataTable);
                return containerList;
            }
            else
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CONTAINERLIST" },
                    new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,50) { Value = AGENT_CODE },
                    new SqlParameter("@BOOKING_NO", SqlDbType.VarChar,100) { Value = BOOKING_NO },
                    new SqlParameter("@CRO_NO", SqlDbType.VarChar,100) { Value = CRO_NO },
                    new SqlParameter("@BL_NO", SqlDbType.VarChar,50) { Value = BL_NO },
                    new SqlParameter("@DO_NO", SqlDbType.VarChar,100) { Value = DO_NO }
                };
                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(connstring, "SP_CRUD_BL", parameters);
                List<CONTAINERS> containerList = SqlHelper.CreateListFromTable<CONTAINERS>(dataTable);
                return containerList;

            }

        }

        public DataSet CargoManifestData(string connstring,string AGENT_CODE, string BL_NO)
        {
            try
            {
                SqlParameter[] parameters =
{
                   new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "GET_CARGO_MANIFEST_LIST" },
                   new SqlParameter("@AGENT_CODE", SqlDbType.VarChar,50) { Value = AGENT_CODE },
                   new SqlParameter("@BL_NO", SqlDbType.VarChar,50) { Value = BL_NO }
                 };
        
                return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_CRUD_BL", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
