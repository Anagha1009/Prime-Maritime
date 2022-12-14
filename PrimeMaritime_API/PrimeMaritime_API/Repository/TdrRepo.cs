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
    public class TdrRepo
    {
        public void InsertTdr(string connstring, TDR request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar,255) { Value = "INSERT_TDR" },
                  new SqlParameter("@VESSEL_NAME", SqlDbType.VarChar,255) { Value =request.VESSEL_NAME},
                 new SqlParameter("@VOYAGE_NO",SqlDbType.VarChar,50){Value=request.VOYAGE_NO},
                 new SqlParameter("@POL",SqlDbType.VarChar,100){Value=request.POL},
                 new SqlParameter("@TERMINAL",SqlDbType.VarChar,100){Value=request.TERMINAL},
                 new SqlParameter("@ETA",SqlDbType.DateTime){Value=request.ETA},
                 new SqlParameter("@POB_BERTHING",SqlDbType.DateTime){Value=request.POB_BERTHING},
                 new SqlParameter("@BERTHED",SqlDbType.DateTime){Value=request.BERTHED},
                 new SqlParameter("@OPERATION_COMMMENCED",SqlDbType.DateTime){Value=request.OPERATION_COMMMENCED},
                 new SqlParameter("@POB_SAILING",SqlDbType.DateTime){Value=request.POB_SAILING},
                 new SqlParameter("@SAILED",SqlDbType.DateTime){Value=request.SAILED},
                 new SqlParameter("@ETD",SqlDbType.DateTime){Value=request.ETD},
                 new SqlParameter("@ETA_NEXTPORT",SqlDbType.DateTime){Value=request.ETA_NEXTPORT},
                 new SqlParameter("@CREATED_BY",SqlDbType.VarChar,255){Value=request.CREATED_BY}
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_TDR", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
