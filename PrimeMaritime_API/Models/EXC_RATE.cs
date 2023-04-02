using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class EXC_RATE
    {
        public int ID { get; set; }
        public string CURRENCY { get; set; }
        public decimal RATE { get; set; }
        public string AGENT_CODE { get; set; }
    }
}
