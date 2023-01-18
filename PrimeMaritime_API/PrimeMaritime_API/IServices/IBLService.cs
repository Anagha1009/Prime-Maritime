using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IBLService
    {
        Response<CommonResponse> InsertBL(BL request);

        Response<BL> GetBLDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE);

        Response<List<BL>> GetBLHistory(string AGENT_CODE);

        Response<List<CONTAINERS>> GetContainerList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO,string BL_NO,string DO_NO,bool fromDO);

        Response<SRR> GetSRRDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE);
        Response<CargoManifest> GetCargoManifestList(string AGENT_CODE, string BL_NO);
    }
}
