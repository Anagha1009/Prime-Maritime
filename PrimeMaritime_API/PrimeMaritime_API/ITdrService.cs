using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;

namespace PrimeMaritime_API
{
   public  interface ITdrService
    {
        Response<CommonResponse> InsertTdr(TDR request);

    }
}