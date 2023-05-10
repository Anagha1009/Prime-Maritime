using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class SRR
    {
        public int ID { get; set; }
        public string SRR_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FINAL_DESTINATION { get; set; }
        public string ORIGIN_ICD { get; set; }
        public string DESTINATION_ICD { get; set; }
        public string SERVICE_NAME { get; set; }
        public DateTime EFFECT_FROM { get; set; }
        public DateTime EFFECT_TO { get; set; }
        public bool IS_VESSELVALIDITY { get; set; }
        public string BOOKING_NO { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public int DAYS { get; set; }
        public bool MTY_REPO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string CONTACT { get; set; }
        public string SHIPPER { get; set; }
        public string CONSIGNEE { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string BROKERAGE_PARTY { get; set; }
        public string FORWARDER { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string TSP_1 { get; set; }
        public string TSP_2 { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public string CONTAINER_SIZE { get; set; }
        public string SERVICE_MODE { get; set; }
        public int POD_FREE_DAYS { get; set; }
        public int POL_FREE_DAYS { get; set; }
        public int IMM_VOLUME_EXPECTED { get; set; }
        public int TOTAL_VOLUME_EXPECTED { get; set; }       
        public string STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public decimal LADEN_BACK_COST { get; set; }
        public decimal EMPTY_BACK_COST { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string ORG_CODE { get; set; }
        public string PORT { get; set; }
        public List<SRR_CONTAINERS> SRR_CONTAINERS { get; set; } = new List<SRR_CONTAINERS>();
        public List<SRR_RATES> SRR_RATES { get; set; } = new List<SRR_RATES>();
        public List<SRR_COMMODITIES> SRR_COMMODITIES { get; set; } = new List<SRR_COMMODITIES>();
    }
}
