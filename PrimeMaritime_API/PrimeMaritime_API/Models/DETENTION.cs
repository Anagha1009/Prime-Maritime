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
}
