using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class RATES
    {
        public List<SRR_RATES> FREIGHTLIST { get; set; } = new List<SRR_RATES>();
        public List<SRR_RATES> POL_EXP { get; set; } = new List<SRR_RATES>();
        public List<CHARGE> POD_IMP { get; set; } = new List<CHARGE>();
        public decimal LADEN_BACK_COST { get; set; }
        public decimal EMPTY_BACK_COST { get; set; }

    }

    public class CHARGE
    {
        public string POL { get; set; }
        public string POD { get; set; }
        public string CURRENCY { get; set; }
        public string CHARGE_CODE { get; set; }
        public decimal COST { get; set; }
        public decimal RATE { get; set; }
        public decimal RATE_REQUESTED { get; set; }
        public string PAYMENT_TERM { get; set; } = null;
        public string TRANSPORT_TYPE { get; set; } = null;
        public string CONTAINER_TYPE { get; set; }
        public string AGENT_REMARKS { get; set; }
    }

    public class SRR_RATE_LIST
    {
        public List<CHARGE> FREIGHTLIST { get; set; } = new List<CHARGE>();
        public List<CHARGE> EXP_INCOMELIST { get; set; } = new List<CHARGE>();
        public List<CHARGE> EXP_OTHERINCOMELIST { get; set; } = new List<CHARGE>();
        public List<CHARGE> IMP_INCOMELIST { get; set; } = new List<CHARGE>();
        public List<CHARGE> IMP_OTHERINCOMELIST { get; set; } = new List<CHARGE>();
    }

    public class INVOICELIST
    {
        public int ID { get; set; }
        public string INVOICE_NO { get; set; }
        public string INVOICE_FOR { get; set; }
        public string INVOICE_FOR_ADDRESS { get; set; }
        public string BL_NO { get; set; }
        public string AGENT_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_DATE { get; set; }
    }

    public class INVOICE
    {
        public string INVOICE_NO { get; set; }
        public string INVOICE_FOR { get; set; }
        public string INVOICE_FOR_ADDRESS { get; set; }
        public DateTime INVOICE_DATE { get; set; }
        public string BL_NO { get; set; }
        public string USERNAME { get; set; }
        public string USERADDRESS { get; set; }
        public string SHIPPER { get; set; }
        public string SHIPPER_ADDRESS { get; set; }
        public string CONSIGNEE { get; set; }
        public string CONSIGNEE_ADDRESS { get; set; }
        public string NOTIFY_PARTY { get; set; }
        public string NOTIFY_PARTY_ADDRESS { get; set; }
        public string VESSEL_NAME { get; set; }
        public string VOYAGE_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FINAL_DESTINATION { get; set; }
        public string PLACE_OF_DELIVERY { get; set; }
        public string SERVICE_NAME { get; set; }
        public int TOTAL_CONTAINERS { get; set; }
        public string CONTAINERS { get; set; }
        public List<CHARGE> LOCALCHARGES { get; set; } = new List<CHARGE>();
        public List<CHARGE> FREIGHTLIST { get; set; } = new List<CHARGE>();
        public List<CHARGE> PODCHARGES { get; set; } = new List<CHARGE>();
    }
}
