using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class DETENTION_WAIVER_REQUEST
    {
        public string CONTAINER_NO { get; set; }
        public string PORT_OF_DISCHARGE { get; set; }
        public string CONSIGNEE { get; set; }
        public string CLEARING_PARTY { get; set; }
        public int DETENTION_DAYS { get; set; }
        public decimal DETENTION_RATE { get; set; }
        public string CURRENCY { get; set; }
        public string  REMARK { get; set; }
        public string CREATED_BY { get; set; }

    }

    public class DETENTION
    {
        public string DO_NO { get; set; }
        public List<DETENTION_WAIVER_REQUEST> DETENTION_LIST { get; set; } = new List<DETENTION_WAIVER_REQUEST>();
    }

    public class CONTAINER_DETENTION
    {
        public string CONTAINER_NO { get; set; }
        public string BL_NO { get; set; }
        public string POD_FREE_DAYS { get; set; }
        public string VESSEL_NAME { get; set; }
        public string DCHF_DATE { get; set; }
        public string RCCN_DATE { get; set; }
        public decimal POL_DETENTION { get; set; }
        public decimal POD_DETENTION { get; set; }
        public string RCCN_MONTH { get; set; }
    }
}
