using PrimeMaritime_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Response
{
    public class ActivityMappingResponse
    {
        public int ACT_ID { get; set; }
        public List<ACTIVITY> ActivityList { get; set; }
    }
}
