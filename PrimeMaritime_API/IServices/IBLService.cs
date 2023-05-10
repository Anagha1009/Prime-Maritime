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
        Response<string> InsertBL(BL request);
        Response<string> UpdateBL(BL request);
        Response<BL> GetBLDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE);
        Response<List<BL>> GetBLHistory(string AGENT_CODE, string ORG_CODE, string PORT);
        Response<List<BL>> GetBLSurrenderedList(string POD,string ORG_CODE);
        Response<List<BL>> GetBLFORMERGE(string PORT_OF_LOADING, string PORT_OF_DISCHARGE, string SHIPPER, string CONSIGNEE, string VESSEL_NAME, string VOYAGE_NO, string NOTIFY_PARTY);
        Response<List<CONTAINERS>> GetContainerList(string AGENT_CODE, string DEPO_CODE, string BOOKING_NO, string CRO_NO,string BL_NO,string DO_NO,bool fromDO);
        Response<SRR> GetSRRDetails(string BL_NO, string BOOKING_NO, string AGENT_CODE);
        Response<CargoManifest> GetCargoManifestList(string AGENT_CODE, string VESSEL_NAME, string VOYAGE_NO);
        Response<List<BL>> GetBLListPM();
        Response<Organisation> GetOrgDetails(string ORG_CODE, string ORG_LOC_CODE);
        void InsertSurrender(string BL_NO);
        void InsertUploadedSurrender(string BL_NO);
    }
}
