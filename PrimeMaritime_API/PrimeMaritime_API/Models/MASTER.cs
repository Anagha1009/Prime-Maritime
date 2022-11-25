using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class PARTY_MASTER
    {
        public int CUST_ID { get; set; }
        public string CUST_NAME { get; set; }
        public string CUST_ADDRESS { get; set; }
        public string CUST_EMAIL { get; set; }

        public string CUST_CONTACT { get; set; }

        public string CUST_TYPE { get; set; }

        public string GSTIN { get; set; }
        public Boolean STATUS { get; set; }
        public string REMARKS { get; set; }

        public string AGENT_CODE { get; set; }

        public string CREATED_BY { get; set; }

    }

    public class CONTAINER_MASTER
    {
        public int ID { get; set; }
        public string CONTAINER_NO { get; set; }
        public string CONTAINER_TYPE { get; set; }

        public string CONTAINER_SIZE { get; set; }

        public Boolean IS_OWNED { get; set; }

        public DateTime? ON_HIRE_DATE { get; set; } = null;

        public DateTime? OFF_HIRE_DATE { get; set; } = null;

        public DateTime? MANUFACTURING_DATE { get; set; } = null;

        public Boolean SHIPPER_OWNED { get; set; }

        public string OWNER_NAME { get; set; }

        public string LESSOR_NAME { get; set; }

        public string PICKUP_LOCATION { get; set; }

        public string DROP_LOCATION { get; set; }

        public Boolean STATUS { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; } = null;

        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_DATE { get; set; } = null;
    }

    public class SIZE
    {
        public int ID { get; set; }
        public string CONT_SIZE { get; set; }
        public Boolean STATUS { get; set; }
        public string CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; } = null;

        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_DATE { get; set; } = null;
    }

    public class MASTER
    {
        public int ID { get; set; }

        public string KEY_NAME { get; set; }

        public string CODE { get; set; }

        public string CODE_DESC { get; set; }

        public Boolean STATUS { get; set; }

        public string PARENT_CODE { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime? CREATED_DATE { get; set; } = null;

        public string UPDATED_BY { get; set; }

        public DateTime? UPDATED_DATE { get; set; } = null;


    }
}
