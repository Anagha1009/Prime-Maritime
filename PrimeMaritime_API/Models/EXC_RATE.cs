using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class EXC_RATE
    {
        public int ID { get; set; }
        public string CURRENCY_TYPE { get; set; }
        public string CURRENCY_CODE { get; set; }
        public decimal TT_SELLING { get; set; }
    }
}
