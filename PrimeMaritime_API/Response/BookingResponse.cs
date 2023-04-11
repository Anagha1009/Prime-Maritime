using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class BookingList
    {
        public int ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string SRR_NO { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string SERVICE_NAME { get; set; }
        public string SHIPPER { get; set; }
        public string CONSIGNEE { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string PLACE_OF_RECEIPT { get; set; }
        public int NO_OF_CONTAINERS { get; set; }
        public string SRR_STATUS { get; set; }
        public string CONTAINERS { get; set; }
        public string COMMODITY { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string SLOTS { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public int TOTAL_VOLUME_EXPECTED { get; set; }
        public int CRO_QTY { get; set; }
    }

    public class BookingDetails
    {
        public int ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public List<SRR_CONTAINERS> CONTAINER_LIST { get; set; }
        public List<SLOT_DETAILS> SLOT_LIST { get; set; }
        public int TOTAL_VOLUME_EXPECTED { get; set; }
        public int CRO_QTY { get; set; }
    }

    
}
