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
                  new SqlParameter("@CUST_NAME", SqlDbType.VarChar,500) { Value = master.CUST_NAME},
                  new SqlParameter("@CUST_ADDRESS", SqlDbType.VarChar, 500) { Value = master.CUST_ADDRESS },
                  new SqlParameter("@CUST_EMAIL", SqlDbType.VarChar, 50) { Value = master.CUST_EMAIL },
                  new SqlParameter("@CUST_CONTACT", SqlDbType.VarChar, 20) { Value = master.CUST_CONTACT },
                  new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,100) { Value = master.CUST_TYPE },
                  new SqlParameter("@GSTIN", SqlDbType.VarChar,15) { Value = master.GSTIN },
                  new SqlParameter("@VAT_NO", SqlDbType.VarChar,30) { Value = master.VAT_NO },
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

        public List<PARTY_MASTER> GetPartyMasterList(string dbConn, string AgentCode, string CustName, string CustType, bool Status, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CUSTOMERLIST" },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AgentCode },
                  new SqlParameter("@CUST_NAME", SqlDbType.VarChar, 255) { Value = CustName },
                  new SqlParameter("@CUST_TYPE", SqlDbType.VarChar, 10) { Value = CustType },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = Status },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },

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

        public void DeletePartyMasterDetails(string connstring, int CUSTOMER_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
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
                  new SqlParameter("@CUST_TYPE", SqlDbType.VarChar,100) { Value = master.CUST_TYPE },
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
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@ONHIRE_DATE", SqlDbType.DateTime) { Value = master.ONHIRE_DATE },
                  new SqlParameter("@ONHIRE_LOCATION", SqlDbType.VarChar, 255) { Value = master.ONHIRE_LOCATION },
                  new SqlParameter("@LEASED_FROM", SqlDbType.VarChar,255) { Value = master.LEASED_FROM },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CONTAINER_MASTER", parameters);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CONTAINER_MASTER> GetContainerMasterList(string dbConn, string ContainerNo, string ContType, string ContSize, bool Status, string ONHIRE_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_CONTAINERLIST" },
                  new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 20) { Value = ContainerNo },
                  new SqlParameter("@CONTAINER_TYPE", SqlDbType.VarChar, 50) { Value = ContType },
                  new SqlParameter("@CONTAINER_SIZE", SqlDbType.VarChar, 20) { Value = ContSize },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = Status },
                  new SqlParameter("@ONHIRE_DATE", SqlDbType.DateTime) { Value = ONHIRE_DATE },
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

        public CONTAINER_MASTER GetContainerMasterDetails(string connstring, int ID, string CONTAINER_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 20) { Value = CONTAINER_NO },
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
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@ONHIRE_DATE", SqlDbType.DateTime) { Value = master.ONHIRE_DATE },
                  new SqlParameter("@ONHIRE_LOCATION", SqlDbType.VarChar, 255) { Value = master.ONHIRE_LOCATION },
                  new SqlParameter("@LEASED_FROM", SqlDbType.VarChar,255) { Value = master.LEASED_FROM },
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
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<MASTER> GetMasterList(string dbConn, string key, string FROM_DATE, string TO_DATE, string STATUS)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_MASTER_LIST" },
                  new SqlParameter("@KEY_NAME", SqlDbType.VarChar, 100) { Value =  key},
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value =  FROM_DATE},
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value =  TO_DATE},
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value =  STATUS},

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

        public List<VESSEL_MASTER> GetVesselMasterList(string dbConn, string VESSEL_NAME, string IMO_NO, string STATUS, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSELLIST" },
                  new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar, 255) { Value = VESSEL_NAME },
                  new SqlParameter("@IMO_NO", SqlDbType.VarChar, 11) { Value = IMO_NO },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = STATUS },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },

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
                  new SqlParameter("@LINER_CODE", SqlDbType.VarChar,100) { Value = master.LINER_CODE},
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
                  new SqlParameter("@LINER_CODE", SqlDbType.VarChar,100) { Value = master.LINER_CODE},
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

        #region "CONTAINER TYPE MASTER"
        public void InsertContainerTypeMaster(string connstring, CONTAINER_TYPE master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_CONT_TYPE" },
                  new SqlParameter("@CONT_TYPE_CODE", SqlDbType.VarChar,15) { Value = master.CONT_TYPE_CODE},
                  new SqlParameter("@CONT_TYPE  ", SqlDbType.VarChar, 50) { Value = master.CONT_TYPE   },
                  new SqlParameter("@CONT_SIZE",SqlDbType.Int){Value=master.CONT_SIZE},
                  new SqlParameter("@ISO_CODE",SqlDbType.VarChar,50){Value=master.ISO_CODE},
                  new SqlParameter("@TEUS",SqlDbType.Int){Value=master.TEUS},
                  new SqlParameter("@OUT_DIM",SqlDbType.VarChar,100){Value=master.OUT_DIM},
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_CONT_TYPE", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<CONTAINER_TYPE> GetContainerTypeMasterList(string dbConn, string ContTypeCode, string ContType, string ContSize, bool Status, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_CONT_TYPE_LIST" },
                  new SqlParameter("@CONT_TYPE_CODE", SqlDbType.VarChar, 15) { Value = ContTypeCode },
                  new SqlParameter("@CONT_TYPE", SqlDbType.VarChar, 50) { Value = ContType },
                  new SqlParameter("@CONT_SIZE", SqlDbType.Int) { Value = ContSize },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = Status },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime, 20) { Value = TO_DATE },







                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_MST_CONT_TYPE", parameters);
                List<CONTAINER_TYPE> master = SqlHelper.CreateListFromTable<CONTAINER_TYPE>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public CONTAINER_TYPE GetContainerTypeMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_CONT_TYPE_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<CONTAINER_TYPE>(connstring, "SP_MST_CONT_TYPE", r => r.TranslateAsContainerType(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateConatinerTypeMaster(string connstring, CONTAINER_TYPE master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                 new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_CONT_TYPE" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID },
                  new SqlParameter("@CONT_TYPE_CODE", SqlDbType.VarChar,15) { Value = master.CONT_TYPE_CODE},
                  new SqlParameter("@CONT_TYPE  ", SqlDbType.VarChar, 50) { Value = master.CONT_TYPE   },
                  new SqlParameter("@CONT_SIZE",SqlDbType.Int){Value=master.CONT_SIZE},
                  new SqlParameter("@ISO_CODE",SqlDbType.VarChar,50){Value=master.ISO_CODE},
                  new SqlParameter("@TEUS",SqlDbType.Int){Value=master.TEUS},
                  new SqlParameter("@OUT_DIM",SqlDbType.VarChar,100){Value=master.OUT_DIM},
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_CONT_TYPE", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteContainerTypeMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_CONT_TYPE" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_CONT_TYPE", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ICD MASTER"
        public List<ICD_MASTER> GetICDMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_MST_ICD" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_MASTER", parameters);
                List<ICD_MASTER> master = SqlHelper.CreateListFromTable<ICD_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region DEPO MASTER"
        public List<DEPO_MASTER> GetDEPOMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_MST_DEPO" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_MASTER", parameters);
                List<DEPO_MASTER> master = SqlHelper.CreateListFromTable<DEPO_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region TERMINAL MASTER"
        public List<TERMINAL_MASTER> GetTerminalMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_MST_TERMINAL" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_MASTER", parameters);
                List<TERMINAL_MASTER> master = SqlHelper.CreateListFromTable<TERMINAL_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region CLEARING PARTY"
        public List<CLEARING_PARTY> GetClearingPartyList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CLEARING_PARTY_LIST" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CLEARING_PARTY", parameters);
                List<CLEARING_PARTY> master = SqlHelper.CreateListFromTable<CLEARING_PARTY>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void InsertCP(string connstring, CLEARING_PARTY request)
        {
            try
            {
                SqlParameter[] parameters =
                {

                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "CREATE_CLEARING_PARTY" },
                  new SqlParameter("@NAME", SqlDbType.VarChar,100) { Value = request.NAME },
                  new SqlParameter("@EMAIL_ID", SqlDbType.VarChar,255) { Value = request.EMAIL_ID },
                  new SqlParameter("@ADDRESS", SqlDbType.VarChar, 255) { Value = request.ADDRESS },
                  new SqlParameter("@CONTACT", SqlDbType.VarChar, 20) { Value = request.CONTACT },
                  new SqlParameter("@LOCATION", SqlDbType.VarChar,50) { Value = request.LOCATION },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = request.AGENT_CODE },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar, 100) { Value = request.CREATED_BY }

                };

                //SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_DO", parameters);

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CLEARING_PARTY", parameters);


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "LINER"
        public void InsertLiner(string connstring, LINER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_LINER" },
                  new SqlParameter("@NAME",SqlDbType.VarChar,255){Value=master.NAME},
                  new SqlParameter("@CODE",SqlDbType.VarChar,50){Value=master.CODE},
                  new SqlParameter("@DESCRIPTION",SqlDbType.VarChar,255){Value=master.DESCRIPTION},

                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},

                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = master.CREATED_BY },

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_LINER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LINER> GetLinerList(string dbConn, string Name, string Code, string Description, bool Status, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_LINER_LIST" },
                  new SqlParameter("@NAME", SqlDbType.VarChar, 255) { Value = Name },
                  new SqlParameter("@CODE", SqlDbType.VarChar, 50) { Value = Code },
                  new SqlParameter("@DESCRIPTION", SqlDbType.VarChar, 255) { Value = Description },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = Status },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },


                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_LINER", parameters);
                List<LINER> master = SqlHelper.CreateListFromTable<LINER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public LINER GetLinerDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_LINER_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<LINER>(connstring, "SP_LINER", r => r.TranslateAsLiner(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateLinerList(string connstring, LINER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_LINER" },
                  new SqlParameter("@ID",SqlDbType.Int){Value=master.ID},
                  new SqlParameter("@NAME",SqlDbType.VarChar,255){Value=master.NAME},
                  new SqlParameter("@CODE",SqlDbType.VarChar,50){Value=master.CODE},
                  new SqlParameter("@DESCRIPTION",SqlDbType.VarChar,255){Value=master.DESCRIPTION},

                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},


                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_LINER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteLinerList(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_LINER" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_LINER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region "LINERSERVICE"
        public void InsertService(string connstring, SERVICE master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_SERVICE" },
                  new SqlParameter("@LINER_CODE",SqlDbType.VarChar,100){Value=master.LINER_CODE},
                  new SqlParameter("SERVICE_NAME",SqlDbType.VarChar,255){Value=master.SERVICE_NAME},
                  new SqlParameter("@PORT_CODE",SqlDbType.VarChar,100){Value=master.PORT_CODE},

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
        public List<SERVICE> GetServiceList(string dbConn, bool Status, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                 new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_SERVICELIST" },
                 new SqlParameter("@STATUS", SqlDbType.Bit) { Value = Status },
                 new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                 new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_SERVICE_MASTER", parameters);
                List<SERVICE> master = SqlHelper.CreateListFromTable<SERVICE>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public SERVICE GetServiceDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_SERVICEDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<SERVICE>(connstring, "SP_CRUD_SERVICE_MASTER", r => r.TranslateAsLinerService(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateService(string connstring, SERVICE master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_SERVICE" },
                  new SqlParameter("@ID",SqlDbType.Int){Value=master.ID},
                  new SqlParameter("@LINER_CODE",SqlDbType.VarChar,100){Value=master.LINER_CODE},
                  new SqlParameter("@SERVICE_NAME",SqlDbType.VarChar,255){Value=master.SERVICE_NAME},
                  new SqlParameter("@PORT_CODE",SqlDbType.VarChar,100){Value=master.PORT_CODE},

                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},


                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SERVICE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteService(string connstring, int ID)
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

        #region "VESSEL SCHEDULE"
        public void InsertSchedule(string connstring, SCHEDULE master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_VESSEL_SCHEDULE" },
                  new SqlParameter("@VESSEL_NAME",SqlDbType.VarChar,255){Value=master.VESSEL_NAME},
                  new SqlParameter("SERVICE_NAME",SqlDbType.VarChar,255){Value=master.SERVICE_NAME},
                  new SqlParameter("@PORT_CODE",SqlDbType.VarChar,100){Value=master.PORT_CODE},
                  new SqlParameter("@VIA_NO",SqlDbType.VarChar,100){Value=master.VIA_NO},
                  new SqlParameter("@ETA",SqlDbType.DateTime){Value=master.ETA},
                  new SqlParameter("@ETD",SqlDbType.DateTime){Value=master.ETD},
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

        public List<SCHEDULE> GetScheduleList(string dbConn, string VesselName, string PortCode, bool status, string ETA, string ETD)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSEL_SCHEDULELIST" },
                  new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar, 255) { Value = VesselName },
                  new SqlParameter("@PORT_CODE", SqlDbType.VarChar, 100) { Value = PortCode },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = status },
                  new SqlParameter("@ETA", SqlDbType.DateTime) { Value = ETA },
                   new SqlParameter("@ETD", SqlDbType.DateTime) { Value = ETD },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_VESSEL_MASTER", parameters);
                List<SCHEDULE> master = SqlHelper.CreateListFromTable<SCHEDULE>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public SCHEDULE GetScheduleDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSEL_SCHEDULEDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<SCHEDULE>(connstring, "SP_CRUD_VESSEL_MASTER", r => r.TranslateAsSchedule(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateSchedule(string connstring, SCHEDULE master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_VESSEL_SCHEDULE" },
                  new SqlParameter("@ID",SqlDbType.Int){Value=master.ID},
                  new SqlParameter("@VESSEL_NAME",SqlDbType.VarChar,255){Value=master.VESSEL_NAME},
                  new SqlParameter("@SERVICE_NAME",SqlDbType.VarChar,255){Value=master.SERVICE_NAME},
                  new SqlParameter("@PORT_CODE",SqlDbType.VarChar,100){Value=master.PORT_CODE},
                  new SqlParameter("@VIA_NO",SqlDbType.VarChar,100){Value=master.VIA_NO},
                  new SqlParameter("@ETA",SqlDbType.DateTime){Value=master.ETA},
                  new SqlParameter("@ETD",SqlDbType.DateTime){Value=master.ETD},
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteSchedule(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_VESSEL_SCHEDULE" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "VESSEL VOYAGE"
        public List<VOYAGE> GetVoyageList(string dbConn, bool status, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSEL_VOYAGELIST" },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = status },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                   new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_VESSEL_MASTER", parameters);
                List<VOYAGE> master = SqlHelper.CreateListFromTable<VOYAGE>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public VOYAGE GetVoyageDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VESSEL_VOYAGEDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<VOYAGE>(connstring, "SP_CRUD_VESSEL_MASTER", r => r.TranslateAsVoyage(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateVoyage(string connstring, VOYAGE master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_VESSEL_VOYAGEDETAILS" },
                  new SqlParameter("@ID",SqlDbType.Int){Value=master.ID},
                  new SqlParameter("@VESSEL_NAME",SqlDbType.VarChar,255){Value=master.VESSEL_NAME},
                  new SqlParameter("@VOYAGE_NO",SqlDbType.VarChar,20){Value=master.VOYAGE_NO},
                  new SqlParameter("@ATA",SqlDbType.DateTime){Value=master.ATA},
                  new SqlParameter("@ATD",SqlDbType.DateTime){Value=master.ATD},
                  //new SqlParameter("@IMM_CURR",SqlDbType.VarChar,50){Value=master.IMM_CURR},
                  //new SqlParameter("@IMM_CURR_RATE", SqlDbType.Decimal) { Value = master.IMM_CURR_RATE},
                  //new SqlParameter("@EXP_CURR",SqlDbType.VarChar,50){Value=master.EXP_CURR},
                  //new SqlParameter("@EXP_CURR_RATE", SqlDbType.Decimal) { Value = master.EXP_CURR_RATE},
                  new SqlParameter("@TERMINAL_CODE", SqlDbType.VarChar,255) { Value = master.TERMINAL_CODE},
                  new SqlParameter("@SERVICE_NAME", SqlDbType.VarChar,255) { Value = master.SERVICE_NAME},
                  new SqlParameter("@VIA_NO", SqlDbType.VarChar,100) { Value = master.VIA_NO},
                  new SqlParameter("@PORT_CODE", SqlDbType.VarChar,255) { Value = master.PORT_CODE},
                  new SqlParameter("@ETA", SqlDbType.DateTime) { Value = master.ETA},
                  new SqlParameter("@ETD", SqlDbType.DateTime) { Value = master.ETD},
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS},
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteVoyage(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_VESSEL_VOYAGE" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_VESSEL_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "LOCATION MASTER"
        public void InsertLocationMaster(string connstring, LOCATION_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_LOCATION" },
                  new SqlParameter("@LOC_NAME", SqlDbType.VarChar,500) { Value = master.LOC_NAME},
                  new SqlParameter("@LOC_CODE", SqlDbType.VarChar, 50) { Value = master.LOC_CODE },
                  new SqlParameter("@IS_DEPO", SqlDbType.Bit) { Value = master.IS_DEPO },
                  new SqlParameter("@IS_CFS", SqlDbType.Bit) { Value = master.IS_CFS },
                  new SqlParameter("@IS_TERMINAL", SqlDbType.Bit) { Value = master.IS_TERMINAL },
                  new SqlParameter("@IS_YARD", SqlDbType.Bit) { Value = master.IS_YARD },
                  new SqlParameter("@IS_ICD", SqlDbType.Bit) { Value = master.IS_ICD },
                  new SqlParameter("@ADDRESS", SqlDbType.VarChar,500) { Value = master.ADDRESS },
                  new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar, 10) { Value = master.COUNTRY_CODE },
                  new SqlParameter("@PORT_CODE", SqlDbType.VarChar,255) { Value = master.PORT_CODE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,50) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_LOCATION_MASTER", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<LOCATION_MASTER> GetLocationMasterList(string dbConn, string LOC_NAME, string LOC_TYPE, bool STATUS, string FROM_DATE, string TO_DATE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_LOCATIONLIST" },
                  new SqlParameter("@LOC_NAME", SqlDbType.VarChar, 255) { Value = LOC_NAME },
                  new SqlParameter("@LOC_TYPE", SqlDbType.VarChar, 50) { Value = LOC_TYPE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = STATUS },
                  new SqlParameter("@FROM_DATE", SqlDbType.DateTime) { Value = FROM_DATE },
                  new SqlParameter("@TO_DATE", SqlDbType.DateTime) { Value = TO_DATE },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_LOCATION_MASTER", parameters);
                List<LOCATION_MASTER> master = SqlHelper.CreateListFromTable<LOCATION_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LOCATION_MASTER GetLocationMasterDetails(string connstring, string LOC_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@LOC_CODE", SqlDbType.VarChar, 20) { Value = LOC_CODE },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_LOCATIONDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<LOCATION_MASTER>(connstring, "SP_CRUD_LOCATION_MASTER", r => r.TranslateAsLocation(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateLocationMasterList(string connstring, LOCATION_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_LOCATION" },
                  new SqlParameter("@LOC_NAME", SqlDbType.VarChar,500) { Value = master.LOC_NAME},
                  new SqlParameter("@LOC_CODE", SqlDbType.VarChar, 20) { Value = master.LOC_CODE },
                  new SqlParameter("@IS_DEPO", SqlDbType.Bit) { Value = master.IS_DEPO },
                  new SqlParameter("@IS_CFS", SqlDbType.Bit) { Value = master.IS_CFS },
                  new SqlParameter("@IS_TERMINAL", SqlDbType.Bit) { Value = master.IS_TERMINAL },
                  new SqlParameter("@IS_YARD", SqlDbType.Bit) { Value = master.IS_YARD },
                  new SqlParameter("@IS_ICD", SqlDbType.Bit) { Value = master.IS_ICD },
                  new SqlParameter("@ADDRESS", SqlDbType.VarChar,500) { Value = master.ADDRESS },
                  new SqlParameter("@PORT_CODE", SqlDbType.VarChar,255) { Value = master.PORT_CODE },
                  new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar,20) { Value = master.COUNTRY_CODE },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_LOCATION_MASTER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteLocationMaster(string connstring, string LOC_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@LOC_CODE", SqlDbType.VarChar,20) { Value = LOC_CODE },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_LOCATION" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_LOCATION_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "FREIGHT MASTER"
        public void InsertFreightMaster(string connstring, FREIGHT_MASTER master)
        {
            try
            {
                if (master.CHARGELIST.Count > 0)
                {
                    foreach (var i in master.CHARGELIST)
                    {
                        SqlParameter[] param1 =
                        {
                           new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_CHARGE" },
                           new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = i.POL},
                           new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = i.CHARGE_CODE },
                           new SqlParameter("@IMPCOST20", SqlDbType.Decimal) { Value = i.IMPCOST20 },
                           new SqlParameter("@IMPCOST40", SqlDbType.Decimal) { Value = i.IMPCOST40 },
                           new SqlParameter("@IMPREVENUE20", SqlDbType.Decimal) { Value = i.IMPINCOME20 },
                           new SqlParameter("@IMPREVENUE40", SqlDbType.Decimal) { Value = i.IMPINCOME40 },
                           new SqlParameter("@EXPCOST20", SqlDbType.Decimal) { Value = i.EXPCOST20 },
                           new SqlParameter("@EXPCOST40", SqlDbType.Decimal) { Value = i.EXPCOST40 },
                           new SqlParameter("@EXPREVENUE20", SqlDbType.Decimal) { Value = i.EXPINCOME20 },
                           new SqlParameter("@EXPREVENUE40", SqlDbType.Decimal) { Value = i.EXPINCOME40 },
                           new SqlParameter("@Currency", SqlDbType.VarChar,10) { Value = i.CURRENCY },
                           new SqlParameter("@FROM_VAL", SqlDbType.Int) { Value = i.FROM_VAL },
                           new SqlParameter("@TO_VAL", SqlDbType.Int) { Value = i.TO_VAL },
                        };

                        SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", param1);
                    }
                }
                else
                {
                    SqlParameter[] parameters =
                    {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_FREIGHT" },
                      new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = master.POL},
                      new SqlParameter("@POD", SqlDbType.VarChar, 100) { Value = master.POD },
                      new SqlParameter("@Charge", SqlDbType.VarChar,100) { Value = master.Charge },
                      new SqlParameter("@Currency", SqlDbType.VarChar, 10) { Value = master.Currency },
                      new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = master.LadenStatus },
                      new SqlParameter("@ServiceMode", SqlDbType.VarChar,20) { Value = master.ServiceMode },
                      new SqlParameter("@DRY20", SqlDbType.Decimal) { Value = master.DRY20 },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<FREIGHT_MASTER> GetFreightMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_FREIGHTLIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CHARGE_MASTER", parameters);
                List<FREIGHT_MASTER> master = SqlHelper.CreateListFromTable<FREIGHT_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public FREIGHT_MASTER GetFreightMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_FREIGHTDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<FREIGHT_MASTER>(connstring, "SP_CRUD_CHARGE_MASTER", r => r.TranslateAsFreightMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateFreightMasterList(string connstring, FREIGHT_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_FREIGHT" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID },
                  new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = master.POL},
                  new SqlParameter("@POD", SqlDbType.VarChar, 100) { Value = master.POD },
                  new SqlParameter("@Charge", SqlDbType.VarChar,100) { Value = master.Charge },
                  new SqlParameter("@Currency", SqlDbType.VarChar, 10) { Value = master.Currency },
                  new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = master.LadenStatus },
                  new SqlParameter("@ServiceMode", SqlDbType.VarChar,20) { Value = master.ServiceMode },
                  new SqlParameter("@DRY20", SqlDbType.Decimal) { Value = master.DRY20 },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteFreightMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_FREIGHT" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "CHARGE MASTER"
        public List<CHARGE_MASTER> GetChargeMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_CHARGELIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CHARGE_MASTER", parameters);
                List<CHARGE_MASTER> master = SqlHelper.CreateListFromTable<CHARGE_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CHARGE_MASTER GetChargeMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_CHARGEDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<CHARGE_MASTER>(connstring, "SP_CRUD_CHARGE_MASTER", r => r.TranslateAsChargeMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateChargeMasterList(string connstring, CHARGE_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_CHARGE" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID },
                  new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = master.POL},
                  new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = master.CHARGE_CODE },
                  new SqlParameter("@Currency", SqlDbType.VarChar,100) { Value = master.CURRENCY },
                  new SqlParameter("@IMPCOST20", SqlDbType.Decimal) { Value = master.IMPCOST20 },
                  new SqlParameter("@IMPCOST40", SqlDbType.Decimal) { Value = master.IMPCOST40 },
                  new SqlParameter("@IMPREVENUE20", SqlDbType.Decimal) { Value = master.IMPINCOME20 },
                  new SqlParameter("@IMPREVENUE40", SqlDbType.Decimal) { Value = master.IMPINCOME40 },
                  new SqlParameter("@EXPCOST20", SqlDbType.Decimal) { Value = master.EXPCOST20 },
                  new SqlParameter("@EXPCOST40", SqlDbType.Decimal) { Value = master.EXPCOST40 },
                  new SqlParameter("@EXPREVENUE20", SqlDbType.Decimal) { Value = master.EXPINCOME20 },
                  new SqlParameter("@EXPREVENUE40", SqlDbType.Decimal) { Value = master.EXPINCOME40 },
                  new SqlParameter("@FROM_VAL", SqlDbType.Int) { Value = master.FROM_VAL },
                  new SqlParameter("@TO_VAL", SqlDbType.Int) { Value = master.TO_VAL },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteChargeMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_CHARGE" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "STEVEDORING MASTER"
        public List<STEV_MASTER> GetStevedoringMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_STEVLIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CHARGE_MASTER", parameters);
                List<STEV_MASTER> master = SqlHelper.CreateListFromTable<STEV_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public STEV_MASTER GetStevedoringMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_STEVDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<STEV_MASTER>(connstring, "SP_CRUD_CHARGE_MASTER", r => r.TranslateAsStevMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateStevedoringMasterList(string connstring, STEV_MASTER i)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_STEV" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = i.ID},
                  new SqlParameter("@IE_TYPE", SqlDbType.VarChar,255) { Value = i.IE_TYPE},
                  new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = i.POL},
                  new SqlParameter("@TERMINAL", SqlDbType.VarChar, 255) { Value = i.TERMINAL },
                  new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = i.CHARGE_CODE },
                  new SqlParameter("@CURRENCY", SqlDbType.VarChar, 10) { Value = i.CURRENCY },
                  new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = i.LADEN_STATUS },
                  new SqlParameter("@ServiceMode", SqlDbType.VarChar,20) { Value = i.SERVICE_MODE },
                  new SqlParameter("@DRY20", SqlDbType.Decimal) { Value = i.DRY20 },
                  new SqlParameter("@DRY40", SqlDbType.Decimal) { Value = i.DRY40 },
                  new SqlParameter("@DRY40HC", SqlDbType.Decimal) { Value = i.DRY40HC },
                  new SqlParameter("@DRY45", SqlDbType.Decimal) { Value = i.DRY45 },
                  new SqlParameter("@RF20", SqlDbType.Decimal) { Value = i.RF20 },
                  new SqlParameter("@RF40", SqlDbType.Decimal) { Value = i.RF40 },
                  new SqlParameter("@RF40HC", SqlDbType.Decimal) { Value = i.RF40HC },
                  new SqlParameter("@RF45", SqlDbType.Decimal) { Value = i.RF45 },
                  new SqlParameter("@HAZ20", SqlDbType.Decimal) { Value = i.HAZ20 },
                  new SqlParameter("@HAZ40", SqlDbType.Decimal) { Value = i.HAZ40 },
                  new SqlParameter("@HAZ40HC", SqlDbType.Decimal) { Value = i.HAZ40HC },
                  new SqlParameter("@HAZ45", SqlDbType.Decimal) { Value = i.HAZ45 },
                  new SqlParameter("@SEQ20", SqlDbType.Decimal) { Value = i.SEQ20 },
                  new SqlParameter("@SEQ40", SqlDbType.Decimal) { Value = i.SEQ40 },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteStevedoringMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_STEV" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "DETENTION MASTER"
        public List<DETENTION_MASTER> GetDetentionMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DETENTIONLIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CHARGE_MASTER", parameters);
                List<DETENTION_MASTER> master = SqlHelper.CreateListFromTable<DETENTION_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DETENTION_MASTER GetDetentionMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_DETENTIONDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<DETENTION_MASTER>(connstring, "SP_CRUD_CHARGE_MASTER", r => r.TranslateAsDetentionMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateDetentionMasterList(string connstring, DETENTION_MASTER i)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_DETENTION" },
                    new SqlParameter("@ID", SqlDbType.Int) { Value = i.ID },
                    new SqlParameter("@PORT_CODE", SqlDbType.VarChar,50) { Value = i.PORT_CODE},
                    new SqlParameter("@CONTAINER_TYPE", SqlDbType.VarChar,20) { Value = i.CONTAINER_TYPE},
                    new SqlParameter("@CURRENCY", SqlDbType.VarChar, 10) { Value = i.CURRENCY },
                    new SqlParameter("@FROM_DAYS", SqlDbType.Int) { Value = i.FROM_DAYS },
                    new SqlParameter("@TO_DAYS", SqlDbType.Int) { Value = i.TO_DAYS },
                    new SqlParameter("@RATE20", SqlDbType.Decimal) { Value = i.RATE20 },
                    new SqlParameter("@RATE40", SqlDbType.Decimal) { Value = i.RATE40 },
                    new SqlParameter("@HC_RATE", SqlDbType.Decimal) { Value = i.HC_RATE },
                    new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = i.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteDetentionMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_DETENTION" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "MANDATORY MASTER"
        public List<MANDATORY_MASTER> GetMandatoryMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_MANDATORYLIST" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_CHARGE_MASTER", parameters);
                List<MANDATORY_MASTER> master = SqlHelper.CreateListFromTable<MANDATORY_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MANDATORY_MASTER GetMandatoryMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_MANDATORYDETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<MANDATORY_MASTER>(connstring, "SP_CRUD_CHARGE_MASTER", r => r.TranslateAsMandatoryMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateMandatoryMasterList(string connstring, MANDATORY_MASTER i)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_MANDATORY" },
                    new SqlParameter("@ID", SqlDbType.Int) { Value = i.ID },
                    new SqlParameter("@ORG_CODE", SqlDbType.VarChar,50) { Value = i.ORG_CODE},
                    new SqlParameter("@PORT_CODE", SqlDbType.VarChar,100) { Value = i.PORT_CODE},
                    new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = i.CHARGE_CODE},
                    new SqlParameter("@IE_TYPE", SqlDbType.VarChar, 50) { Value = i.IE_TYPE },
                    new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = i.LADEN_STATUS },
                    new SqlParameter("@CURRENCY", SqlDbType.VarChar,50) { Value = i.CURRENCY },
                    new SqlParameter("@RATE20", SqlDbType.Decimal) { Value = i.RATE20 },
                    new SqlParameter("@RATE40", SqlDbType.Decimal) { Value = i.RATE40 },
                    new SqlParameter("@IS_PERCENTAGE", SqlDbType.Bit) { Value = i.IS_PERCENTAGE },
                    new SqlParameter("@PERCENTAGE_VALUE", SqlDbType.Int) { Value = i.PERCENTAGE_VALUE },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteMandatoryMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_MANDATORY" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "UPLOAD TARIFF"
        public void UploadFreightTariff(string connstring, List<FREIGHT_MASTER> master)
        {
            try
            {
                foreach (var i in master)
                {
                    SqlParameter[] parameters =
                    {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_FREIGHT" },
                      new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = i.POL},
                      new SqlParameter("@POD", SqlDbType.VarChar, 100) { Value = i.POD },
                      new SqlParameter("@Charge", SqlDbType.VarChar,100) { Value = i.Charge },
                      new SqlParameter("@Currency", SqlDbType.VarChar, 10) { Value = i.Currency },
                      new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = i.LadenStatus },
                      new SqlParameter("@ServiceMode", SqlDbType.VarChar,20) { Value = i.ServiceMode },
                      new SqlParameter("@DRY20", SqlDbType.Decimal) { Value = i.DRY20 },
                      new SqlParameter("@DRY40", SqlDbType.Decimal) { Value = i.DRY40 },
                      new SqlParameter("@DRY40HC", SqlDbType.Decimal) { Value = i.DRY40HC },
                      new SqlParameter("@DRY45", SqlDbType.Decimal) { Value = i.DRY45 },
                      new SqlParameter("@RF20", SqlDbType.Decimal) { Value = i.RF20 },
                      new SqlParameter("@RF40", SqlDbType.Decimal) { Value = i.RF40 },
                      new SqlParameter("@RF40HC", SqlDbType.Decimal) { Value = i.RF40HC },
                      new SqlParameter("@RF45", SqlDbType.Decimal) { Value = i.RF45 },
                      new SqlParameter("@HAZ20", SqlDbType.Decimal) { Value = i.HAZ20 },
                      new SqlParameter("@HAZ40", SqlDbType.Decimal) { Value = i.HAZ40 },
                      new SqlParameter("@HAZ40HC", SqlDbType.Decimal) { Value = i.HAZ40HC },
                      new SqlParameter("@HAZ45", SqlDbType.Decimal) { Value = i.HAZ45 },
                      new SqlParameter("@SEQ20", SqlDbType.Decimal) { Value = i.SEQ20 },
                      new SqlParameter("@SEQ40", SqlDbType.Decimal) { Value = i.SEQ40 },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UploadChargeTariff(string connstring, List<CHARGE_MASTER> master)
        {
            try
            {
                foreach (var i in master)
                {
                    SqlParameter[] parameters =
                    {
                        new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_CHARGE" },
                        new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = i.POL},
                        new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = i.CHARGE_CODE },
                        new SqlParameter("@IMPCOST20", SqlDbType.Decimal) { Value = i.IMPCOST20 },
                        new SqlParameter("@IMPCOST40", SqlDbType.Decimal) { Value = i.IMPCOST40 },
                        new SqlParameter("@IMPREVENUE20", SqlDbType.Decimal) { Value = i.IMPINCOME20 },
                        new SqlParameter("@IMPREVENUE40", SqlDbType.Decimal) { Value = i.IMPINCOME40 },
                        new SqlParameter("@EXPCOST20", SqlDbType.Decimal) { Value = i.EXPCOST20 },
                        new SqlParameter("@EXPCOST40", SqlDbType.Decimal) { Value = i.EXPCOST40 },
                        new SqlParameter("@EXPREVENUE20", SqlDbType.Decimal) { Value = i.EXPINCOME20 },
                        new SqlParameter("@EXPREVENUE40", SqlDbType.Decimal) { Value = i.EXPINCOME40 },
                        new SqlParameter("@Currency", SqlDbType.VarChar,10) { Value = i.CURRENCY },
                        new SqlParameter("@FROM_VAL", SqlDbType.Int) { Value = i.FROM_VAL },
                        new SqlParameter("@TO_VAL", SqlDbType.Int) { Value = i.TO_VAL },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UploadStevTariff(string connstring, List<STEV_MASTER> master)
        {
            try
            {
                foreach (var i in master)
                {
                    SqlParameter[] parameters =
                   {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_STEV" },
                      new SqlParameter("@IE_TYPE", SqlDbType.VarChar,255) { Value = i.IE_TYPE},
                      new SqlParameter("@POL", SqlDbType.VarChar,100) { Value = i.POL},
                      new SqlParameter("@TERMINAL", SqlDbType.VarChar, 255) { Value = i.TERMINAL },
                      new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = i.CHARGE_CODE },
                      new SqlParameter("@CURRENCY", SqlDbType.VarChar, 10) { Value = i.CURRENCY },
                      new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = i.LADEN_STATUS },
                      new SqlParameter("@ServiceMode", SqlDbType.VarChar,20) { Value = i.SERVICE_MODE },
                      new SqlParameter("@DRY20", SqlDbType.Decimal) { Value = i.DRY20 },
                      new SqlParameter("@DRY40", SqlDbType.Decimal) { Value = i.DRY40 },
                      new SqlParameter("@DRY40HC", SqlDbType.Decimal) { Value = i.DRY40HC },
                      new SqlParameter("@DRY45", SqlDbType.Decimal) { Value = i.DRY45 },
                      new SqlParameter("@RF20", SqlDbType.Decimal) { Value = i.RF20 },
                      new SqlParameter("@RF40", SqlDbType.Decimal) { Value = i.RF40 },
                      new SqlParameter("@RF40HC", SqlDbType.Decimal) { Value = i.RF40HC },
                      new SqlParameter("@RF45", SqlDbType.Decimal) { Value = i.RF45 },
                      new SqlParameter("@HAZ20", SqlDbType.Decimal) { Value = i.HAZ20 },
                      new SqlParameter("@HAZ40", SqlDbType.Decimal) { Value = i.HAZ40 },
                      new SqlParameter("@HAZ40HC", SqlDbType.Decimal) { Value = i.HAZ40HC },
                      new SqlParameter("@HAZ45", SqlDbType.Decimal) { Value = i.HAZ45 },
                      new SqlParameter("@SEQ20", SqlDbType.Decimal) { Value = i.SEQ20 },
                      new SqlParameter("@SEQ40", SqlDbType.Decimal) { Value = i.SEQ40 },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UploadDetentionTariff(string connstring, List<DETENTION_MASTER> master)
        {
            try
            {
                foreach (var i in master)
                {
                    SqlParameter[] parameters =
                   {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_DETENTION" },
                      new SqlParameter("@PORT_CODE", SqlDbType.VarChar,50) { Value = i.PORT_CODE},
                      new SqlParameter("@CONTAINER_TYPE", SqlDbType.VarChar,20) { Value = i.CONTAINER_TYPE},
                      new SqlParameter("@CURRENCY", SqlDbType.VarChar, 10) { Value = i.CURRENCY },
                      new SqlParameter("@FROM_DAYS", SqlDbType.Int) { Value = i.FROM_DAYS },
                      new SqlParameter("@TO_DAYS", SqlDbType.Int) { Value = i.TO_DAYS },
                      new SqlParameter("@RATE20", SqlDbType.Decimal) { Value = i.RATE20 },
                      new SqlParameter("@RATE40", SqlDbType.Decimal) { Value = i.RATE40 },
                      new SqlParameter("@HC_RATE", SqlDbType.Decimal) { Value = i.HC_RATE },
                      new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = i.CREATED_BY },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UploadMandatoryTariff(string connstring, List<MANDATORY_MASTER> master)
        {
            try
            {
                foreach (var i in master)
                {
                    SqlParameter[] parameters =
                   {
                      new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_MANDATORY" },
                      new SqlParameter("@ORG_CODE", SqlDbType.VarChar,50) { Value = i.ORG_CODE},
                      new SqlParameter("@PORT_CODE", SqlDbType.VarChar,100) { Value = i.PORT_CODE},
                      new SqlParameter("@CHARGE_CODE", SqlDbType.VarChar,100) { Value = i.CHARGE_CODE},
                      new SqlParameter("@IE_TYPE", SqlDbType.VarChar, 50) { Value = i.IE_TYPE },
                      new SqlParameter("@LadenStatus", SqlDbType.Char,1) { Value = i.LADEN_STATUS },
                      new SqlParameter("@CURRENCY", SqlDbType.VarChar,50) { Value = i.CURRENCY },
                      new SqlParameter("@RATE20", SqlDbType.Decimal) { Value = i.RATE20 },
                      new SqlParameter("@RATE40", SqlDbType.Decimal) { Value = i.RATE40 },
                      new SqlParameter("@IS_PERCENTAGE", SqlDbType.Bit) { Value = i.IS_PERCENTAGE },
                      new SqlParameter("@PERCENTAGE_VALUE", SqlDbType.Int) { Value = i.PERCENTAGE_VALUE },
                    };

                    SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_CHARGE_MASTER", parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "ORGANISATION MASTER"
        public void InsertOrgMaster(string connstring, ORG_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_ORG" },
                  new SqlParameter("@ORG_NAME", SqlDbType.VarChar,255) { Value = master.ORG_NAME},
                  new SqlParameter("@ORG_CODE", SqlDbType.VarChar, 50) { Value = master.ORG_CODE },
                  new SqlParameter("@ORG_LOCATION", SqlDbType.VarChar, 100) { Value = master.ORG_LOCATION },
                  new SqlParameter("@ORG_LOC_CODE", SqlDbType.VarChar, 100) { Value = master.ORG_LOC_CODE },
                  new SqlParameter("@ORG_ADDRESS1", SqlDbType.VarChar, 255) { Value = master.ORG_ADDRESS1 },
                  new SqlParameter("@EMAIL", SqlDbType.VarChar, 255) { Value = master.EMAIL },
                  new SqlParameter("@CONTACT", SqlDbType.VarChar, 50) { Value = master.CONTACT },
                  new SqlParameter("@FAX", SqlDbType.VarChar, 50) { Value = master.FAX },
                  new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar, 10) { Value = master.COUNTRY_CODE },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,50) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_ORGANISATION", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public string ValidateOrgCode(string connstring, string ORG_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "VALIDATE_ORG_CODE" },
                  new SqlParameter("@ORG_CODE", SqlDbType.VarChar, 50) { Value = ORG_CODE },
                };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_ORGANISATION", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ORG_MASTER> GetOrgMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_ORG_LIST" }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_ORGANISATION", parameters);
                List<ORG_MASTER> master = SqlHelper.CreateListFromTable<ORG_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ORG_MASTER GetOrgMasterDetails(string connstring, string ORG_CODE, string ORG_LOC_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ORG_CODE", SqlDbType.VarChar, 20) { Value = ORG_CODE },
                   new SqlParameter("@ORG_LOC_CODE", SqlDbType.VarChar, 100) { Value = ORG_LOC_CODE },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_ORG_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<ORG_MASTER>(connstring, "SP_CRUD_ORGANISATION", r => r.TranslateAsOrgMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateOrgMasterList(string connstring, ORG_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "UPDATE_ORG" },
                  new SqlParameter("@ORG_NAME", SqlDbType.VarChar,255) { Value = master.ORG_NAME},
                  new SqlParameter("@ORG_CODE", SqlDbType.VarChar, 50) { Value = master.ORG_CODE },
                  new SqlParameter("@ORG_LOCATION", SqlDbType.VarChar, 100) { Value = master.ORG_LOCATION },
                  new SqlParameter("@ORG_LOC_CODE", SqlDbType.VarChar, 100) { Value = master.ORG_LOC_CODE },
                  new SqlParameter("@ORG_ADDRESS1", SqlDbType.VarChar, 255) { Value = master.ORG_ADDRESS1 },
                  new SqlParameter("@EMAIL", SqlDbType.VarChar, 255) { Value = master.EMAIL },
                  new SqlParameter("@CONTACT", SqlDbType.VarChar, 50) { Value = master.CONTACT },
                  new SqlParameter("@FAX", SqlDbType.VarChar, 50) { Value = master.FAX },
                  new SqlParameter("@COUNTRY_CODE", SqlDbType.VarChar, 10) { Value = master.COUNTRY_CODE },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_ORGANISATION", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteOrgMaster(string connstring, string ORG_CODE,string ORG_LOC_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ORG_CODE", SqlDbType.VarChar,20) { Value = ORG_CODE },
                  new SqlParameter("@ORG_LOC_CODE", SqlDbType.VarChar,100) { Value = ORG_LOC_CODE },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_ORG" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_ORGANISATION", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "SLOT MASTER"
        public void InsertSlotMaster(string connstring, SLOT_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_SLOT" },
                  new SqlParameter("@SLOT_OPERATOR", SqlDbType.VarChar,255) { Value = master.SLOT_OPERATOR},
                  new SqlParameter("@SERVICES", SqlDbType.VarChar, 100) { Value = master.SERVICES },
                  new SqlParameter("@LINER_CODE", SqlDbType.VarChar, 100) { Value = master.LINER_CODE },
                  new SqlParameter("@PORT_CODE", SqlDbType.VarChar, 100) { Value = master.PORT_CODE },
                  new SqlParameter("@TERM", SqlDbType.VarChar, 50) { Value = master.TERM },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,50) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SLOT", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<SLOT_MASTER> GetSlotMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_SLOT_LIST" }
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_CRUD_SLOT", parameters);
                List<SLOT_MASTER> master = SqlHelper.CreateListFromTable<SLOT_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SLOT_MASTER GetSlotMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "GET_SLOT_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<SLOT_MASTER>(connstring, "SP_CRUD_SLOT", r => r.TranslateAsSlotMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateSlotMasterList(string connstring, SLOT_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "UPDATE_SLOT" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@SLOT_OPERATOR", SqlDbType.VarChar,255) { Value = master.SLOT_OPERATOR},
                  new SqlParameter("@SERVICES", SqlDbType.VarChar, 100) { Value = master.SERVICES },
                  new SqlParameter("@LINER_CODE", SqlDbType.VarChar, 100) { Value = master.LINER_CODE },
                  new SqlParameter("@PORT_CODE", SqlDbType.VarChar, 100) { Value = master.PORT_CODE },
                  new SqlParameter("@TERM", SqlDbType.VarChar, 50) { Value = master.TERM },
                  new SqlParameter("@STATUS", SqlDbType.Bit) { Value = master.STATUS },
                  new SqlParameter("@CREATED_BY", SqlDbType.VarChar,50) { Value = master.CREATED_BY },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SLOT", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteSlotMaster(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 20) { Value = "DELETE_SLOT" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_CRUD_SLOT", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }

}

