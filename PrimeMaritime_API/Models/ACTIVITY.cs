using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class ACTIVITY
    {
        public int ID { get; set; }
        public string ACT_NAME { get; set; }
        public string ACT_CODE { get; set; }
        public string ACT_TYPE { get; set; }

        public string ACTIVITY_BY { get; set; }
        public string CREATED_BY { get; set; }
       
    }
}
