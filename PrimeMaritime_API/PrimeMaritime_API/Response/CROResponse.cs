using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class CROResponse
    {
        public int CRO_ID { get; set; }
        public string CRO_NO { get; set; }
        public int BOOKING_ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string STUFFING_TYPE { get; set; }
        public string EMPTY_CONT_PCKP { get; set; }
        public string LADEN_ACPT_LOCATION { get; set; }
        public DateTime CRO_VALIDITY_DATE { get; set; }
        public string REMARKS { get; set; }
        public int REQ_QUANTITY { get; set; }
        public decimal GROSS_WT { get; set; }
        public string GROSS_WT_UNIT { get; set; }
        public string PACKAGES { get; set; }
        public int NO_OF_PACKAGES { get; set; }
        public string STATUS { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string CREATED_BY { get; set; }

    }

    public class CRODetails
    {
        public int ID { get; set; }
        public string CRO_NO { get; set; }
        public int BOOKING_ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string STUFFING_TYPE { get; set; }
        public string EMPTY_CONT_PCKP { get; set; }
        public string LADEN_ACPT_LOCATION { get; set; }
        public DateTime CRO_VALIDITY_DATE { get; set; }
        public int REQ_QUANTITY { get; set; }
        public decimal GROSS_WT { get; set; }
        public string GROSS_WT_UNIT { get; set; }
        public string PACKAGES { get; set; }
        public int NO_OF_PACKAGES { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string ADDRESS { get; set; }

        public string EMAIL { get; set; }

        public string CONTACT { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public BOOKING BookingDetails { get; set; }
        public List<SRR_CONTAINERS> ContainerList { get; set; }
    }
}
