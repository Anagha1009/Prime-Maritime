using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class TDR
    {
        public string TDR_NO { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string POL { get; set; }
        public string TERMINAL { get; set; }
        public DateTime ETA { get; set; }
        public DateTime POB_BERTHING { get; set; }
        public DateTime BERTHED { get; set; }
        public DateTime OPERATION_COMMMENCED { get; set; }
        public DateTime POB_SAILING { get; set; }
        public DateTime SAILED { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA_NEXTPORT { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
    }
}
