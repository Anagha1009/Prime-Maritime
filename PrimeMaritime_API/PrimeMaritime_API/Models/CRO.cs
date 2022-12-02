using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class CRO
    {
        public int ID { get; set; }
        public string CRO_NO { get; set; }
        public int BOOKING_ID { get; set; }
        public string BOOKING_NO { get; set; }
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string CUSTOMER_NAME { get; set; }
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
}
