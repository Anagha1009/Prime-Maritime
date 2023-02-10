using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class DO
    {
        public int ID { get; set; }
		public int BL_ID { get; set; }
		public string BL_NO { get; set; }
		public string DO_NO { get; set; }

		public DateTime? DO_DATE { get; set; }
		public DateTime ARRIVAL_DATE { get; set; }
		public DateTime DO_VALIDITY { get; set; }
		public string IGM_NO { get; set; }
		public string IGM_ITEM_NO { get; set; }
		public DateTime IGM_DATE { get; set; }

		public string CLEARING_PARTY { get; set; }
		public string ACCEPTANCE_LOCATION { get; set; }

		public DateTime LETTER_VALIDITY { get; set; }
		public string SHIPPING_TERMS { get; set; }

		public string AGENT_CODE { get; set; }
		public string AGENT_NAME { get; set; }
		public string CREATED_BY { get; set; }

		public List<CONTAINERS> CONTAINER_LIST2 { get; set; } = new List<CONTAINERS>();

	}
}
