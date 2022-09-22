using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class SRRList
    {
        public string SRR_NO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public DateTime EFFECT_FROM { get; set; }
        public DateTime EFFECT_TO { get; set; }
        public string STATUS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int NO_OF_CONTAINERS { get; set; }
    }
}
