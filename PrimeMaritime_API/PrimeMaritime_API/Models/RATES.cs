using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class RATES
    {
        public List<FREIGHT> FREIGHTLIST { get; set; } = new List<FREIGHT>();
    }

    public class FREIGHT
    {
        public string POL { get; set; }
        public string POD { get; set; }
        public string CHARGE { get; set; }
        public string CURRENCY { get; set; }
        public string LADEN_STATUS { get; set; }
        public string CONTAINER_TYPE { get; set; }
    }
}
