using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeMaritime_API.Models
{
    public class RefreshToken
    {
        public int ID { get; set; }
        public int USER_ID { get; set; }
        public string TOKEN { get; set; }
        public DateTime EXPIRES { get; set; }
        public bool ISEXPIRED => DateTime.UtcNow >= EXPIRES;
        public DateTime CREATED { get; set; }
        public DateTime? REVOKED { get; set; }

        //public bool IS_ACTIVE => REVOKED == null && !ISEXPIRED;
        public bool IS_ACTIVE { get; set; }
    }
}
