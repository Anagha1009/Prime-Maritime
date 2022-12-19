using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System.Collections.Generic;

namespace PrimeMaritime_API
{
   public  interface ITdrService
    {
        Response<CommonResponse> InsertTdr(TDR request);

        Response<List<TDR>> GetTdrList();


    }
}