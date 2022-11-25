using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class ACTIVITY_MAPPING
    {
        public int ID { get; set; }
        public int ACT_ID { get; set; }
        public List<ACTIVITY_ID> ACT_SEQ_ID { get; set; } = new List<ACTIVITY_ID>();
        public string CREATED_BY { get; set; }

    }

    public class ACTIVITY_ID
    {
        public int ID { get; set; }
        public string ACT_CODE { get; set; }
    }
}
