using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class SRR_COMMODITIES
    {
        public int ID { get; set; }
        public int SRR_ID { get; set; }
        public string SRR_NO { get; set; }
        public string COMMODITY_NAME { get; set; }
        public double LENGTH { get; set; }
        public double WIDTH { get; set; }
        public double HEIGHT { get; set; }
        public decimal WEIGHT { get; set; }
        public string WEIGHT_UNIT { get; set; }
        public string COMMODITY_TYPE { get; set; }
        public string IMO_CLASS { get; set; }
        public string UN_NO { get; set; }
        public string HAZ_APPROVAL_REF { get; set; }
        public string FLASH_POINT { get; set; }
        public string CAS_NO { get; set; }
        public string TEMPERATURE { get; set; }
        public string VENTILATION { get; set; }
        public string HUMIDITY { get; set; }
        public string REMARKS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_DATE { get; set; }

    }
}
