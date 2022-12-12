using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public  interface ILoadtlistService
    {
        Response<List<LOAD_LIST>> GetLoadList(string VESSEL_NAME,string VOYAGE_NO);

    }
}
