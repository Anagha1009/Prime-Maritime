using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Request
{
    public class SRRRequest
    {
        public int ID { get; set; }
        public string SRR_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FINAL_DESTINATION { get; set; }
        public string SERVICE_NAME { get; set; }
        public string EFFECT_FROM { get; set; }
        public string EFFECT_TO { get; set; }
        public bool IS_VESSELVALIDITY { get; set; }
        public bool MTY_REPO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string CONTACT { get; set; }
        public string SHIPPER { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string OTHER_PARTY { get; set; }
        public string OTHER_PARTY_NAME { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string TSP_1 { get; set; }
        public string TSP_2 { get; set; }        
        public string STATUS { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public List<SRR_CONTAINERS> SRR_CONTAINERS { get; set; } = new List<SRR_CONTAINERS>();
        public List<SRR_RATES> FREIGHT_CHARGES { get; set; } = new List<SRR_RATES>();
        public List<SRR_RATES> POL_CHARGES { get; set; } = new List<SRR_RATES>();
        public List<SRR_RATES> POD_CHARGES { get; set; } = new List<SRR_RATES>();
        public List<SRR_COMMODITIES> SRR_COMMODITIES { get; set; } = new List<SRR_COMMODITIES>();
    }
}
