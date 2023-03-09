using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface ISRRReportService
    {
        Response<List<SRR_REPORT>> GetSRRCountList();
    }
}
