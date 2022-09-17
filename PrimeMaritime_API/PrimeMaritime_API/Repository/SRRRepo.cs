using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Repository
{
    public class SRRRepo
    {
        public List<SRR> GetSRRList(string connstring)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<SRR>>(connstring, "SP_GET_SRR", r => r.TranslateAsUsersList());
        }
    }
}
