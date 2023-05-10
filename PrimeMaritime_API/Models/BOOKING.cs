using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class BOOKING
    {
        public int ID { get; set; }
        public string BOOKING_NO { get; set; }
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }       
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string MOTHER_VESSEL_NAME { get; set; }
        public string MOTHER_VOYAGE_NO { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public Boolean IS_ROLLOVER { get; set; }
        public List<SLOT_DETAILS> SLOT_LIST { get; set; }
    }

    public class SLOT_DETAILS
    {
        public int ID { get; set; }
        public int BOOKING_ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string REPO_NO { get; set; }
        public string SLOT_OPERATOR { get; set; }
        public int NO_OF_SLOTS { get; set; }
        public string CREATED_BY { get; set; }
    }

    public class VOYAGE
    {
        public int ID { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public DateTime? ATA { get; set; }
        public DateTime? ATD { get; set; }
        public DateTime? ETA { get; set; }
        public DateTime? ETD { get; set; }
        //public string IMM_CURR { get; set; }
        //public decimal IMM_CURR_RATE { get; set; }
        //public string EXP_CURR { get; set; }
        //public decimal EXP_CURR_RATE { get; set; }
        public string TERMINAL_CODE { get; set; }
        public string SERVICE_NAME { get; set; }
        public string VIA_NO { get; set; }
        public string PORT_CODE { get; set; }
        public bool STATUS { get; set; }
        public string CREATED_BY { get; set; }
    }

   
        public class ROLLOVER
        {
            public int BOOKING_ID { get; set; }
            public string BOOKING_NO { get; set; }

            public string VESSEL_NAME { get; set; }

            public string VOYAGE_NO { get; set; }

            public string MOTHER_VESSEL_NAME { get; set; }

            public string MOTHER_VOYAGE_NO { get; set; }

            public string AGENT_CODE { get; set; }

            public string AGENT_NAME { get; set; }
            public string STATUS { get; set; }

            public DateTime CREATED_DATE { get; set; }

        }
    
}
