using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class SRR
    {
        public int ID { get; set; }
        public string SRR_NO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public DateTime VALID_FROM { get; set; }
        public DateTime VALID_TO { get; set; }
        public int POL_FREE_DAYS { get; set; }
        public int POD_FREE_DAYS { get; set; }
        public string CREATED_BY { get; set; }
        public string CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public string UPDATED_DATE { get; set; }
    }
}
