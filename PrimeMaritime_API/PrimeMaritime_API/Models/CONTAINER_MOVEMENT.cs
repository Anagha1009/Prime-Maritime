﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
	public class CONTAINER_MOVEMENT
	{
		public int ID{get;set;}
		public string BOOKING_NO { get; set; }
		public string CRO_NO { get; set; }
		public string CONTAINER_NO { get; set; }
		public string ACTIVITY { get; set; }
		public string PREV_ACTIVITY { get; set; }
		public DateTime ACTIVITY_DATE { get; set; }
		
		public string LOCATION { get; set; }
		public string STATUS { get; set; }
		public string AGENT_CODE { get; set; }
		public string DEPO_CODE { get; set; }
		public string CREATED_BY { get; set; }

		public virtual List<CM> CONTAINER_MOVEMENT_LIST { get; set; } = new List<CM>();
	}

	public class CM
    {
		public int ID { get; set; }
		public string BOOKING_NO { get; set; }
		public string CRO_NO { get; set; }
		public string CONTAINER_NO { get; set; }
		public string ACTIVITY { get; set; }
		public string PREV_ACTIVITY { get; set; }
		public DateTime ACTIVITY_DATE { get; set; }
		public string LOCATION { get; set; }
		public string STATUS { get; set; }
		public string AGENT_CODE { get; set; }
		public string DEPO_CODE { get; set; }
		public string CREATED_BY { get; set; }

	}
}
