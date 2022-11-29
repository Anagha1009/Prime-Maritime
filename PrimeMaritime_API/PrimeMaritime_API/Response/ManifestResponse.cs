using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class CargoManifest
    {
        public int ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string CONSIGNEE_ADDRESS { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string SERVICE_NAME { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string BL_NO_DATE { get; set; }
        public string SHIPPER { get; set; }
        public string CONSIGNEE { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string MARKS_NOS { get; set; }
        public string DESC_OF_GOODS { get; set; }
        public decimal GROSS_WEIGHT { get; set; }
        public string DELIVERY_MODE { get; set; }
        public int TWEENTY_FT { get; set; }
        public int FORTY_FT { get; set; }
        public List<BL_CONTAINERS> CONTAINER_LIST { get; set; }

    }

    public class BL_CONTAINERS
    {
        public int ID { get; set; }
        public string CONTAINER_NO { get; set; }
        public string CONTAINER_SIZE { get; set; }
        public string CONTAINER_TYPE { get; set; }
        public string SEAL_NO { get; set; }
        public string STATUS { get; set; }
        public decimal GROSS_WEIGHT { get; set; }
        public string IMO_CLASS { get; set; }
        public string UN_NO { get; set; }
    }
}
