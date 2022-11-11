using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class MASTER
    {
        public int ID { get; set; }
        public string CUST_NAME { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string CUST_EMAIL { get; set; }

        public string CUST_CONTACT { get; set; }

        public string CUST_TYPE { get; set; }

        public string GSTIN { get; set; }
        public Boolean STATUS { get; set; }
        public string REMARKS { get; set; }

        public string AGENT_CODE { get; set; }

        public int CREATED_BY { get; set; }

        public DateTime CREATED_ON { get; set; }

        public int MODIFIED_BY { get; set; }

        public DateTime MODIFIED_ON { get; set; }








    }
}
