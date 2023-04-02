using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class DEPO_CONTAINER
    {
        public string BOOKING_NO { get; set; }       
        public string CRO_NO { get; set; }       
        public string CREATED_BY { get; set; }
        public string DEPO_CODE { get; set; }
        public List<CONTAINERS> CONTAINER_LIST { get; set; } = new List<CONTAINERS>();
    }

    public class MR_LIST
    {
        public string MR_NO { get; set; }
        public string CONTAINER_NO { get; set; }
        public string LOCATION { get; set; }
        public string COMPONENT { get; set; }
        public string DAMAGE { get; set; }
        public string REPAIR { get; set; }
        public string DESC { get; set; }
        public decimal LENGTH { get; set; }
        public decimal WIDTH { get; set; }
        public decimal HEIGHT { get; set; }
        public string UNIT { get; set; }
        public string RESPONSIBILITY { get; set; }
        public decimal MAN_HOUR { get; set; }
        public decimal LABOUR { get; set; }
        public decimal MATERIAL { get; set; }
        public decimal TOTAL { get; set; }
        public decimal TAX { get; set; }
        public decimal FINAL_TOTAL { get; set; }
        public string DEPO_CODE { get; set; }
        public string DEPO_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public decimal APPROVED_RATE { get; set; }
        public string REMARKS { get; set; }
        public string STATUS { get; set; }
    }

    public class MNR_LIST
    {
        public string MR_NO { get; set; }
        public string CONTAINER_NO { get; set; }
        public string DEPO_CODE { get; set; }
        public string DEPO_NAME { get; set; }
        public string STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
    }

    public class MNR_TARIFF
    {
        public decimal MAN_HOUR { get; set; }
        public decimal LABOUR_CHARGE { get; set; }
        public decimal MATERIAL_COST { get; set; }
        public decimal TOTAL { get; set; }     
    }
}
