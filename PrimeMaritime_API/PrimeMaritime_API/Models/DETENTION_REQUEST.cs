using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class DETENTION_REQUEST
    {
        public int ID { get; set; }
        public string CONTAINER_NO { get; set; }
        public string DOCUMENT_TYPE { get; set; }
        public string DOCUMENT_NO { get; set; }
        public string SHIPPER_NAME { get; set; }
        public string CLEARING_PARTY { get; set; }
        public int DETENTION_DAYS { get; set; }
        public decimal DETENTION { get; set; }
        public string CURRENCY { get; set; }
        public int TARRIF_ID { get; set; }
        public decimal WAIVER_REQUESTED { get; set; }
        public decimal WAIVER_APPROVED { get; set; }
        public string AGENT_REMARKS { get; set; }
        public string PRINCIPAL_REMARKS { get; set; }
        public string STATUS { get; set; }
        public DateTime MODIFIED_ON { get; set; }
        public string MODIFIED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string CREATED_BY { get; set; }

    }
}
