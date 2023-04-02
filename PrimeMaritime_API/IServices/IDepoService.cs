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
        Response<List<MNR_LIST>> GetMNRList(string OPERATION, string DEPO_CODE);
        Response<MNR_TARIFF> GetMNRTariff(string COMPONENT, string REPAIR, string LENGTH, string WIDTH, string HEIGHT, string QUANTITY);
        Response<List<MR_LIST>> GetMNRDetails(string OPERATION, string MR_NO);
        Response<string> ApproveRate(List<MR_LIST> request);
        Response<string> InsertNewMRRequest(List<MR_LIST> request);
        Response<string> DeleteMRRequest(string MR_NO, string LOCATION);


    }
}
