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
        public List<CONTAINERS> CONTAINER_LIST { get; set; } = new List<CONTAINERS>();
    }
}
