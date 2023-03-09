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
        public string CONTAINER_TYPE { get; set; }
        public int CONTAINER_SIZE { get; set; }
        public string SERVICE_MODE { get; set; }
        public int POD_FREE_DAYS { get; set; }
        public int POL_FREE_DAYS { get; set; }
        public int IMM_VOLUME_EXPECTED { get; set; }
        public int TOTAL_VOLUME_EXPECTED { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
        public string CONTAINERS { get; set; }
        public string STATUS { get; set; }
        public string COMMODITY { get; set; }
    }
}
