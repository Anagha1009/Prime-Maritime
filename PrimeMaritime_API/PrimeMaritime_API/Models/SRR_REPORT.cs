using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class SRR_REPORT
    {
        public string MONTH { get; set; }
        public int YEAR { get; set; }
        public int TOTAL { get; set; }
        public int APPROVED { get; set; }
        public int REQUESTED { get; set; }
        public int REJECTED { get; set; }
    }
}
