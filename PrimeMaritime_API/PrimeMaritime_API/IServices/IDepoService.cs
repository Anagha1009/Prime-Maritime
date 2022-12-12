using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface IDepoService
    {
        Response<CommonResponse> InsertContainer(DEPO_CONTAINER request);
        Response<CommonResponse> InsertMRRequest(List<MR_LIST> request);
        Response<string> GetMNRDesc(string Ist_char, string IInd_char, string IIIrd_char, string IVth_char, string component_code, string damage_code, string repair_code);
        Response<List<MNR_LIST>> GetMNRList(string OPERATION, string DEPO_CODE);
        Response<List<MR_LIST>> GetMNRDetails(string MR_NO);
        Response<string> ApproveRate(List<MR_LIST> request);
    }
}
