using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class RATES
    {
        public List<SRR_RATES> FREIGHTLIST { get; set; } = new List<SRR_RATES>();
        public List<SRR_RATES> POL_EXP { get; set; } = new List<SRR_RATES>();
        public List<CHARGE> POD_IMP { get; set; } = new List<CHARGE>();
        public decimal LADEN_BACK_COST { get; set; }

    }

    public class FREIGHT
    {
        public string POL { get; set; }
        public string POD { get; set; }
        public string CHARGE { get; set; }
        public string CURRENCY { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public decimal RATE { get; set; }
        public decimal RATE_REQUESTED { get; set; }
    }

    public class CHARGE
    {
        public string POL { get; set; }
        public string POD { get; set; }
        public string CURRENCY { get; set; }
        public string CHARGE_CODE { get; set; }
        public string IE { get; set; }
        public string CHARGE_TYPE { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public decimal RATE { get; set; }
        public decimal RATE_REQUESTED { get; set; }
    }

    public class SRR_RATE_LIST
    {
        public List<FREIGHT> FREIGHTLIST { get; set; } = new List<FREIGHT>();
        public List<CHARGE> EXP_COSTLIST { get; set; } = new List<CHARGE>();
        public List<FREIGHT> EXP_OTHERCOSTLIST { get; set; } = new List<FREIGHT>();
    }
}
