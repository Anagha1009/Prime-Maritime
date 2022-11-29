using Newtonsoft.Json;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class MasterRepo
    {

        #region "PARTY MASTER"
        public void InsertPartyMaster(string connstring, PARTY_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_CUSTOMER" },
                  new SqlParameter("@CUST_NAME", SqlDbType.VarChar,50) { Value = master.CUST_NAME},
                  new SqlParameter("@CUST_ADDRESS", SqlDbType.VarChar, 100) { Value = master.CUST_ADDRESS },
                  new SqlParameter("@CUST_EMAIL", SqlDbType.VarChar, 50) { Value = master.CUST_EMAIL },
                  new SqlParameter("@CUST_CONTACT", SqlDbType.VarChar, 20) { Value = master.CUST_CONTACT },
                  new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,10) { Value = master.CUST_TYPE },
                  new SqlParameter("@GSTIN", SqlDbType.VarChar,15) { Value = master.GSTIN },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                  new SqlParameter("@REMARKS", SqlDbType.VarChar, 200) { Value = master.REMARKS },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 100) { Value = master.AGENT_CODE },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,100) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PARTY_MASTER> GetPartyMasterList(string dbConn, string AgentCode)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CUSTOMERLIST" },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AgentCode },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_MASTER", parameters);
                List<PARTY_MASTER> master = SqlHelper.CreateListFromTable<PARTY_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public PARTY_MASTER GetPartyMasterDetails(string connstring, string AGENT_CODE, int CUSTOMER_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
                  new SqlParameter("@CUST_ID", SqlDbType.Int) { Value = CUSTOMER_ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_CUSTOMERDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<PARTY_MASTER>(connstring, "SP_CRUD_MASTER", r => r.TranslateAsCustomer(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeletePartyMasterDetails(string connstring, string AGENT_CODE, int CUSTOMER_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE },
                  new SqlParameter("@CUST_ID", SqlDbType.Int) { Value = CUSTOMER_ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_CUSTOMER" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdatePartyMasterDetails(string connstring, PARTY_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_CUSTOMER" },
                  new SqlParameter("@CUST_NAME", SqlDbType.VarChar,50) { Value = master.CUST_NAME},
                  new SqlParameter("@CUST_ADDRESS", SqlDbType.VarChar, 100) { Value = master.CUST_ADDRESS },
                  new SqlParameter("@CUST_EMAIL", SqlDbType.VarChar, 50) { Value = master.CUST_EMAIL },
                  new SqlParameter("@CUST_CONTACT", SqlDbType.VarChar, 20) { Value = master.CUST_CONTACT },
                  new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,10) { Value = master.CUST_TYPE },
                  new SqlParameter("@GSTIN", SqlDbType.VarChar,15) { Value = master.GSTIN },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = master.AGENT_CODE },
                  new SqlParameter("@CUST_ID", SqlDbType.Int) { Value = master.CUST_ID },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region "CONTAINER MASTER"
        public void InsertContainerMaster(string connstring, CONTAINER_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_CONTAINER" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,20) { Value = master.CONTAINER_NO},
                  new SqlParameter("@CONTAINER_TYPE", SqlDbType.VarChar, 50) { Value = master.CONTAINER_TYPE },
                  new SqlParameter("@CONTAINER_SIZE", SqlDbType.VarChar, 20) { Value = master.CONTAINER_SIZE },
                  new SqlParameter("@IS_OWNED", SqlDbType.Bit) { Value = master.IS_OWNED },
                  new SqlParameter("@ON_HIRE_DATE", SqlDbType.DateTime) { Value = master.ON_HIRE_DATE },
                  new SqlParameter("@OFF_HIRE_DATE", SqlDbType.DateTime) { Value = master.OFF_HIRE_DATE },
                  new SqlParameter("@MANUFACTURING_DATE", SqlDbType.DateTime) { Value = master.MANUFACTURING_DATE},
                  new SqlParameter("@SHIPPER_OWNED", SqlDbType.Bit) { Value = master.SHIPPER_OWNED },
                  new SqlParameter("@OWNER_NAME", SqlDbType.VarChar, 255) { Value = master.OWNER_NAME },
                  new SqlParameter("@LESSOR_NAME", SqlDbType.VarChar,255) { Value = master.LESSOR_NAME },
                  new SqlParameter("@PICKUP_LOCATION", SqlDbType.VarChar,255) { Value = master.PICKUP_LOCATION },
                  new SqlParameter("@DROP_LOCATION", SqlDbType.VarChar,255) { Value = master.DROP_LOCATION },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },
                  new SqlParameter("@CREATED_DATE", SqlDbType.DateTime) { Value = master.CREATED_DATE },
                  new SqlParameter("@UPDATED_BY", SqlDbType.VarChar,255) { Value = master.UPDATED_BY },
                  new SqlParameter("@UPDATED_DATE", SqlDbType.DateTime) { Value = master.UPDATED_DATE },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MASTER", parameters);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CONTAINER_MASTER> GetContainerMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_CONTAINERLIST" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CONTAINER_MASTER", parameters);
                List<CONTAINER_MASTER> master = SqlHelper.CreateListFromTable<CONTAINER_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public CONTAINER_MASTER GetContainerMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_CONTAINERDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<CONTAINER_MASTER>(connstring, "SP_CRUD_CONTAINER_MASTER", r => r.TranslateAsContainer(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateContainerMasterList(string connstring, CONTAINER_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_CONTAINER" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,20) { Value = master.CONTAINER_NO},
                  new SqlParameter("@CONTAINER_TYPE", SqlDbType.VarChar, 50) { Value = master.CONTAINER_TYPE },
                   new SqlParameter("@CONTAINER_SIZE", SqlDbType.VarChar, 20) { Value = master.CONTAINER_SIZE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@ON_HIRE_DATE", SqlDbType.DateTime) { Value = master.ON_HIRE_DATE },
                  new SqlParameter("@OFF_HIRE_DATE", SqlDbType.DateTime) { Value = master.OFF_HIRE_DATE },
                  new SqlParameter("@MANUFACTURING_DATE", SqlDbType.DateTime) { Value = master.MANUFACTURING_DATE },
                  new SqlParameter("@OWNER_NAME", SqlDbType.VarChar,255) { Value = master.OWNER_NAME },
                  new SqlParameter("@LESSOR_NAME", SqlDbType.VarChar,255) { Value = master.LESSOR_NAME },
                  new SqlParameter("@PICKUP_LOCATION", SqlDbType.VarChar,255) { Value = master.PICKUP_LOCATION },
                  new SqlParameter("@DROP_LOCATION", SqlDbType.VarChar,255) { Value = master.DROP_LOCATION },
                  new SqlParameter("@IS_OWNED", SqlDbType.Bit) { Value = master.IS_OWNED },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteContainerMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_CONTAINER" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "COMMON MASTER"
        public void InsertMaster(string connstring, MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_MASTER" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@KEY_NAME", SqlDbType.VarChar, 100) { Value = master.KEY_NAME },
                  new SqlParameter("@CODE", SqlDbType.VarChar, 255) { Value = master.CODE },
                  new SqlParameter("@CODE_DESC", SqlDbType.VarChar, 255) { Value = master.CODE_DESC },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@PARENT_CODE", SqlDbType.VarChar, 100) { Value = master.PARENT_CODE },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },
                  new SqlParameter("@CREATED_DATE", SqlDbType.DateTime) { Value = master.CREATED_DATE },
                  new SqlParameter("@UPDATED_BY", SqlDbType.VarChar,255) { Value = master.UPDATED_BY },
                  new SqlParameter("@UPDATED_DATE", SqlDbType.DateTime) { Value = master.UPDATED_DATE },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MASTER> GetMasterList(string dbConn, string key)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_MASTER_LIST" },
                  new SqlParameter("@KEY_NAME", SqlDbType.VarChar, 100) { Value =  key},

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_MASTER", parameters);
                List<MASTER> master = SqlHelper.CreateListFromTable<MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MASTER GetMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_MASTER_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<MASTER>(connstring, "SP_MASTER", r => r.TranslateAsMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateMaster(string connstring, MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_MASTER" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@KEY_NAME", SqlDbType.VarChar, 100) { Value = master.KEY_NAME},
                  new SqlParameter("@CODE", SqlDbType.VarChar, 255) { Value = master.CODE },
                  new SqlParameter("@CODE_DESC", SqlDbType.VarChar, 255) { Value = master.CODE_DESC },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@PARENT_CODE", SqlDbType.VarChar, 100) { Value = master.PARENT_CODE },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMaster(string connstring, int ID)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
               new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_MASTER" }
            };

            SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MASTER", parameters);
        }
        #endregion

        #region "VESSEL_MASTER"
        public void InsertVesselMaster(string connstring, VESSEL_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_VESSEEL" },
                  new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar,255) { Value = master.VESSEL_NAME},
                  new SqlParameter("@IMO_NO", SqlDbType.VarChar,11) { Value = master.IMO_NO},
                  new SqlParameter("@COUNTRY_CODE  ", SqlDbType.VarChar, 5) { Value = master.COUNTRY_CODE   },
                  new SqlParameter("@VESSEL_CODE", SqlDbType.VarChar, 8) { Value = master.VESSEL_CODE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<VESSEL_MASTER> GetVesselMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSELLIST" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_VESSEL_MASTER", parameters);
                List<VESSEL_MASTER> master = SqlHelper.CreateListFromTable<VESSEL_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public VESSEL_MASTER GetVesselMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSELDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<VESSEL_MASTER>(connstring, "SP_CRUD_VESSEL_MASTER", r => r.TranslateAsVessel(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateVesselMasterList(string connstring, VESSEL_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_VESSEL" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar,255) { Value = master.VESSEL_NAME},
                  new SqlParameter("@IMO_NO", SqlDbType.VarChar, 11) { Value = master.IMO_NO },
                   new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar, 5) { Value = master.COUNTRY_CODE },
                  new SqlParameter("@VESSEL_CODE", SqlDbType.VarChar,8) { Value = master.VESSEL_CODE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void DeleteVesselMasterList(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_VESSEL" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region "SERVICE MASTER"
        public void InsertServiceMaster(string connstring, SERVICE_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_SERVICE" },
                  new SqlParameter("@LINER_ID", SqlDbType.Int) { Value = master.LINER_ID},
                  new SqlParameter("@SERVICE_NAME", SqlDbType.VarChar,255) { Value = master.SERVICE_NAME},
                  new SqlParameter("@PORT_CODE  ", SqlDbType.VarChar, 100) { Value = master.PORT_CODE   },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SERVICE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public List<SERVICE_MASTER> GetServiceMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_SERVICELIST" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_SERVICE_MASTER", parameters);
                List<SERVICE_MASTER> master = SqlHelper.CreateListFromTable<SERVICE_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public SERVICE_MASTER GetServiceMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_SERVICEDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<SERVICE_MASTER>(connstring, "SP_CRUD_SERVICE_MASTER", r => r.TranslateAsService(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateServiceMasterList(string connstring, SERVICE_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_SERVICE" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID },
                  new SqlParameter("@LINER_ID", SqlDbType.Int) { Value = master.LINER_ID},
                  new SqlParameter("@SERVICE_NAME", SqlDbType.VarChar,255) { Value = master.SERVICE_NAME},
                  new SqlParameter("@PORT_CODE  ", SqlDbType.VarChar, 100) { Value = master.PORT_CODE   },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SERVICE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteServiceMasterList(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_SERVICE" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SERVICE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


    }
}

