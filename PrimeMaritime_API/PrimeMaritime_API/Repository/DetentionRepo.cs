using IdentityModel.Client;
using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class DetentionRepo
    {

        public void InsertDetention(string connstring, DETENTION_REQUEST request)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@OPERATION", SqlDbType.VarChar,50) { Value = "INSERT_DETENTION_REQUEST" },
              new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar,50) { Value = request.CONTAINER_NO},
              new SqlParameter("@DOCUMENT_TYPE", SqlDbType.VarChar, 50) { Value = request.DOCUMENT_TYPE },
              new SqlParameter("@DOCUMENT_NO", SqlDbType.VarChar, 255) { Value = request.DOCUMENT_NO },
              new SqlParameter("@SHIPPER_NAME", SqlDbType.VarChar, 50) { Value = request.SHIPPER_NAME },
              new SqlParameter("@CLEARING_PARTY", SqlDbType.VarChar, 255) { Value = request.CLEARING_PARTY },
              new SqlParameter("@DETENTION_DAYS", SqlDbType.Int) { Value = request.DETENTION_DAYS },
              new SqlParameter("@DETENTION", SqlDbType.Decimal) { Value = request.DETENTION},
              new SqlParameter("@CURRENCY", SqlDbType.VarChar, 50) { Value = request.CURRENCY },
              new SqlParameter("@TARRIF_ID", SqlDbType.Int) { Value = request.TARRIF_ID },
              new SqlParameter("@WAIVER_REQUESTED", SqlDbType.Decimal) { Value = request.WAIVER_REQUESTED },
              new SqlParameter("@WAIVER_APPROVED", SqlDbType.Decimal) { Value = request.WAIVER_APPROVED },
              new SqlParameter("@AGENT_REMARKS", SqlDbType.VarChar,255) { Value = request.AGENT_REMARKS },
              new SqlParameter("@PRINCIPAL_REMARKS", SqlDbType.VarChar,255) { Value = request.PRINCIPAL_REMARKS },
              new SqlParameter("@STATUS", SqlDbType.VarChar,255) { Value = request.STATUS },
              new SqlParameter("@MODIFIED_ON", SqlDbType.DateTime) { Value = request.MODIFIED_ON },
              new SqlParameter("@MODIFIED_BY", SqlDbType.VarChar,255) { Value = request.MODIFIED_BY },
              new SqlParameter("@CREATED_ON", SqlDbType.DateTime) { Value = request.CREATED_ON },
              new SqlParameter("@CREATED_BY", SqlDbType.VarChar,255) { Value = request.CREATED_BY },
            };

            var ID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_DETENTION_REQUEST", parameters);


        }

        public List<DETENTION_REQUEST> GetDetentionList(string dbConn, string AGENT_CODE)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DETENTION_REQUEST" },
                  new SqlParameter("@AGENT_CODE", SqlDbType.VarChar, 50) { Value = AGENT_CODE }

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_DETENTION_REQUEST", parameters);
                List<DETENTION_REQUEST> detention_Request = SqlHelper.CreateListFromTable<DETENTION_REQUEST>(dataTable);

                return detention_Request;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //public List<DETENTION_REQUEST> GET_DETAILS_BY_CONTAINER_NO(string dbConn, string CONTAINER_NO)
        //    {
        //        try
        //        {
        //            SqlParameter[] parameters =
        //            {
        //          new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_DETAILS_BY_CONTAINER_NO" },
        //          new SqlParameter("@CONTAINER_NO", SqlDbType.VarChar, 50) { Value = CONTAINER_NO }

        //        };

        //            DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_DETENTION_REQUEST", parameters);
        //            List<DETENTION_REQUEST> detention_Request = SqlHelper.CreateListFromTable<DETENTION_REQUEST>(dataTable);

        //            return detention_Request;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
            
            
        }
    }

