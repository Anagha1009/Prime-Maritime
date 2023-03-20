using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface ITDRService
    {
        Response<CommonResponse> InsertTdr(TDR request);
        Response<List<TDR>> GetTdrList();
        Response<TDR> GetTdrDetails(string TDR_NO);
    }
}
