using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class SRR_RATES
    {
        public int ID { get; set; }
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public string CHARGE_CODE { get; set; }
        public string TRANSPORT_TYPE { get; set; }
        public string CURRENCY { get; set; }
        public string RATE_TYPE { get; set; }
        public string PAYMENT_TERM { get; set; }
        public decimal RATE { get; set; }
        public decimal COST { get; set; }
        public decimal RATE_REQUESTED { get; set; }
        public decimal STANDARD_RATE { get; set; }
        public decimal APPROVED_RATE { get; set; }
        public string STATUS { get; set; }
        public string REMARKS { get; set; }
        public string AGENT_REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }
    }
}
