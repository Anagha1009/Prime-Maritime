using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class UserDBClient
    {
        public List<SRR> GetSRRList(string connstring)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<SRR>>(connstring, "stp_GetSRRList", r => r.TranslateAsUsersList());
        }
    }
}
