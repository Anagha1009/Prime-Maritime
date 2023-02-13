using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class LOAD_LIST
    {
        public string SRR_NO { get; set; }
        public string CONTAINER_NO { get; set; }
        public string SEAL_NO { get; set; }
        public int CONTAINER_SIZE { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public decimal GROSS_WEIGHT { get; set; }
        public string COMMODITY_TYPE { get; set; }
        public string IMO_CLASS { get; set; }
        public string UN_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FINAL_DESTINATION { get; set; }
        public string SHIPPER { get; set; }
        public string COMMODITY_NAME { get; set; }
        public string REMARKS { get; set; }
    }
}
