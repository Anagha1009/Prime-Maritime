using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class BL
    {
        public int ID { get; set; }
        public string BL_NO { get; set; }
        public string BOOKING_NO { get; set; }
        public string CRO_NO { get; set; }
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }
        public string SHIPPER { get; set; }
        public string SHIPPER_ADDRESS { get; set; }
        public string CONSIGNEE { get; set; }
        public string CONSIGNEE_ADDRESS { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string NOTIFY_PARTY_ADDRESS { get; set; }
        public string PRE_CARRIAGE_BY { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string PORT_OF_LOADING { get; set; }
        public string PORT_OF_DISCHARGE { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string FINAL_DESTINATION { get; set; }
        public string PREPAID_AT { get; set; }
        public string PAYABLE_AT { get; set; }
        public string BL_ISSUE_PLACE { get; set; }
        public DateTime BL_ISSUE_DATE { get; set; }
        public decimal TOTAL_PREPAID { get; set; }
        public int NO_OF_ORIGINAL_BL { get; set; }

        public string BL_STATUS { get; set; }

        public string MARKS_NOS { get; set; }
        public string DESC_OF_GOODS { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public List<CONTAINERS> CONTAINER_LIST { get; set; } = new List<CONTAINERS>();
    }

    public class CONTAINERS
    {
        public int ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string CRO_NO { get; set; }
        public string BL_NO { get; set; }
        public string DO_NO { get; set; }
        public string CONTAINER_NO { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public int CONTAINER_SIZE { get; set; }
        public string SEAL_NO { get; set; }
        public string MARKS_NOS { get; set; }
        public string DESC_OF_GOODS { get; set; }
        public decimal GROSS_WEIGHT { get; set; }
        public string MEASUREMENT { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string CREATED_BY { get; set; }
    }
}
