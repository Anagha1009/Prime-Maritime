using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Request
{
    public class BookingRequest
    {
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string MOTHER_VESSEL_NAME { get; set; }
        public string MOTHER_VOYAGE_NO { get; set; }
        public string SLOT_OPERATOR { get; set; }
        public int NO_OF_SLOTS { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string CREATED_BY { get; set; }
    }
}
