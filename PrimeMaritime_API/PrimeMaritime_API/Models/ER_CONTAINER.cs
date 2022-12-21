using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class ER_CONTAINER
    {
        public string REPO_NO { get; set; }
        public string CONTAINER_NO { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public string CONTAINER_SIZE { get; set; }
        public string SEAL_NO { get; set; }
        public string MARKS_NOS { get; set; }
        public string DESC_OF_GOODS { get; set; }
        public decimal GROSS_WEIGHT { get; set; }
        public string MEASUREMENT { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }

        public string DEPO_CODE { get; set; }
        public string CREATED_BY { get; set; }
    }

    public class ER_RATES
    {
        public int ID { get; set; }
        public string REPO_NO { get; set; }
        public string CHARGE_CODE { get; set; }
        public string CURRENCY { get; set; }
        public decimal STANDARD_RATE { get; set; }
        public string CHARGE_TYPE { get; set; }
        public string REMARKS { get; set; }
        public string CREATED_BY { get; set; }
    }
}
