using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class MasterDetails
    {
        public string CUST_NAME { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string CUST_EMAIL { get; set; }

        public string CUST_CONTACT { get; set; }

        public string CUST_TYPE { get; set; }

        public string GSTIN { get; set; }
    }
}
