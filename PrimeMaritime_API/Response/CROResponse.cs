using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class CRODetails
    {
        public int ID { get; set; }
        public string CRO_NO { get; set; }
        public int BOOKING_ID { get; set; }
        public string BOOKING_NO { get; set; }
        public string STUFFING_TYPE { get; set; }
        public string EMPTY_CONT_PCKP { get; set; }
        public string LADEN_ACPT_LOCATION { get; set; }
        public DateTime CRO_VALIDITY_DATE { get; set; }
        public int REQ_QUANTITY { get; set; }
        public decimal GROSS_WT { get; set; }
        public string GROSS_WT_UNIT { get; set; }
        public string PACKAGES { get; set; }
        public int NO_OF_PACKAGES { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string CONTACT { get; set; }
        public string SHIPPER_NAME { get; set; }
        public string SERVICE_NAME { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FINAL_DESTINATION { get; set; }
        public int CRO_QTY { get; set; }
        public int ALLOTED_CONTAINERS { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string CONTAINERS { get; set; }
        public string COMMODITY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public BOOKING BookingDetails { get; set; }
        public List<SRR_CONTAINERS> ContainerList { get; set; }
    }
}
