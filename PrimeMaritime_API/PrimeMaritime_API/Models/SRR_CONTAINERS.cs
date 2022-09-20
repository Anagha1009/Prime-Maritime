using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class SRR_CONTAINERS
    {
        public int ID { get; set; }
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }
        public int NO_OF_CONTAINERS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
    }
}
