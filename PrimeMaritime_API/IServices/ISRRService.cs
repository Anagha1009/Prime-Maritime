using PrimeMaritime_API.Helpers;
using PrimeMaritime_API.Models;
using PrimeMaritime_API.Request;
using PrimeMaritime_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.IServices
{
    public interface ISRRService
    {
        Response<SRR> GetSRRBySRRNo(string SRR_NO, string AGENT_CODE);
        Response<string> GetRate(string POL, string POD, string CHARGE, string CONT_TYPE);
        Response<List<SRRList>> GetSRRList(string OPERATION, string SRR_NO, string CUSTOMER_NAME, string STATUS,string FROMDATE,string TODATE, string AGENT_CODE, string ORG_CODE, string PORT);
        Response<string> InsertSRR(SRRRequest sRRRequest);
        Response<string> UpdateSRR(List<SRR_RATES> request);
        Response<string> InsertContainer(List<SRR_CONTAINERS> request);
        Response<CommonResponse> ApproveRate(List<SRR_RATES> request);
        Response<CommonResponse> CounterRate(List<SRR_RATES> request);
        Response<RATES> GetCalRates(string POL, string POD, string CONTAINER_TYPE, string SRR_NO, int NO_OF_CONTAINERS);
        Response<string> InsertInvoice(INVOICELIST request);
        Response<string> InsertDestinationAgent(string DESTINATION_AGENT_CODE, string SRR_NO);
        Response<INVOICE> GetInvoiceDetails(string INVOICE_NO, string CONTAINER_TYPE);        
        Response<List<INVOICELIST>> GetInvoiceList(string INVOICE_NO, string FROM_DATE, string TO_DATE, string AGENT_CODE);
        Response<SRR_RATE_LIST> GetSRRRateList(string POL, string POD, string CONTAINER_TYPE, int NO_OF_CONTAINERS);
        Response<EXC_RATE> GetExcRates(string CURRENCY_CODE, string AGENT_CODE, string ORG_CODE, string PORT);
        Response<List<EXC_RATE>> GetExcRateList(string ORG_CODE, string PORT);
        Response<string> InsertExcRate(List<EXC_RATE> excRateList);
    }
}
